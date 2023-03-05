using Microsoft.AspNetCore.Mvc;
using rardk.web.BusinessLayer;

namespace rardk.web.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NowController : ControllerBase
{
    private readonly ILetterboxdBusinessLayer _letterboxdBusinessLayer;
    private readonly IBackloggdBusinessLayer _backloggdBusinessLayer;

    public NowController(ILetterboxdBusinessLayer letterboxdBusinessLayer, IBackloggdBusinessLayer backloggdBusinessLayer)
    {
        _letterboxdBusinessLayer = letterboxdBusinessLayer;
        _backloggdBusinessLayer = backloggdBusinessLayer;
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
}