using Avalonia;
using Avalonia.Controls;
using FluentAvalonia.FluentIcons;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.Button;

public partial class IconButton : Avalonia.Controls.Button
{
    public IconButton()
    {
        InitializeComponent();
        CornerRadius = new CornerRadius(4);
    }
    public static readonly StyledProperty<FluentIconSymbol> IconProperty =
        AvaloniaProperty.Register<IconButton, FluentIconSymbol>(nameof(Icon));
        
    public static readonly StyledProperty<object> ContentProperty =
        ContentControl.ContentProperty.AddOwner<IconButton>();

    public FluentIconSymbol Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
        
    public new object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }
}