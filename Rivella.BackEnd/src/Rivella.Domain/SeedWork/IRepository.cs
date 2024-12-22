namespace Rivella.Domain.SeedWork;

public interface IRepository<TEntity, in TId> where TEntity : Entity<TId>
{
    Task InsertAsync(TEntity entity);
    Task<TEntity?> GetAsync(TId id);
    Task Update(TEntity entity);
}