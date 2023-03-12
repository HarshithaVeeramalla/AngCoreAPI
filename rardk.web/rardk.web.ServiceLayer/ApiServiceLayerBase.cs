using System.Net.Http.Json;
using System.Text.Json;
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

    public async Task<T?> Post<T>(string url, Dictionary<string, string> formBody)
    {
        using var client = new HttpClient();

        var res = await client.PostAsync(url, new FormUrlEncodedContent(formBody));
        if (!res.IsSuccessStatusCode)
        {
            return default;
        }
        var responseString = await res.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<T>(responseString);
        return result;
    }
}