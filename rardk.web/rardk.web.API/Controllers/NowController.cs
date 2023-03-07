using Microsoft.AspNetCore.Mvc;
using rardk.web.BusinessLayer;

namespace rardk.web.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NowController : ControllerBase
{
    private readonly ILetterboxdBusinessLayer _letterboxdBusinessLayer;
    private readonly IBackloggdBusinessLayer _backloggdBusinessLayer;
    private readonly ILastfmBusinessLayer _lastfmBusinessLayer;
    private readonly ISerializdBusinessLayer _serializdBusinessLayer;

    public NowController(ILetterboxdBusinessLayer letterboxdBusinessLayer,
        IBackloggdBusinessLayer backloggdBusinessLayer,
        ILastfmBusinessLayer lastfmBusinessLayer,
        ISerializdBusinessLayer serializdBusinessLayer)
    {
        _letterboxdBusinessLayer = letterboxdBusinessLayer;
        _backloggdBusinessLayer = backloggdBusinessLayer;
        _lastfmBusinessLayer = lastfmBusinessLayer;
        _serializdBusinessLayer = serializdBusinessLayer;
    }

    [HttpGet("letterboxd", Name = "letterboxd")]
    public ActionResult GetLetterboxdFeed(int limit = 0)
    {
        var letterboxdFeed = _letterboxdBusinessLayer.GetLetterboxdFeed(limit);
        return Ok(letterboxdFeed);
    }

    [HttpGet("backloggd", Name = "backloggd")]
    public ActionResult GetBackloggdFeed(int limit = 0)
    {
        var backloggdFeed = _backloggdBusinessLayer.GetBackloggdFeed(limit);
        return Ok(backloggdFeed);
    }

    [HttpGet("lastfm/topalbums", Name = "lastfm/topalbums")]
    public async Task<ActionResult> GetLastfmTopAlbums(int limit = 0)
    {
        var topAlbums = await _lastfmBusinessLayer.GetTopAlbums(limit);
        return Ok(topAlbums);
    }

    [HttpGet("lastfm/topartists", Name = "lastfm/topartists")]
    public async Task<ActionResult> GetLastfmTopArtists(int limit = 0)
    {
        var topArtists = await _lastfmBusinessLayer.GetTopArtists(limit);
        return Ok(topArtists);
    }

    [HttpGet("lastfm/weeklyalbumchart", Name = "lastfm/weeklyalbumchart")]
    public async Task<ActionResult> GetLastfmWeeklyAlbumChart(int limit = 0)
    {
        var weeklyAlbumChart = await _lastfmBusinessLayer.GetWeeklyAlbumChart(limit);
        return Ok(weeklyAlbumChart);
    }

    [HttpGet("lastfm/weeklyartistchart", Name = "lastfm/weeklyartistchart")]
    public async Task<ActionResult> GetLastfmWeeklyArtistChart(int limit = 0)
    {
        var weeklyArtistChart = await _lastfmBusinessLayer.GetWeeklyArtistChart(limit);
        return Ok(weeklyArtistChart);
    }

    [HttpGet("serializd/currentlywatching", Name = "serializd/currentlywatching")]
    public async Task<ActionResult> GetSerializdCurrentlyWatchingShows(int limit = 0)
    {
        var shows = await _serializdBusinessLayer.GetCurrentlyWatchingShows(limit);
        return Ok(shows);
    }
}