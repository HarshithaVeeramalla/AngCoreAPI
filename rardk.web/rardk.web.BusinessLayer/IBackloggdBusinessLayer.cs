using rardk.web.Models;

namespace rardk.web.BusinessLayer;

public interface IBackloggdBusinessLayer
{
    IEnumerable<BackloggdItem> GetBackloggdFeed(int limit = 0);
}