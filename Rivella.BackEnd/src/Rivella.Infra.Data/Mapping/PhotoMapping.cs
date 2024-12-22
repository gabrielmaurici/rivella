using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rivella.Domain.Entity;

namespace Rivella.Infra.Data.Mapping;

public class PhotoMapping : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.ToTable("photos", "public");

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("serial");
        
        builder.Property(p => p.AlbumId)
            .HasColumnName("album_id")
            .HasColumnType("integer");
        
        builder.Property(p => p.Url)
            .HasColumnName("url")
            .HasColumnType("varchar(200)");
        
        builder.Property(p => p.UserName)
            .HasColumnName("user_name")
            .HasColumnType("varchar(100)");
        
        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasColumnType("varchar(200)");
        
        builder.Property(p => p.DateUpload)
            .HasColumnName("date_upload")
            .HasColumnType("timestamp");
        
        builder.HasOne<Album>(x => x.Album)
            .WithMany(x => x.Photos)
            .HasForeignKey(x => x.AlbumId);
    }
}