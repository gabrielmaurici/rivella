using System.Net.Http.Headers;
using Rivella.Blazor.Models.Photo;
using Rivella.Blazor.Services.RivellaApi;

namespace Rivella.Blazor.Services.Album.UploadPhoto;

public class UploadPhotoService(IRivellaApiService rivellaApiService) : IUploadPhotoService
{
    private const int MaxFileSize = 5 * 1024 * 1024;
    public async Task UploadAsync(UploadPhotoModel model)
    {
        using var content = new MultipartFormDataContent();
        content.Add(new StringContent(model.IdAlbum.ToString()), "IdAlbum");
        content.Add(new StringContent(model.UserName ?? string.Empty), "UserName");
        content.Add(new StringContent(model.Description ?? string.Empty), "Description");
        var stream =  model.Image.OpenReadStream(MaxFileSize);
        var fileContent = new StreamContent(stream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);
        content.Add(fileContent, "Image", model.Image.Name);
        
        var request = rivellaApiService.CreateRequest("photos/upload", HttpMethod.Post, content);
        var response = await rivellaApiService.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Erro ao enviar foto: {responseContent}");
    }
}