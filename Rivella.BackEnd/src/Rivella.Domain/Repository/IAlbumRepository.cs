using Rivella.Domain.Entity;
using Rivella.Domain.SeedWork;

namespace Rivella.Domain.Repository;

public interface IAlbumRepository : IRepository<Album, int>
{
    Task<Album?> GetAsync(Guid code);
}