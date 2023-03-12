using Microsoft.AspNetCore.Mvc;
using rardk.web.BusinessLayer;

namespace rardk.web.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscordController : ControllerBase
{
    private readonly IDiscordBusinessLayer _discordBusinessLayer;

    public DiscordController(IDiscordBusinessLayer discordBusinessLayer)
    {
        _discordBusinessLayer = discordBusinessLayer;
    }

    [HttpGet("access-token", Name = "access-token")]
    public async Task<ActionResult> GetDiscordAccessToken(string code, string redirectUrl)
    {
        var accessToken = await _discordBusinessLayer.GetAccessToken(code, redirectUrl);
        if (accessToken == null)
        {
            return NotFound();
        }
        return Ok(accessToken);
    }
}