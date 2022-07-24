using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW_M4P3
{
        public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
        {
            public void Configure(EntityTypeBuilder<Artist> builder)
            {
            builder
                .ToTable("Artist")
                .HasKey(p => p.Id);

            builder.HasData(
                new Artist()
                {
                    Id = 1,
                    Name = "Slipknot",
                    DateOfBirth = new DateTime(1995, 1, 1),
                    Phone = 11111111,
                    Email = "slipknot@gmail.com",
                    InstagrameUrl = "slipknot"
                },
                new Artist()
                {
                    Id = 2,
                    Name = "Rammstein",
                    DateOfBirth = new DateTime(1994, 1, 1),
                    Phone = 2222222,
                    Email = "rammstein@gmail.com",
                    InstagrameUrl = "rammstein"
                },
                new Artist()
                {
                    Id = 3,
                    Name = "Oxxxymiron",
                    DateOfBirth = new DateTime(2008, 1, 1),
                    Phone = 33333333,
                    Email = "oxxxymiron@mail.ru",
                    InstagrameUrl = "oxxxymiron"
                });
            }
        }
}
