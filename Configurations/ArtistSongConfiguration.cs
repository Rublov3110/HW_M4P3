using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW_M4P3
{
    public class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.ToTable("ArtistSong")
                .HasKey(p => p.Id);
            builder.HasData(
                new ArtistSong()
                {
                    Id = 1,
                    ArtistId = 2,
                    SongId = 1
                },
                new ArtistSong()
                {
                    Id = 2,
                    ArtistId = 2,
                    SongId = 2
                },
                new ArtistSong()
                {
                    Id = 3,
                    ArtistId = 3,
                    SongId = 1
                });
        }
    }
}
