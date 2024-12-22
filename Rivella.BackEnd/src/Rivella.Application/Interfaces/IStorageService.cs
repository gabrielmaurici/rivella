using Rivella.Application.UseCases.Photo.UploadPhoto;

namespace Rivella.Application.Interfaces;

public interface IStorageService
{
    Task<string> Upload(string filename, Stream image);   
}