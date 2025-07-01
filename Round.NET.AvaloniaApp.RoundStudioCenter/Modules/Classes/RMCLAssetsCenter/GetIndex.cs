using System.Collections.Generic;
using System.Threading.Tasks;
using RMCL.Base.Entry.Assets.Center;
using NetworkService.SingleInstanceDetector;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Classes.RMCLAssetsCenter;

public class GetIndex
{
    public static async Task<List<AssetsIndexItemEntry>> GetPluginIndex()
    {
        string apiUrl = $"{RouterIndex.RootUrl}{RouterIndex.PluginIndexUrl}";
        return await HttpApiClient.GetAsync<List<AssetsIndexItemEntry>>(apiUrl);
    }

    public static async Task<List<AssetsIndexItemEntry>> GetSkinIndex()
    {
        string apiUrl = $"{RouterIndex.RootUrl}{RouterIndex.SkinIndexUrl}";
        return await HttpApiClient.GetAsync<List<AssetsIndexItemEntry>>(apiUrl);
    }
    
    public static async Task<List<AssetsIndexItemEntry>> GetCodeIndex()
    {
        string apiUrl = $"{RouterIndex.RootUrl}{RouterIndex.CodeIndexUrl}";
        return await HttpApiClient.GetAsync<List<AssetsIndexItemEntry>>(apiUrl);
    }
}