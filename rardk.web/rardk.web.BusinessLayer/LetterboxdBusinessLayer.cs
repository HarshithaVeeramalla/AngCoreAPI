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

        public void GetLetterboxdFeed()
        {
            _letterboxdServiceLayer.GetLetterboxdFeed();
        }
    }

    public interface ILetterboxdBusinessLayer
    {
        void GetLetterboxdFeed();
    }
}
