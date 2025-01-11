using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    internal class MusicCompany
    {
        public List<Song> Songs = [];

        public void AddSong()
        {
            Console.WriteLine("Enter information about song in this format 'Type of the song: Name of the song, Duration of the song, Name of the author, Rank (whole number), Release date (dd.mm.yyyy)' ");
            string[] songInfo = [.. Console.ReadLine()!.Split(',', ':')];

            Song? song = songInfo[0] switch
            {
                "Pop" => new PopSong(songInfo[1], songInfo[0], Convert.ToInt16(songInfo[2]), songInfo[3], DateTime.Parse(songInfo[5]), short.Parse(songInfo[4])),
                "Rock" => new RockSong(songInfo[1], songInfo[0], short.Parse(songInfo[2]), songInfo[3], DateTime.Parse(songInfo[5]), short.Parse(songInfo[4])),
                "Folk" => new FolkSong(songInfo[1], songInfo[0], short.Parse(songInfo[2]), songInfo[3], DateTime.Parse(songInfo[5]), short.Parse(songInfo[4])),
                _ => null
            };

            if (song != null)
            {
                Songs.Add(song);
            }
            else
            {
                throw new FormatException("Invalid input!");
            }
        }

        public void AddSong(int index = 1)
        {
            string[] songInfo = new string[6];

            Console.Write("Enter type of the song: ");
            songInfo[0] = Console.ReadLine()!;

            Console.Write("Enter name of the song: ");
            songInfo[1] = Console.ReadLine()!;

            Console.Write("Enter duration of the song: ");
            songInfo[2] = Console.ReadLine()!;

            Console.Write("Enter name of the author: ");
            songInfo[3] = Console.ReadLine()!;

            Console.Write("Enter rank (whole number): ");
            songInfo[4] = Console.ReadLine()!;

            Console.Write("Enter release date (dd.mm.yyyy): ");
            songInfo[5] = Console.ReadLine()!;

            Song? song = songInfo[0] switch
            {
                "Pop" => new PopSong(songInfo[1], songInfo[0], Convert.ToInt16(songInfo[2]), songInfo[3], DateTime.Parse(songInfo[5]), short.Parse(songInfo[4])),
                "Rock" => new RockSong(songInfo[1], songInfo[0], short.Parse(songInfo[2]), songInfo[3], DateTime.Parse(songInfo[5]), short.Parse(songInfo[4])),
                "Folk" => new FolkSong(songInfo[1], songInfo[0], short.Parse(songInfo[2]), songInfo[3], DateTime.Parse(songInfo[5]), short.Parse(songInfo[4])),
                _ => null
            };

            if (song != null)
            {
                Songs.Add(song);
            }
            else
            {
                throw new FormatException("Invalid input!");
            }
        }
    }
}
