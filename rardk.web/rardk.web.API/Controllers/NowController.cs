using Microsoft.AspNetCore.Mvc;
using rardk.web.BusinessLayer;

namespace rardk.web.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NowController : ControllerBase
{
    private readonly ILetterboxdBusinessLayer _letterboxdBusinessLayer;

    public NowController(ILetterboxdBusinessLayer letterboxdBusinessLayer)
    {
        _letterboxdBusinessLayer = letterboxdBusinessLayer;
    }

    [HttpGet("letterboxd", Name = "letterboxd")]
    public ActionResult GetLetterboxdFeed(int limit = 0)
    {
        var letterboxdFeed = _letterboxdBusinessLayer.GetLetterboxdFeed(limit);
        return Ok(letterboxdFeed);
    }
}