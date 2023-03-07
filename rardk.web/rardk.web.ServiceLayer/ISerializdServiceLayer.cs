using rardk.web.Models.Serializd;

namespace rardk.web.ServiceLayer;

public interface ISerializdServiceLayer
{
    Task<SerializdCurrentlyWatchingResponse?> GetCurrentlyWatchingFeed();
}