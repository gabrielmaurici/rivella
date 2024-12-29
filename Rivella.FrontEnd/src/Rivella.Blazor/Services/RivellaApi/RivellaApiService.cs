using System.Text;
using Newtonsoft.Json;

namespace Rivella.Blazor.Services.RivellaApi;

public class RivellaApiService(IHttpClientFactory httpClientFactory) : IRivellaApiService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("rivella-api");
    
    public HttpRequestMessage CreateRequest(string resource, HttpMethod method, HttpContent? content = null)
    {
        var requestUri = _httpClient.BaseAddress + resource;
        return new HttpRequestMessage(method, requestUri)
        {
            Content = content
        };
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        => await _httpClient.SendAsync(request);
}