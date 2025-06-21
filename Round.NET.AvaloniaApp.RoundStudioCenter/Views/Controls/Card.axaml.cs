using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls;

public partial class Card : UserControl
{
    public Card()
    {
        InitializeComponent();
    }
    public static readonly StyledProperty<string> CardTitleProperty =
        AvaloniaProperty.Register<Card, string>(nameof(CardTitle));

    public static readonly StyledProperty<string> CardDescriptionProperty =
        AvaloniaProperty.Register<Card, string>(nameof(CardDescription));

    public string CardTitle
    {
        get => GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }

    public string CardDescription
    {
        get => GetValue(CardDescriptionProperty);
        set => SetValue(CardDescriptionProperty, value);
    }
}