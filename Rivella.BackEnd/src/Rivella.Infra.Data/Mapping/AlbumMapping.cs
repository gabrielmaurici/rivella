using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rivella.Domain.Entity;

namespace Rivella.Infra.Data.Mapping;

public class AlbumMapping : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.ToTable(nameof(Album));
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Code)
            .HasColumnName("Code")
            .HasColumnType("uniqueidentifier");
        
        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar(100)");
        
        builder.Property(x => x.RevelationDate)
            .HasColumnName("RevelationDate")
            .HasColumnType("datetime");
    }
}