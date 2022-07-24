using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HW_M4P3
{
    public sealed class Program
    {
        internal static void Main(string[] args)
        {
            using (ApplicationContext context = new ApplicationContextFactory().CreateDbContext(Array.Empty<string>()))
            {
                context.Database.Migrate();

                var songsWithGenre = context.Songs
                    .Where(s => s.GenreId != null)
                    .Join(
                        context.Genres,
                        s => s.GenreId,
                        g => g.Id,
                        (s, g) => new
                        {
                            s.Id,
                            SongTitle = s.Title,
                            GenreTitle = g.Title
                        })
                    .Join(
                        context.ArtistSongs,
                        s => s.Id,
                        ars => ars.SongId,
                        (s, ars) => new
                        {
                            s.SongTitle,
                            s.GenreTitle,
                            ars.ArtistId
                        })
                    .Join(
                        context.Artists,
                        ars => ars.ArtistId,
                        art => art.Id,
                        (ars, art) => new
                        {
                            ars.SongTitle,
                            ars.GenreTitle,
                            ArtistName = art.Name,
                            ArtistDOB = art.DateOfBirth
                        })
                    .Where(i => EF.Functions.DateDiffYear(i.ArtistDOB, DateTime.UtcNow) < 20)
                    .ToList();
                foreach (var item in songsWithGenre)
                {
                    Console.WriteLine($"{item.SongTitle}, {item.ArtistName} - {item.GenreTitle}");
                }

                var songsByGenre = context.Songs
                    .Include(s => s.Genre)
                    .GroupBy(x => x.Genre.Title)
                    .Select(x => new
                    {
                        GenreTitle = x.Key == null ? "Without genre" : x.Key,
                        SongsCount = x.Count()
                    })
                    .ToList();

                foreach (var item in songsByGenre)
                {
                    Console.WriteLine($"{item.GenreTitle}: {item.SongsCount}");
                }

                var maxDateOfBirth = context.Artists.Max(a => a.DateOfBirth);
                var oldestSongs = context.Songs.Where(s => s.ReleaseDate < maxDateOfBirth).ToList();
                foreach (var item in oldestSongs)
                {
                    Console.WriteLine($"{item.Title}");
                }

                context.SaveChanges();

            }
        }
    }
}
