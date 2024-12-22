using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rivella.Domain.Entity;

namespace Rivella.Infra.Data.Mapping;

public class PhotoMapping : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.ToTable(nameof(Photo));
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Url)
            .HasColumnName("Url")
            .HasColumnType("varchar(200)");
        
        builder.Property(p => p.UserName)
            .HasColumnName("UserName")
            .HasColumnType("varchar(100)");
        
        builder.Property(p => p.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar(200)");
        
        builder.Property(p => p.DateUpload)
            .HasColumnName("DateUpload")
            .HasColumnType("datetime");

        builder.HasOne<Album>()
            .WithMany()
            .HasForeignKey(x => x.IdAlbum);
    }
}