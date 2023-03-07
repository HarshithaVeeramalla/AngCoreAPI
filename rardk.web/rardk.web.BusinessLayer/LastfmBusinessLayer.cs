using rardk.web.Models.LastFM;
using rardk.web.ServiceLayer;

namespace rardk.web.BusinessLayer
{
    public class LastfmBusinessLayer : ILastfmBusinessLayer
    {
        private readonly ILastfmServiceLayer _lastfmServiceLayer;
        public LastfmBusinessLayer(ILastfmServiceLayer lastfmServiceLayer)
        {
            _lastfmServiceLayer = lastfmServiceLayer;
        }

        public async Task<IEnumerable<Album>?> GetTopAlbums(int limit = 0)
        {
            var results = await _lastfmServiceLayer.GetTopAlbums();
            if (results != null && limit > 0)
            {
                return results.Albums.Take(limit);
            }

            return results?.Albums;
        }

        public async Task<IEnumerable<Artist>?> GetTopArtists(int limit = 0)
        {
            var results = await _lastfmServiceLayer.GetTopArtists();
            if (results != null && limit > 0)
            {
                return results.Artists.Take(limit);

            }
            return results?.Artists;
        }

        public async Task<IEnumerable<Album>?> GetWeeklyAlbumChart(int limit = 0)
        {
            var results = await _lastfmServiceLayer.GetWeeklyAlbumChart();
            if (results != null && limit > 0)
            {
                return results.Albums.Take(limit);
            }

            return results?.Albums;
        }

        public async Task<IEnumerable<Artist>?> GetWeeklyArtistChart(int limit = 0)
        {
            var results = await _lastfmServiceLayer.GetWeeklyArtistChart();
            if (results != null && limit > 0)
            {
                return results.Artists.Take(limit);
            }

            return results?.Artists;
        }
    }
}
