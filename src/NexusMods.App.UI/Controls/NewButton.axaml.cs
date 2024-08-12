using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace NexusMods.App.UI.Controls;

public class NewButton : TemplatedControl
{
    public static readonly StyledProperty<string?> TextProperty = TextBlock.TextProperty.AddOwner<TopLevelMenuItemHeader>();
    
    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}

