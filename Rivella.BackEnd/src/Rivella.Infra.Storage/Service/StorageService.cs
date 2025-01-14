using System.Runtime.InteropServices;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Rivella.Application.Interfaces;
using Rivella.Domain.Exceptions;

namespace Rivella.Infra.Storage.Service;

public class StorageService(Cloudinary storage) : IStorageService
{
    public async Task<string> Upload(string filename, Stream image)
    {
        var imageUpload = new ImageUploadParams
        {
            File = new FileDescription(filename, image),
        };
        var result = await storage.UploadAsync(imageUpload);
        if (result.Error != null)
            throw new SaveImageException();
        
        return result.SecureUrl.AbsoluteUri;
    }
}