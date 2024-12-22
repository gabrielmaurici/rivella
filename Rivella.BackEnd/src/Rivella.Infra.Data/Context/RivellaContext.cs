using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Rivella.Domain.Entity;

namespace Rivella.Infra.Data.Context;

public class RivellaContext : DbContext
{
    public RivellaContext(DbContextOptions<RivellaContext> context) : base(context)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public DbSet<Album> Albums { get; private set; }
    public DbSet<Photo> Photos { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}