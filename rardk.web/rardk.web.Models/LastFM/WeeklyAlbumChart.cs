using System.Text.Json.Serialization;

namespace rardk.web.Models.LastFM;

public class WeeklyAlbumChart
{
    [JsonPropertyName("album")]
    public List<Album> Albums { get; set; }

    [JsonPropertyName("@attr")]
    public Attr Attr { get; set; }
}