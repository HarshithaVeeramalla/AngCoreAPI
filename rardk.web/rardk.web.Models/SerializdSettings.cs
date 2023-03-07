namespace rardk.web.Models
{
    public class SerializdSettings
    {
        public string BaseUrl { get; set; }
        public string User { get; set; }
        public string ShowBaseUrl { get; set; }
        public string ShowImageBaseUrl { get; set; }

        public SerializdSettings(string baseUrl, string showBaseUrl, string showImageBaseUrl, string user)
        {
            BaseUrl = baseUrl;
            ShowBaseUrl = showBaseUrl;
            ShowImageBaseUrl = showImageBaseUrl;
            User = user;
        }
    }
}