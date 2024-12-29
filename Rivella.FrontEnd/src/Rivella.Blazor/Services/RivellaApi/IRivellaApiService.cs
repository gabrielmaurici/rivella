namespace Rivella.Blazor.Services.RivellaApi;

public interface IRivellaApiService
{
    HttpRequestMessage CreateRequest(string resource, HttpMethod method, HttpContent? content = null);
    Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
}