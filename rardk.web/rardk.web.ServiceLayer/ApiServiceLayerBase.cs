using System.Net.Http.Json;
using rardk.web.Models;

namespace rardk.web.ServiceLayer;

public class ApiServiceLayerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClients _httpClients;

    public ApiServiceLayerBase(IHttpClientFactory httpClientFactory, HttpClients httpClients)
    {
        _httpClientFactory = httpClientFactory;
        _httpClients = httpClients;
    }

    public async Task<T?> Get<T>(string url)
    {
        var client = _httpClientFactory.CreateClient(_httpClients.ToString());
        var apiResponse = await client.GetAsync(url);
        if (!apiResponse.IsSuccessStatusCode)
        {
            return default;
        }
        return await apiResponse.Content.ReadFromJsonAsync<T>();
    }
}