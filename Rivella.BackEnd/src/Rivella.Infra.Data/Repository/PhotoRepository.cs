using Microsoft.EntityFrameworkCore;
using Rivella.Domain.Entity;
using Rivella.Domain.Repository;
using Rivella.Infra.Data.Context;

namespace Rivella.Infra.Data.Repository;

public class PhotoRepository(RivellaContext context) : IPhotoRepository
{
    public async Task InsertAsync(Photo entity)
    {
        await context.Photos.AddAsync(entity);
    }

    public async Task<Photo?> GetAsync(int id)
    {
        return await context.Photos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task Update(Photo entity)
    {
        context.Photos.Update(entity);
        return Task.CompletedTask;
    }
}