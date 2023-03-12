using rardk.web.Models;
using rardk.web.ServiceLayer;

namespace rardk.web.BusinessLayer;

public class DiscordBusinessLayer : IDiscordBusinessLayer
{
    private readonly IDiscordServiceLayer _discordServiceLayer;

    public DiscordBusinessLayer(IDiscordServiceLayer discordServiceLayer)
    {
        _discordServiceLayer = discordServiceLayer;
    }

    public async Task<DiscordAccessTokenResponse?> GetAccessToken(string code, string redirectUrl)
    {
        return await _discordServiceLayer.GetAccessToken(code, redirectUrl);
    }
}