using rardk.web.Models;
using rardk.web.ServiceLayer;

namespace rardk.web.BusinessLayer
{
    public class BackloggdBusinessLayer : IBackloggdBusinessLayer
    {
        private readonly IBackloggdServiceLayer _backloggdServiceLayer;

        public BackloggdBusinessLayer(IBackloggdServiceLayer backloggdServiceLayer)
        {
            _backloggdServiceLayer = backloggdServiceLayer;
        }

        public IEnumerable<BackloggdItem> GetBackloggdFeed(int limit = 0)
        {
            return _backloggdServiceLayer.GetBackloggdFeed(limit);
        }
    }
}
