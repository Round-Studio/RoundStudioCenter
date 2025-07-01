using System.Collections.Generic;
using System.Text.Json.Serialization;
using Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Enums;

namespace RMCL.Base.Entry.Assets.Center;

public class AssetsIndexItemEntry
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("versions")]
    public List<string> Versions { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    public AssetsTypeEnum Type { get; set; }
}