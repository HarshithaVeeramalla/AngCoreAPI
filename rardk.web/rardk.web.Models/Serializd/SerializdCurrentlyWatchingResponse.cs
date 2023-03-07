using System.Text.Json.Serialization;

namespace rardk.web.Models.Serializd
{
    public class SerializdCurrentlyWatchingResponse
    {
        [JsonPropertyName("items")]
        public List<Show> Items { get; set; }

        [JsonPropertyName("totalItems")]
        public int TotalItems { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }
    }
}
