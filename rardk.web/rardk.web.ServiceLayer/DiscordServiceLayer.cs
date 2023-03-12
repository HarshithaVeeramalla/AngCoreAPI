using rardk.web.Models;

namespace rardk.web.ServiceLayer
{
    public class DiscordServiceLayer : ApiServiceLayerBase, IDiscordServiceLayer
    {
        private readonly DiscordSettings _discordSettings;

        public DiscordServiceLayer(DiscordSettings discordSettings, IHttpClientFactory httpClientFactory) : base(
            httpClientFactory, HttpClients.Discord)
        {
            _discordSettings = discordSettings;
        }

        public async Task<DiscordAccessTokenResponse?> GetAccessToken(string code, string redirectUrl)
        {
            var body = new Dictionary<string, string>
            {
                { "client_id", _discordSettings.ClientId },
                {"client_secret",_discordSettings.ClientSecret},
                {"grant_type","authorization_code"},
                {"code", code},
                {"redirect_uri",redirectUrl}
            };
            var response = await Post<DiscordAccessTokenResponse>(_discordSettings.TokenAuthEndpoint, body);
            return response;
        }
    }
}
