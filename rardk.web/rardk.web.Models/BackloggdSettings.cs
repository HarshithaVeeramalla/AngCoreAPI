namespace rardk.web.Models;

public class BackloggdSettings
{
    public string BackloggdProfileUrl { get; set; }
    public BackloggdSettings(string backloggdProfileUrl)
    {
        BackloggdProfileUrl = backloggdProfileUrl;
    }
}