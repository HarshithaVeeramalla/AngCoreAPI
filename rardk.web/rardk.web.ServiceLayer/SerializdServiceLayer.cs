using rardk.web.Models;
using rardk.web.Models.Serializd;

namespace rardk.web.ServiceLayer;

public class SerializdServiceLayer : ApiServiceLayerBase, ISerializdServiceLayer
{
    private readonly SerializdSettings _serializdSettings;

    public SerializdServiceLayer(SerializdSettings serializdSettings, IHttpClientFactory httpClientFactory) : base(httpClientFactory, HttpClients.Serializd)
    {
        _serializdSettings = serializdSettings;
    }

    public async Task<SerializdCurrentlyWatchingResponse?> GetCurrentlyWatchingFeed()
    {
        var serializdCurrentlyWatchingResponse = await Get<SerializdCurrentlyWatchingResponse>($"{_serializdSettings.User}/currently_watching_page/1?sort_by=date_added_desc");
        return serializdCurrentlyWatchingResponse;
    }
}