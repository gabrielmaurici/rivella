namespace Rivella.Application.Interfaces;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task RollbackAsync();
}