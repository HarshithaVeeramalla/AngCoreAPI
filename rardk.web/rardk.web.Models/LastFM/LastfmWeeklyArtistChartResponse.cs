using System.Text.Json.Serialization;

namespace rardk.web.Models.LastFM;

public class LastfmWeeklyArtistChartResponse
{
    [JsonPropertyName("weeklyartistchart")]
    public WeeklyArtistChart WeeklyArtistChart { get; set; }
}