using System.ServiceModel.Syndication;
using System.Xml;
using rardk.web.Models;

namespace rardk.web.ServiceLayer;

public class BackloggdServiceLayer : IBackloggdServiceLayer
{
    private readonly BackloggdSettings _backloggdSettings;
    private const string BackloggdExtensionNamespace = "https://www.backloggd.com/";

    public BackloggdServiceLayer(BackloggdSettings backloggdSettings)
    {
        _backloggdSettings = backloggdSettings;
    }

    public IEnumerable<BackloggdItem> GetBackloggdFeed(int limit = 0)
    {
        var reader = XmlReader.Create(_backloggdSettings.BackloggdProfileUrl);
        var feed = SyndicationFeed.Load(reader);
        var feedItems = limit > 0 ? feed.Items.Take(limit) : feed.Items;
        var items = feedItems.Select(i =>
        {
            //var imageUrl = i.ReadElementExtension("url","");
            var imageUrl = i.ElementExtensions
                .Where(e => e.OuterName == "image" && e.OuterNamespace == "")
                .Select(e => e.GetObject<XmlElement>().SelectSingleNode("url")?.InnerText)
                .FirstOrDefault();
            var userRating = i.ReadElementExtension("user_rating", BackloggdExtensionNamespace);
            var link = i.Links.FirstOrDefault()?.Uri.AbsoluteUri;

            return new BackloggdItem
            {
                Title = i.Title.Text,
                Summary = i.Summary.Text,
                Url = link,
                Rating = userRating != null ? Convert.ToDecimal(userRating) : null,
                ImageUrl = imageUrl,

            };
        });
        return items;
    }
}