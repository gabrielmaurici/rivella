using System.Text;
using Newtonsoft.Json;
using Rivella.Blazor.Models.Album;
using Rivella.Blazor.Services.RivellaApi;

namespace Rivella.Blazor.Services.Album.CreateAlbum;

public class CreateAlbumService(IRivellaApiService rivellaApiService) : ICreateAlbumService
{
    public async Task<AlbumResponseModel> CreateAsync(CreateAlbumModel albumModel)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(albumModel),
            Encoding.UTF8,
            "application/json"
        );
        var request = rivellaApiService.CreateRequest("albums", HttpMethod.Post, content);
        var response = await rivellaApiService.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Erro ao criar albúm: {responseContent}");
        
        var albumResponse = JsonConvert.DeserializeObject<AlbumResponseModel>(responseContent)!;
        return albumResponse;
    }
}