namespace rardk.web.Models
{
    public class LetterboxdSettings
    {
        public string LetterboxdProfileUrl { get; set; }
        public LetterboxdSettings(string letterboxdProfileUrl)
        {
            LetterboxdProfileUrl = letterboxdProfileUrl;
        }
    }
}