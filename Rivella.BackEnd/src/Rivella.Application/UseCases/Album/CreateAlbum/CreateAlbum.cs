using Rivella.Application.Common;
using Rivella.Application.Interfaces;
using Rivella.Application.UseCases.Album.Common;
using Rivella.Domain.Repository;

namespace Rivella.Application.UseCases.Album.CreateAlbum;

public class CreateAlbum(
    IAlbumRepository albumRepository,
    IUnitOfWork unitOfWork) : ICreateAlbum
{
    private readonly string _rivellaLink = Environment.GetEnvironmentVariable("rivella-front-end") ?? 
                                           throw new ApplicationException("rivella-front-end não encontrado"); 
    
    public async Task<AlbumOutput> CreateAsync(CreateAlbumInput input)
    {
        var code = Guid.NewGuid();
        var qrCodeLink = $"{_rivellaLink}/album/{code}";
        var qrCode = QrCodeGenerator.Generate(qrCodeLink);
        var album = new Domain.Entity.Album(
            code,
            input.Name,
            qrCode,
            input.RevelationDate
        );
        
        await albumRepository.InsertAsync(album);
        await unitOfWork.CommitAsync();
        
        return AlbumOutput.FromAlbum(album);
    }
}