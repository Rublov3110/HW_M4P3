using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW_M4P3
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre")
                .HasKey(p => p.Id);
            builder.HasData(
                new Genre()
                {
                    Id = 1,
                    Title = "Hard rock"
                },
                new Genre()
                {
                    Id = 2,
                    Title = "Pop"
                },
                new Genre()
                {
                    Id = 3,
                    Title = "Country"
                });
        }
    }
}
