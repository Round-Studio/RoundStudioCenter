using Avalonia;
using Avalonia.Controls;
using FluentAvalonia.FluentIcons;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.Button;

public partial class AccentIconButton : Avalonia.Controls.Button
{
    public AccentIconButton()
    {
        InitializeComponent();
        CornerRadius = new CornerRadius(4);
    }
    public static readonly StyledProperty<FluentIconSymbol> IconProperty =
        AvaloniaProperty.Register<AccentIconButton, FluentIconSymbol>(nameof(Icon));
        
    public static readonly StyledProperty<object> ContentProperty =
        ContentControl.ContentProperty.AddOwner<AccentIconButton>();

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