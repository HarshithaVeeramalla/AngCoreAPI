using rardk.web.Models;
using rardk.web.Models.Serializd;
using rardk.web.ServiceLayer;

namespace rardk.web.BusinessLayer
{
    public class SerializdBusinessLayer : ISerializdBusinessLayer
    {
        private readonly ISerializdServiceLayer _serializdServiceLayer;
        private readonly SerializdSettings _serializdSettings;

        public SerializdBusinessLayer(ISerializdServiceLayer serializdServiceLayer, SerializdSettings serializdSettings)
        {
            _serializdServiceLayer = serializdServiceLayer;
            _serializdSettings = serializdSettings;
        }

        public async Task<IEnumerable<Show>?> GetCurrentlyWatchingShows(int limit = 0)
        {
            var results = await _serializdServiceLayer.GetCurrentlyWatchingFeed();

            var modifiedItems = results?.Items.Select(i =>
            {
                var showUrl = $"{_serializdSettings.ShowBaseUrl}{i.ShowId}/";
                var imageUrl = $"{_serializdSettings.ShowImageBaseUrl}{i.BannerImage}";

                i.BannerImage = imageUrl;
                i.ShowUrl = showUrl;
                return i;
            });

            if (modifiedItems != null && limit > 0)
            {
                return modifiedItems.Take(limit);
            }

            return modifiedItems;
        }
    }
}
