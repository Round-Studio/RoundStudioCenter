namespace Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Models.AssetsCenter;

public class RouterIndex
{
    public const string RootUrl = "https://rmcl-assetsstore.pages.dev";
    
    public const string PluginIndexUrl = "/api/plugin.json";
    public const string SkinIndexUrl = "/api/skin.json";
    public const string CodeIndexUrl = "/api/code.json";

    public const string PluginInfoUrl = "/api/plugin/:name/index.json";
    public const string SkinInfoUrl = "/api/skin/:name/index.json";
    public const string CodeInfoUrl = "/api/code/:name/index.json";

    public const string AssetNamePlaceholding = ":name";
}