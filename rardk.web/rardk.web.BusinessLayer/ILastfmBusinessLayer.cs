using rardk.web.Models.LastFM;

namespace rardk.web.BusinessLayer;

public interface ILastfmBusinessLayer
{
    Task<IEnumerable<Album>?> GetTopAlbums(int limit = 0);
    Task<IEnumerable<Artist>?> GetTopArtists(int limit = 0);
    Task<IEnumerable<Album>?> GetWeeklyAlbumChart(int limit = 0);
    Task<IEnumerable<Artist>?> GetWeeklyArtistChart(int limit = 0);
}