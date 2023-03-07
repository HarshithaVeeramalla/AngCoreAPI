using System.Text.Json.Serialization;

namespace rardk.web.Models.LastFM;

public class LastfmTopAlbumsResponse
{
    [JsonPropertyName("topalbums")]
    public TopAlbums TopAlbums { get; set; }
}