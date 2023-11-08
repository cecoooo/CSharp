namespace MusicHub
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context = new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Console.WriteLine(ExportAlbumsInfo(context, 9));

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            string res = "";

            var albumInfo = context.Producers
                .Include(x => x.Albums)
                .ThenInclude(x => x.Songs)
                .ThenInclude(x => x.Writer)
                .First(x => x.Id == producerId)
                .Albums.Select(x => new
                {
                    AlbumName = x.Name,
                    x.ReleaseDate,
                    ProducerName = x.Producer.Name,
                    SongInfo = x.Songs.Select(x => new
                    {
                        SongName = x.Name,
                        x.Price,
                        WriterName = x.Writer.Name
                    }).
                    OrderByDescending(x => x.SongName)
                    .ThenBy(x => x.WriterName)
                    .AsEnumerable(),
                    TotalAlbumPrice = x.Price
                })
                .OrderByDescending(x => x.TotalAlbumPrice)
                .AsEnumerable();

            int albumInfoLength = albumInfo.Count();
            int i = 1;

            foreach (var album in albumInfo)
            {
                res += $"-AlbumName: {album.AlbumName}\n" +
                    $"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}\n" +
                    $"-ProducerName: {album.ProducerName}\n" +
                    $"-Songs:\n";
                int count = 1;
                foreach (var song in album.SongInfo)
                {
                    res += $"---#{count}\n" +
                        $"---SongName: {song.SongName}\n" +
                        $"---Price: {song.Price:f2}\n" +
                        $"---Writer: {song.WriterName}\n";
                    count++;
                }
                res += $"-AlbumPrice: {album.TotalAlbumPrice:f2}";
                if (i != albumInfoLength)
                    res += "\n";
                i++;
            }

            return res;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            string res = "";

            var songs = context.Songs
                .Include(x => x.Album)
                .ThenInclude(x => x.Producer)
                .Select(x => new
                {
                    SongName = x.Name,
                    PerformerFullName = x.SongPerformers
                    .Select(x => new
                    {
                        x.Performer.FirstName,
                        x.Performer.LastName
                    })
                    .Where(x => x.FirstName != null)
                    .OrderBy(x => x.FirstName)
                    .AsEnumerable(),
                    WriterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.WriterName)
                .AsEnumerable()
                .Where(x => x.Duration.TotalSeconds > duration);

            int count = 1;
            int songsCount = songs.Count();

            foreach (var song in songs)
            {
                res += $"-Song #{count}\n" +
                    $"---SongName: {song.SongName}\n" +
                    $"---Writer: {song.WriterName}\n";
                foreach (var performer in song.PerformerFullName)
                {
                    res += $"---Performer: {performer.FirstName} {performer.LastName}\n";
                }
                res += $"---AlbumProducer: {song.AlbumProducer}\n" +
                    $"---Duration: {song.Duration.ToString("c")}";
                if (count != songsCount)
                    res += "\n";
                count++;
            }
            return res;
        }
    }
}
