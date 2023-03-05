using rardk.web.Models;

namespace rardk.web.ServiceLayer;

public interface IBackloggdServiceLayer
{
    IEnumerable<BackloggdItem> GetBackloggdFeed(int limit = 0);
}