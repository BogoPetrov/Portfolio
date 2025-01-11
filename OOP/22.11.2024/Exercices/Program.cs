namespace Exercices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AudioCompany audioCompany = new();
            Console.Write("Enter audio company name: ");
            audioCompany.Name = Console.ReadLine();
            Console.Write("Enter audio company address: ");
            audioCompany.Address = Console.ReadLine();
            Console.Write("Enter audio company owner: ");
            audioCompany.Owner = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter number of preformers: ");
            short count = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine();
            for (short i = 0; i < count; i++)
            {
                audioCompany.AddPreformer();
                Console.WriteLine();
            }

            Console.WriteLine("Audio company created!");
            Console.WriteLine();
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine(audioCompany.ToString());
            Console.Write("Do you want to remove a preformer? (y/n): ");
            bool remove = Console.ReadKey(true).Key == ConsoleKey.Y;
            Console.Clear();
            if (remove)
            {
                Console.Write("Enter preformer name: ");
                audioCompany.RemovePreformer(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine(audioCompany.ToString());
            }
            else
            {
                Console.WriteLine("END");
            }

            Console.ReadKey(true);

        }
    }

    public class AudioCompany
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Owner { get; set; }
        public List<Preformer?>? PreformerList { get; set; } = [];

        public AudioCompany()
        {
            Name = "No name";
            Address = "No address";
            Owner = "No owner";
        }

        public void AddPreformer()
        {
            Preformer preformer = new();
            Console.Write("Enter preformer name: ");
            preformer.Name = Console.ReadLine();
            Console.Write("Enter preformer nick name: ");
            preformer.NickName = Console.ReadLine();
            Console.WriteLine();

            preformer.AlbumList = [];
            Console.Write("Enter number of albums: ");
            short count = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine();
            for (short i = 0; i < count; i++)
            {
                preformer.AddAlbum();
                Console.WriteLine();
            }

            Console.WriteLine($"Preformer {preformer.Name} added!");
            Console.WriteLine();
            PreformerList?.Add(preformer);
        }

        public void RemovePreformer(string? preformer)
        {
            if (PreformerList != null && PreformerList.Find(check => check!.Name!.Equals(preformer)) != null)
            {
                Console.WriteLine($"Preformer {preformer} removed!");
                PreformerList.Remove(PreformerList.Find(check => check!.Name!.Equals(preformer)));
            }
        }

        public void RemovePreformer(Preformer preformer)
        {
            if (PreformerList != null && PreformerList.Contains(preformer))
            {
                Console.WriteLine($"Preformer {preformer.Name} removed!");
                PreformerList.Remove(preformer);
            }
        }

        public override string ToString()
        {
            return $"AudioCompany: {Name}\nAddress: {Address}\nOwner: {Owner}\nPreformers:\n{string.Join("\n", PreformerList!.Select(preformer => preformer!.Name))}";
        }
    }

    public class Preformer
    {
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public List<Album?>? AlbumList { get; set; } = [];

        public Preformer()
        {
            Name = "No name";
            NickName = "No nick name";
        }

        public void AddAlbum()
        {
            Album album = new();
            Console.Write("Enter album name: ");
            album.Name = Console.ReadLine();
            Console.Write("Enter album genre: ");
            album.Genre = Console.ReadLine();
            Console.Write("Enter album year: ");
            album.Year = Convert.ToInt16(Console.ReadLine());
            Console.Write("Enter album sold copies: ");
            album.SoldCopies = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine();

            album.SongList = [];
            Console.Write("Enter number of songs: ");
            short numberOfSongs = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine();
            for (short i = 0; i < numberOfSongs; i++)
            {
                album.AddSong();
                Console.WriteLine();
            }

            Console.WriteLine($"Album {album.Name} added!");
            Console.WriteLine();
            AlbumList?.Add(album);
        }

        public void RemoveAlbum(string? album)
        {
            if (AlbumList != null && AlbumList.Find(check => check!.Name!.Equals(album)) != null)
            {
                Console.WriteLine($"Album {album} removed!");
                AlbumList.Remove(AlbumList.Find(check => check!.Name!.Equals(album)));
            }
        }

        public void RemoveAlbum(Album album)
        {
            if (AlbumList != null && AlbumList.Contains(album))
            {
                Console.WriteLine($"Album {album.Name} removed!");
                AlbumList.Remove(album);
            }
        }
    }

    public class Album
    {
        public string? Name { get; set; }
        public string? Genre { get; set; }
        public short Year { get; set; }
        public short SoldCopies { get; set; }
        public List<Song?>? SongList { get; set; } = [];

        public Album()
        {
            Name = "No name";
            Genre = "No genre";
            Year = 0;
            SoldCopies = 0;
        }

        public void AddSong()
        {
            Song song = new();
            Console.Write("Enter song name: ");
            song.Name = Console.ReadLine();
            Console.Write("Enter song duration: ");
            string[] input = Console.ReadLine()!.Split(':');
            song.SongDuration = new Duration(Convert.ToInt16(input[0]), Convert.ToInt16(input[1]), Convert.ToInt16(input[2]));

            Console.WriteLine($"{song.Name} added!");
            Console.WriteLine();
            SongList?.Add(song);
        }

        public void RemoveSong(string? song)
        {
            if (SongList != null && SongList.Find(check => check!.Name!.Equals(song)) != null)
            {
                SongList.Remove(SongList.Find(check => check!.Name!.Equals(song)));
            }
        }

        public void RemoveSong(Song album)
        {
            if (SongList != null && SongList.Contains(album))
            {
                SongList.Remove(album);
            }
        }
    }

    public class Song
    {
        public string? Name { get; set; }
        public Duration? SongDuration { get; set; }

        public Song()
        {
            Name = "No name";
            SongDuration = new Duration();
        }
    }

    public struct Duration(short hours, short minutes, short seconds)
    {
        public short Hours { get; set; } = hours;
        public short Minutes { get; set; } = minutes;
        public short Seconds { get; set; } = seconds;

        public readonly override string ToString()
        {
            return $"{Hours}:{Minutes}:{Seconds}";
        }
    }
}
