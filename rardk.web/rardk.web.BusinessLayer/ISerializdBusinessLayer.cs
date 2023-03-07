using rardk.web.Models.Serializd;

namespace rardk.web.BusinessLayer;

public interface ISerializdBusinessLayer
{
    Task<IEnumerable<Show>?> GetCurrentlyWatchingShows(int limit = 0);
}