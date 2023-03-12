namespace rardk.web.Models
{
    public class DiscordSettings
    {
        public DiscordSettings(string clientId, string clientSecret, string tokenAuthEndpoint)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            TokenAuthEndpoint = tokenAuthEndpoint;
        }

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TokenAuthEndpoint { get; set; }
    }
}
