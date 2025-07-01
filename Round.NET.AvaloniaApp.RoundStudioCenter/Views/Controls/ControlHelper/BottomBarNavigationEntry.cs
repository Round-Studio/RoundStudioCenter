using Avalonia.Controls;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.ControlHelper;

public class BottomBarNavigationEntry
{
    public Control Title { get; set; }
    public string Tag { get; set; }
    public UserControl Page { get; set; }
    public bool IsDefault { get; set; } = false;
    public bool IsNoButton { get; set; } = false;
}

public class BottomBarNavigationItemEntry : BottomBarNavigationEntry
{
    public Avalonia.Controls.Button NavItem { get; set; }
    public bool IsThis { get; set; } = false;
}