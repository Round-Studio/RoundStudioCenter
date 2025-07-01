using Avalonia.Controls;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.Item;

public partial class LabelBox : UserControl
{
    private string _text;
    private TextBlock _textBlock;

    public string Text
    {
        get
        {
            return _text;
        }
        set
        {
            _text = value;
            _textBlock.Text = value;
        }
    }

    public LabelBox()
    {
        InitializeComponent();
        _textBlock = ItTextBox;
    }
}