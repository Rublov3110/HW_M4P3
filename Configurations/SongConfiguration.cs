using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW_M4P3
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song")
                .HasKey(p => p.Id);
            builder.HasData(
                new Song()
                {
                    Id = 1,
                    Title = "Sonne",
                    Duration = 300000,
                    ReleaseDate = new DateTime(2001, 1, 1),
                    GenreId = 1
                },
                new Song()
                {
                    Id = 2,
                    Title = "Ich tu dir weh",
                    Duration = 300000,
                    ReleaseDate = new DateTime(2009, 1, 1),
                    GenreId = 1
                },
                new Song()
                {
                    Id = 3,
                    Title = "Organization",
                    Duration = 300000,
                    ReleaseDate = new DateTime(2021, 1, 1),
                    GenreId = 2
                });
        }
    }
}
