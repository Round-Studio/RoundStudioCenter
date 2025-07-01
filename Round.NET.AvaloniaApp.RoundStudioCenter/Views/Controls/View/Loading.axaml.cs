using Avalonia.Controls;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.View;

public partial class Loading : UserControl
{
    public string BigTitle { get; set; } = "稍安勿躁";
    public string SmallTitle { get; set; } = "正在收集宇宙电波...";
    public Loading()
    {
        InitializeComponent();

        this.Loaded += (sender, args) =>
        {
            BigTitleBox.Text = BigTitle;
            SmallTitleBox.Text = SmallTitle;
        };
    }
}