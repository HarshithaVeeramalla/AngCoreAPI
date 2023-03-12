using rardk.web.Models;

namespace rardk.web.ServiceLayer;

public interface IDiscordServiceLayer
{
    Task<DiscordAccessTokenResponse?> GetAccessToken(string code, string redirectUrl);
}