using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RMCL.Base.Entry.Assets.Center;

public class AssetInfoEntry
{
    public class InfoRoot
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("versions")]
        public List<VersionInfo> Versions { get; set; }
    }

    public class VersionInfo
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }
        
        [JsonPropertyName("files")]
        public List<File> Files { get; set; }
    }

    public class File
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("downloadUrl")]
        public string DownloadUrl { get; set; }
    }
}