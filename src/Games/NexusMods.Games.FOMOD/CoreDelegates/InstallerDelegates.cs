using FomodInstaller.Interface;
using FomodInstaller.Interface.ui;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using NexusMods.Common.GuidedInstaller;

namespace NexusMods.Games.FOMOD.CoreDelegates;

[UsedImplicitly]
public sealed class InstallerDelegates : ICoreDelegates
{
    public IContextDelegates context { get; }
    public IIniDelegates ini => throw new NotImplementedException();
    public IPluginDelegates plugin { get; }
    public IUIDelegates ui { get; }

    public InstallerDelegates(ILoggerFactory loggerFactory, IGuidedInstaller guidedInstaller)
    {
        context = new ContextDelegates(loggerFactory.CreateLogger<ContextDelegates>());
        plugin = new PluginDelegates(loggerFactory.CreateLogger<PluginDelegates>());
        ui = new UiDelegates(loggerFactory.CreateLogger<UiDelegates>(), guidedInstaller);
    }
}
