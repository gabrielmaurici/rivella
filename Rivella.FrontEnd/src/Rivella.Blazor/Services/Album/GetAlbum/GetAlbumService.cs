using Newtonsoft.Json;
using Rivella.Blazor.Models.Album;
using Rivella.Blazor.Services.RivellaApi;

namespace Rivella.Blazor.Services.Album.GetAlbum;

public class GetAlbumService(IRivellaApiService rivellaApiService) : IGetAlbumService
{
    public async Task<AlbumResponseModel> GetAsync(Guid code)
    {
        var resource = $"albums/{code}";
        var request = rivellaApiService.CreateRequest(resource, HttpMethod.Get);
        var response = await rivellaApiService.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Erro ao buscar albúm: {responseContent}");
        
        var albumResponse = JsonConvert.DeserializeObject<AlbumResponseModel>(responseContent)!;
        return albumResponse;
    }
}