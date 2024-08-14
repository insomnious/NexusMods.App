using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using NexusMods.Icons;

namespace NexusMods.App.UI.Controls;

[TemplatePart("PART_LeftIcon",  typeof(UnifiedIcon))]
[TemplatePart("PART_RightIcon", typeof(UnifiedIcon))]
[TemplatePart("PART_Label", typeof(TextBlock))]
public class NewButton : Button
{

    public enum ShowIcons
    {
        None,Left,Right,Both,
    }

    private UnifiedIcon? _leftIcon  = null;
    private UnifiedIcon? _rightIcon = null;
    private TextBlock? _label = null;
    
    public static readonly StyledProperty<string?> TextProperty = AvaloniaProperty.Register<NewButton, string?>(nameof(Text), defaultValue: "New Button");
    public static readonly StyledProperty<IconValue?> LeftIconProperty = AvaloniaProperty.Register<NewButton, IconValue?>(nameof(LeftIcon), defaultValue: IconValues.ChevronDown);
    public static readonly StyledProperty<IconValue?> RightIconProperty = AvaloniaProperty.Register<NewButton, IconValue?>(nameof(RightIcon), defaultValue: IconValues.ChevronUp);
    
    public static readonly AttachedProperty<ShowIcons> IconsProperty = AvaloniaProperty.RegisterAttached<NewButton, TemplatedControl, ShowIcons>("Icons", defaultValue: ShowIcons.None);
    public static readonly AttachedProperty<bool> ShowLabelProperty = AvaloniaProperty.RegisterAttached<NewButton, TemplatedControl, bool>("ShowLabel", defaultValue: true);
    
    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public ShowIcons? ShowIcon
    {
        get => GetValue(IconsProperty);
        set => SetValue(IconsProperty, value);
    }
    
    public IconValue? LeftIcon
    {
        get => GetValue(LeftIconProperty);
        set => SetValue(LeftIconProperty, value);
    }
    
    public IconValue? RightIcon
    {
        get => GetValue(RightIconProperty);
        set => SetValue(RightIconProperty, value);
    }
    
    public bool ShowLabel
    {
        get => GetValue(ShowLabelProperty);
        set => SetValue(ShowLabelProperty, value);
    }

    /// <inheritdoc/>
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        _leftIcon = e.NameScope.Find<UnifiedIcon>("PART_LeftIcon");
        _rightIcon = e.NameScope.Find<UnifiedIcon>("PART_RightIcon");
        _label = e.NameScope.Find<TextBlock>("PART_Label");

        if (_leftIcon == null || _rightIcon == null || _label == null) return;

        _leftIcon.Value = LeftIcon;
        _rightIcon.Value = RightIcon;

        _label.IsVisible = ShowLabel;

        switch (ShowIcon)
        {
            case ShowIcons.None:
                _leftIcon!.IsVisible = false;
                _rightIcon!.IsVisible = false;
                break;
            case ShowIcons.Left:
                _leftIcon!.IsVisible = true;
                _rightIcon!.IsVisible = false;
                break;
            case ShowIcons.Right:
                _leftIcon!.IsVisible = false;
                _rightIcon!.IsVisible = true;
                break;
            case ShowIcons.Both:
                _leftIcon!.IsVisible = true;
                _rightIcon!.IsVisible = true;
                break;
            default:
                _leftIcon!.IsVisible = false;
                _rightIcon!.IsVisible = false;
                break;
        }
    }
}

