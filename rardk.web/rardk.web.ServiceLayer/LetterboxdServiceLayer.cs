using System.ServiceModel.Syndication;
using System.Xml;

namespace rardk.web.ServiceLayer
{
    public class LetterboxdServiceLayer : ILetterboxdServiceLayer
    {
        public void GetLetterboxdFeed()
        {
            var reader = XmlReader.Create("sample");
            var feed = SyndicationFeed.Load(reader);

        }
    }

    public interface ILetterboxdServiceLayer
    {
        void GetLetterboxdFeed();
    }
}