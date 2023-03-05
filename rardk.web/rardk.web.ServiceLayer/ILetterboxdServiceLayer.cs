using rardk.web.Models;

namespace rardk.web.ServiceLayer;

public interface ILetterboxdServiceLayer
{
    IEnumerable<LetterboxdItem> GetLetterboxdFeed(int limit = 0);
}