using rardk.web.Models;
using rardk.web.Models.LastFM;

namespace rardk.web.ServiceLayer;

public class LastfmServiceLayer : ApiServiceLayerBase, ILastfmServiceLayer
{
    private readonly LastfmSettings _lastfmSettings;

    public LastfmServiceLayer(LastfmSettings lastfmSettings, IHttpClientFactory clientFactory) : base(clientFactory, HttpClients.Lastfm)
    {
        _lastfmSettings = lastfmSettings;
    }

    public async Task<TopAlbums?> GetTopAlbums()
    {
        var topAlbumsResponse = await Get<LastfmTopAlbumsResponse>($"?api_key={_lastfmSettings.ApiKey}&format=json&user={_lastfmSettings.User}&method=user.getTopAlbums");
        return topAlbumsResponse?.TopAlbums ?? null;
    }

    public async Task<TopArtists?> GetTopArtists()
    {
        var topArtistsResponse = await Get<LastfmTopArtistsResponse>($"?api_key={_lastfmSettings.ApiKey}&format=json&user={_lastfmSettings.User}&method=user.getTopArtists");
        return topArtistsResponse?.TopArtists ?? null;
    }

    public async Task<WeeklyAlbumChart?> GetWeeklyAlbumChart()
    {
        var weeklyAlbumChart = await Get<LastfmWeeklyAlbumChartResponse>($"?api_key={_lastfmSettings.ApiKey}&format=json&user={_lastfmSettings.User}&method=user.getWeeklyAlbumChart");
        return weeklyAlbumChart?.WeeklyAlbumChart ?? null;
    }

    public async Task<WeeklyArtistChart?> GetWeeklyArtistChart()
    {
        var weeklyArtistChart = await Get<LastfmWeeklyArtistChartResponse>($"?api_key={_lastfmSettings.ApiKey}&format=json&user={_lastfmSettings.User}&method=user.getWeeklyArtistChart");
        return weeklyArtistChart?.WeeklyArtistChart ?? null;
    }
}