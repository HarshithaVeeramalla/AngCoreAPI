using rardk.web.Models;

namespace rardk.web.BusinessLayer;

public interface IDiscordBusinessLayer
{
    Task<DiscordAccessTokenResponse?> GetAccessToken(string code, string redirectUrl);
}