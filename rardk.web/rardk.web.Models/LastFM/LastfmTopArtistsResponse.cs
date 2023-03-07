using System.Text.Json.Serialization;

namespace rardk.web.Models.LastFM;

public class LastfmTopArtistsResponse
{
    [JsonPropertyName("topartists")]
    public TopArtists TopArtists { get; set; }
}