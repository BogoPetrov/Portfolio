namespace Test_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicCompany myCompany = new MusicCompany();
           
            for (int i = 0; i < 5; i++)
            {
                myCompany.AddSong(1);
                Console.WriteLine("--------------------");
            }

            foreach (Song song in myCompany.Songs)
            {
                song.ShowRank();
            }

            Console.ReadKey(true);
        }
    }
}
