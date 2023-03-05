using rardk.web.Models;
using rardk.web.ServiceLayer;

namespace rardk.web.BusinessLayer;

public interface ILetterboxdBusinessLayer
{
    IEnumerable<LetterboxdItem> GetLetterboxdFeed(int limit = 0);
}