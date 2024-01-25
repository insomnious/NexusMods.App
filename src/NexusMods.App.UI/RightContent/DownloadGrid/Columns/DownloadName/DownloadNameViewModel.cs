using System.Reactive.Disposables;
using NexusMods.App.UI.Controls.DataGrid;
using NexusMods.App.UI.RightContent.Downloads.ViewModels;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace NexusMods.App.UI.RightContent.DownloadGrid.Columns.DownloadName;

public class DownloadNameViewModel : AViewModel<IDownloadNameViewModel>, IDownloadNameViewModel, IComparableColumn<IDownloadTaskViewModel>
{
    [Reactive]
    public IDownloadTaskViewModel Row { get; set; } = new DownloadTaskDesignViewModel();

    [Reactive]
    public string Name { get; set; } = "";

    public DownloadNameViewModel()
    {
        this.WhenActivated(d =>
        {
            this.WhenAnyValue(vm => vm.Row.Name)
                .BindToUi(this, vm => vm.Name)
                .DisposeWith(d);
        });
    }

    public int Compare(IDownloadTaskViewModel a, IDownloadTaskViewModel b) => String.Compare(a.Name, b.Name, StringComparison.Ordinal);
}
