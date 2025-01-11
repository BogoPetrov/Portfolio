using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    public abstract class Song
    {
        // Fields
        protected string? _nameOfSong;
        protected string? _typeOfSong;
        protected short _durationOfSong;
        protected string? _nameOfAuthor;
        protected DateTime _releaseDate;
        protected short _rank;

        // Properties
        public string? NameOfSong
        {
            get => _nameOfSong; protected set => _nameOfSong = value;
        }
        public string? TypeOfSong
        {
            get => _typeOfSong; protected set => _typeOfSong = value;
        }
        public short DurationOfSong
        {
            get => _durationOfSong; protected set => _durationOfSong = value;
        }
        public string? NameOfAuthor
        {
            get => _nameOfAuthor; protected set => _nameOfAuthor = value;
        }
        public DateTime ReleaseDate
        {
            get => _releaseDate; protected set => _releaseDate = value;
        }
        public short Rank
        {
            get => _rank; protected set => _rank = value;
        }

        // Methods
        public abstract void ShowRank();
    }

    public class PopSong : Song
    {
        // Constructor
        public PopSong(string nameOfSong, string typeOfSong, short durationOfSong, string nameOfAuthor, DateTime releaseDate, short rank)
        {
            NameOfSong = nameOfSong;
            TypeOfSong = typeOfSong;
            DurationOfSong = durationOfSong;
            NameOfAuthor = nameOfAuthor;
            ReleaseDate = releaseDate;
            Rank = rank;
        }

        // Methods
        public override void ShowRank()
        {
            if (_rank < 100)
            {
                Console.WriteLine("This song is in TOP 100 pop songs!");
            }
            else
            {
                Console.WriteLine("This song is a poupular pop song!");
            }
        }

    }

    public class RockSong : Song
    {
        public RockSong(string nameOfSong, string typeOfSong, short durationOfSong, string nameOfAuthor, DateTime releaseDate, short rank)
        {
            NameOfSong = nameOfSong;
            TypeOfSong = typeOfSong;
            DurationOfSong = durationOfSong;
            NameOfAuthor = nameOfAuthor;
            ReleaseDate = releaseDate;
            Rank = rank;
        }

        // Methods
        public override void ShowRank()
        {
            if (_rank < 100)
            {
                Console.WriteLine("This song is in TOP 100 rock songs!");
            }
            else
            {
                Console.WriteLine("This song is a poupular rock songs!");
            }
        }
    }

    public class FolkSong : Song
    {
        public FolkSong(string nameOfSong, string typeOfSong, short durationOfSong, string nameOfAuthor, DateTime releaseDate, short rank)
        {
            NameOfSong = nameOfSong;
            TypeOfSong = typeOfSong;
            DurationOfSong = durationOfSong;
            NameOfAuthor = nameOfAuthor;
            ReleaseDate = releaseDate;
            Rank = rank;
        }

        // Methods
        public override void ShowRank()
        {
            if (_rank < 100)
            {
                Console.WriteLine("This song is in TOP 100 folk songs!");
            }
            else
            {
                Console.WriteLine("This song is a poupular folk songs!");
            }
        }
    }
}
