﻿using System.Text.Json.Serialization;

namespace rardk.web.Models.LastFM;

public class TopArtists
{
    [JsonPropertyName("artist")]
    public List<Artist> Artists { get; set; }

    [JsonPropertyName("@attr")]
    public Attr Attr { get; set; }
}