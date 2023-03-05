using rardk.web.Models;
using rardk.web.ServiceLayer;

namespace rardk.web.BusinessLayer
{
    public class LetterboxdBusinessLayer : ILetterboxdBusinessLayer
    {
        private readonly ILetterboxdServiceLayer _letterboxdServiceLayer;

        public LetterboxdBusinessLayer(ILetterboxdServiceLayer letterboxdServiceLayer)
        {
            _letterboxdServiceLayer = letterboxdServiceLayer;
        }

        public IEnumerable<LetterboxdItem> GetLetterboxdFeed(int limit = 0)
        {
            return _letterboxdServiceLayer.GetLetterboxdFeed(limit);
        }
    }
}
