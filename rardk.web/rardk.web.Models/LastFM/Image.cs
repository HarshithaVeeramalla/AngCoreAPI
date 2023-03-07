using System.Text.Json.Serialization;

namespace rardk.web.Models.LastFM;

public class Image
{
    [JsonPropertyName("size")]
    public string Size { get; set; }

    [JsonPropertyName("#text")]
    public string Text { get; set; }
}