using System.Text.Json.Serialization;

namespace rardk.web.Models.LastFM;

public class LastfmWeeklyAlbumChartResponse
{
    [JsonPropertyName("weeklyalbumchart")]
    public WeeklyAlbumChart WeeklyAlbumChart { get; set; }
}