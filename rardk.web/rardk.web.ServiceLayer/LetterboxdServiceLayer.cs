using System.ServiceModel.Syndication;
using System.Xml;
using rardk.web.Models;

namespace rardk.web.ServiceLayer
{
    public class LetterboxdServiceLayer : ILetterboxdServiceLayer
    {
        private const string LetterboxdExtensionNamespace = "https://letterboxd.com";
        private readonly LetterboxdSettings _letterboxdSettings;

        public LetterboxdServiceLayer(LetterboxdSettings letterboxdSettings)
        {
            _letterboxdSettings = letterboxdSettings;
        }

        public IEnumerable<LetterboxdItem> GetLetterboxdFeed(int limit = 0)
        {
            var reader = XmlReader.Create(_letterboxdSettings.LetterboxdProfileUrl);
            var feed = SyndicationFeed.Load(reader);
            var feedItems = limit > 0 ? feed.Items.Take(limit) : feed.Items;
            var items = feedItems.Select(i =>
            {
                var isRewatch = i.ReadElementExtension("rewatch", LetterboxdExtensionNamespace)?.ParseYesOrNo();
                var watchedDate = i.ReadElementExtension("watchedDate", LetterboxdExtensionNamespace);
                var memberRating = i.ReadElementExtension("memberRating", LetterboxdExtensionNamespace);
                var link = i.Links.FirstOrDefault()?.Uri.AbsoluteUri;

                var imageFromDescription = GetImageFromDescription(i.Summary.Text);

                return new LetterboxdItem
                {
                    Title = i.Title.Text,
                    Summary = i.Summary.Text,
                    Url = link,
                    IsRewatch = isRewatch ?? false,
                    WatchedDate = watchedDate,
                    Rating = memberRating,
                    ImageUrl = imageFromDescription,

                };
            });
            return items;
        }

        private static string? GetImageFromDescription(string summaryText)
        {
            const string httpValue = "http";
            const string fileTypeValue = "jpg";

            var httpIndex = summaryText.IndexOf(httpValue, StringComparison.OrdinalIgnoreCase);
            var jpgIndex = summaryText.IndexOf(fileTypeValue, StringComparison.OrdinalIgnoreCase);
            if (httpIndex == -1 || jpgIndex == -1)
            {
                return null;
            }
            var imageFromDescription = summaryText.Substring(httpIndex, jpgIndex - httpIndex + fileTypeValue.Length);
            return imageFromDescription;

        }
    }
}