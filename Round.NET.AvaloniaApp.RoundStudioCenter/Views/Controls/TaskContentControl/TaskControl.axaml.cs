using Avalonia.Controls;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.TaskContentControl;

public partial class TaskControl : UserControl
{
    public string TaskName { get; set; }
    public Control BoxContent { get; set; }
    public string UUID { get; set; }
    public TaskControl()
    {
        InitializeComponent();
    }

    public void RunTask()
    {
        TaskNameBox.Text = TaskName;
        ContentBox.Content = BoxContent;
        BoxContent.Tag = UUID;
    }
}