using rardk.web.Models.LastFM;

namespace rardk.web.ServiceLayer;

public interface ILastfmServiceLayer
{
    Task<TopAlbums?> GetTopAlbums();
    Task<TopArtists?> GetTopArtists();
    Task<WeeklyAlbumChart?> GetWeeklyAlbumChart();
    Task<WeeklyArtistChart?> GetWeeklyArtistChart();
}