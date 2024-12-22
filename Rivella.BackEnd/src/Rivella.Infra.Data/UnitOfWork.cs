using Rivella.Application.Interfaces;
using Rivella.Infra.Data.Context;

namespace Rivella.Infra.Data;

public class UnitOfWork(RivellaContext context) : IUnitOfWork
{
    public async Task CommitAsync()
        => await context.SaveChangesAsync();
    

    public Task RollbackAsync()
        => Task.CompletedTask;
}