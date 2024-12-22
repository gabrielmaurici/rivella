using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rivella.Domain.Entity;

namespace Rivella.Infra.Data.Mapping;

public class AlbumMapping : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.ToTable("albums", "public");
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("serial");
        
        builder.Property(x => x.Code)
            .HasColumnName("code")
            .HasColumnType("uuid");
        
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(100)");
        
        builder.Property(x => x.RevelationDate)
            .HasColumnName("revelation_date")
            .HasColumnType("timestamp");
        
        builder.Property(x => x.DateCreated)
            .HasColumnName("date_created")
            .HasColumnType("timestamp");
    }
}