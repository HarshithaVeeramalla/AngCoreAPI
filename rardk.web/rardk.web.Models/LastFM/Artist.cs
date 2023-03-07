using System.Text.Json.Serialization;

namespace rardk.web.Models.LastFM;

public class Artist
{
    [JsonPropertyName("streamable")]
    public string Streamable { get; set; }

    [JsonPropertyName("image")]
    public List<Image> Image { get; set; }

    [JsonPropertyName("mbid")]
    public string Mbid { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("playcount")]
    public string Playcount { get; set; }

    [JsonPropertyName("@attr")]
    public Attr Attr { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}