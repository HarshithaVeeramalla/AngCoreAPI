using System.Net.Http.Json;
using rardk.web.Models;
using rardk.web.Models.LastFM;

namespace rardk.web.ServiceLayer;

public class LastfmServiceLayer : ILastfmServiceLayer
{
    private readonly LastfmSettings _lastfmSettings;
    private readonly IHttpClientFactory _httpClientFactory;

    public LastfmServiceLayer(LastfmSettings lastfmSettings, IHttpClientFactory httpClientFactory)
    {
        _lastfmSettings = lastfmSettings;
        _httpClientFactory = httpClientFactory;
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

    private async Task<T?> Get<T>(string url)
    {
        var client = _httpClientFactory.CreateClient(HttpClients.Lastfm.ToString());
        var apiResponse = await client.GetAsync(url);
        if (!apiResponse.IsSuccessStatusCode)
        {
            return default;
        }
        return await apiResponse.Content.ReadFromJsonAsync<T>();
    }
}