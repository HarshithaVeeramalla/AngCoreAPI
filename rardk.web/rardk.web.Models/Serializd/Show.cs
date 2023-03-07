using System.Text.Json.Serialization;

namespace rardk.web.Models.Serializd;

public class Show
{
    [JsonPropertyName("showId")]
    public int ShowId { get; set; }

    [JsonPropertyName("dateAdded")]
    public DateTime DateAdded { get; set; }

    [JsonPropertyName("showName")]
    public string ShowName { get; set; }

    [JsonPropertyName("bannerImage")]
    public string BannerImage { get; set; }

    [JsonPropertyName("showUrl")]
    public string? ShowUrl { get; set; }
}