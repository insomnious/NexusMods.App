using System.Reactive;
using Avalonia.Media.Imaging;
using NexusMods.Abstractions.GameLocators;
using ReactiveUI;

namespace NexusMods.App.UI.Controls.GameWidget;

public interface IGameWidgetViewModel : IViewModelInterface
{
    public GameInstallation Installation { get; set; }
    public string Name { get; }
    public Bitmap Image { get; }
    public ReactiveCommand<Unit,Unit> AddGameCommand { get; set; }
    public ReactiveCommand<Unit,Unit> ViewGameCommand { get; set; }
    
    // TODO: This is temporary, to speed up development. Until design comes up with UX for deleting loadouts.
    public ReactiveCommand<Unit,Unit> RemoveAllLoadoutsCommand { get; set; }

    public GameWidgetState State { get; set; }
    public bool CanAddMoreThanOneLoadout { get; }
}

public enum GameWidgetState : byte
{
    DetectedGame,
    AddingGame,
    ManagedGame,
    RemovingGame,
}

