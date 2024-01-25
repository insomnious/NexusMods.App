using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NexusMods.Abstractions.DataModel.Entities;
using NexusMods.Abstractions.Games;
using NexusMods.Abstractions.Installers;
using NexusMods.Abstractions.Serialization;
using NexusMods.Activities;
using NexusMods.App.BuildInfo;
using NexusMods.Games.TestFramework;
using NexusMods.StandardGameLocators.TestHelpers;

namespace NexusMods.Games.Sifu.Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection container)
    {
        container
            .AddDefaultServicesForTesting()
            .AddUniversalGameLocator<Sifu>(new Version())
            .AddSifu()
            .AddLogging(builder => builder.AddXUnit())
            .AddGames()
            .AddActivityMonitor()
            .AddDataModelEntities()
            .AddDataModelBaseEntities()
            .AddInstallerTypes()
            .Validate();
    }
}
