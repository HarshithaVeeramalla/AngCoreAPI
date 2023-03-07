namespace rardk.web.Models;

public class LastfmSettings
{
    public LastfmSettings(string baseUrl, string apiKey)
    {
        BaseUrl = baseUrl;
        ApiKey = apiKey;
    }

    public string BaseUrl { get; set; }
    public string ApiKey { get; set; }
    public string User { get; set; }
}