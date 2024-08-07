using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NexusMods.Abstractions.Activities;
using NexusMods.Abstractions.Games.DTO;
using NexusMods.Abstractions.NexusWebApi;
using NexusMods.Abstractions.NexusWebApi.DTOs;
using NexusMods.Abstractions.NexusWebApi.Types;
using NexusMods.Hashing.xxHash64;
using NexusMods.Networking.Downloaders.Tasks.State;
using NexusMods.Paths;

namespace NexusMods.Networking.Downloaders.Tasks;

/// <summary>
/// Represents an individual task to download and install a .nxm link.
/// </summary>
/// <remarks>
///     This task is usually created via <see cref="DownloadService.AddTask(NexusMods.Abstractions.NexusWebApi.Types.NXMUrl)"/>.
/// </remarks>
[Obsolete(message: "To be replaced with Jobs")]
public class NxmDownloadTask : ADownloadTask
{
    private readonly INexusApiClient _nexusApiClient;

    private NxmDownloadState.ReadOnly NxPersistentState
    {
        get
        {
            if (!PersistentState.TryGetAsNxmDownloadState(out var nxState))
                throw new InvalidOperationException("Download task is not a NXM download task.");
            return nxState;
        }
    }

    public NxmDownloadTask(IServiceProvider provider) : base(provider)
    {
        _nexusApiClient = provider.GetRequiredService<INexusApiClient>();
    }

    /// <summary>
    /// Creates a new download task for the given NXM URL.
    /// </summary>
    internal async Task Create(NXMModUrl nxmUrl)
    {
        using var tx = Connection.BeginTransaction();
        var id = base.Create(tx);

        tx.Add(id, NxmDownloadState.ModId, nxmUrl.ModId);
        tx.Add(id, NxmDownloadState.FileId, nxmUrl.FileId);
        tx.Add(id, NxmDownloadState.Game, nxmUrl.Game);
        tx.Add(id, DownloaderState.GameDomain, GameDomain.From(nxmUrl.Game));
        tx.Add(id, DownloaderState.FriendlyName, "<Unknown>");
        
        if (nxmUrl.ExpireTime.HasValue) 
            tx.Add(id, NxmDownloadState.ValidUntil, nxmUrl.ExpireTime!.Value);
        if (nxmUrl.Key.HasValue)
            tx.Add(id, NxmDownloadState.NxmKey, nxmUrl.Key!.Value.Value);
        
        await Init(tx, id);
    }


    protected override async Task Download(AbsolutePath destination, CancellationToken token)
    {
        Logger.LogInformation("Initializing download links for NXM file {Name}", PersistentState.FriendlyName);
        var links = await InitDownloadLinks(token);

        var foundSize = PersistentState.Contains(DownloaderState.Size);
        if (!foundSize && PersistentState.Contains(NxmDownloadState.ModId))
        {
            Logger.LogInformation("Getting Nexus Mod metadata for NXM file {Name}", PersistentState.FriendlyName);
            foundSize = await UpdateMetadata(token);
        }
        
        if (!foundSize && !PersistentState.Contains(DownloaderState.Size))
        {
            Logger.LogInformation("Getting metadata for NXM file {Name}", PersistentState.FriendlyName);
            await UpdateSizeAndName(links);
        }


        var activity = ((IActivitySource<Size>)TransientState!.Activity!);
        activity.SetMax(PersistentState.Size);

        Logger.LogInformation("Starting download of NXM file {Name}", PersistentState.FriendlyName);
        
        var hash = await HttpDownloader.DownloadAsync(links, destination, TransientState, PersistentState.Size, token);
        if (hash.Value == Hash.Zero)
            throw new OperationCanceledException();
        
        Logger.LogInformation("Finished download of NXM file {Name}", PersistentState.FriendlyName);
    }

    private async Task<bool> UpdateMetadata(CancellationToken token)
    {
        try
        {
            var nxState = NxPersistentState;
            
            var fileInfos = await _nexusApiClient.ModFilesAsync(nxState.Game, nxState.ModId, token);

            var file = fileInfos.Data.Files.FirstOrDefault(f => f.FileId == nxState.FileId);
            
            var info = await _nexusApiClient.ModInfoAsync(nxState.Game, nxState.ModId, token);


            var eid = PersistentState.Id;
            if (file is { SizeInBytes: not null })
            {
                using var tx = Connection.BeginTransaction();
                if (!string.IsNullOrWhiteSpace(info.Data.Name))
                    tx.Add(eid, DownloaderState.FriendlyName, info.Data.Name);
                else
                    tx.Add(eid, DownloaderState.FriendlyName, file.FileName);
                
                tx.Add(eid, DownloaderState.Size, Size.FromLong(file.SizeInBytes!.Value));
                tx.Add(eid, DownloaderState.Version, file.Version);
                await tx.Commit();
                RefreshState();
                return true;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to update metadata for NXM file {Name}", PersistentState.FriendlyName);
            return false;
        }

        return false;

    }

    private async Task UpdateSizeAndName(HttpRequestMessage[] message)
    {
        var (name, size) = await GetNameAndSizeAsync(message.First().RequestUri!);
        using var tx = Connection.BeginTransaction();
        tx.Add(PersistentState.Id, DownloaderState.Size, size);
        tx.Add(PersistentState.Id, DownloaderState.FriendlyName, name);
        
        Logger.LogDebug("Updated size and name for {Name} to {Size}", name, size);
        await tx.Commit();
        RefreshState();
    }
    
    private async Task<HttpRequestMessage[]> InitDownloadLinks(CancellationToken token)
    {
        Response<DownloadLink[]> links;

        var nxState = NxPersistentState;

        if (!NxmDownloadState.NxmKey.TryGet(nxState, out var nxmKey))
        {
            links = await _nexusApiClient.DownloadLinksAsync(nxState.Game, nxState.ModId, nxState.FileId, token);
        }
        else
        {
            links = await _nexusApiClient.DownloadLinksAsync(nxState.Game, nxState.ModId, nxState.FileId, NXMKey.From(nxState.NxmKey), nxState.ValidUntil, token);
        }
        return links.Data.Select(u => new HttpRequestMessage(HttpMethod.Get, u.Uri)).ToArray();
    }

   
}
