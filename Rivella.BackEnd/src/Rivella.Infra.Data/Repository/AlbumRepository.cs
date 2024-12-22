using Microsoft.EntityFrameworkCore;
using Rivella.Domain.Entity;
using Rivella.Domain.Repository;
using Rivella.Infra.Data.Context;

namespace Rivella.Infra.Data.Repository;

public class AlbumRepository(RivellaContext context) : IAlbumRepository
{
    public async Task InsertAsync(Album model)
    {
        await context.Albums.AddAsync(model);
    }

    public async Task<Album?> GetAsync(int id)
    {
        return await context.Albums.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task Update(Album model)
    {
        context.Albums.Update(model);
        return Task.CompletedTask;
    }
}