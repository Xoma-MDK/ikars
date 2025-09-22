using System.Text;
using System.Text.Json;

namespace Payment.Web.Infrastructure.Http;

internal abstract class BaseHttpClient
{
    private readonly HttpClient _httpClient;

    protected BaseHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TResponse> GetAsync<TResponse>(string url)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResponse>(responseBody) ?? throw new NullReferenceException();
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request)
    {
        var jsonContent = JsonSerializer.Serialize(request);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync(url, content);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResponse>(responseBody) ?? throw new NullReferenceException();
    }
}