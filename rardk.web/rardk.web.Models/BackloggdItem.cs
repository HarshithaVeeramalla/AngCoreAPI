namespace rardk.web.Models;

public class BackloggdItem
{
    public string Title { get; set; }
    public string Summary { get; set; }
    public string? ImageUrl { get; set; }
    public string? Url { get; set; }
    public decimal? Rating { get; set; }
}