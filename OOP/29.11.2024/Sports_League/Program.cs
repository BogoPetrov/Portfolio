using System.Collections;
using System.Numerics;

namespace Sports_League
{
    internal class Program
    {
        public static void Main()
        {
            List<League> leagues = [];
            List<Referee> referees = [];
            List<Coach> coaches = [];
            Console.WriteLine("-----------------------------------------------\n");
            Console.WriteLine("        SPORTS LEAGUE MANAGEMENT SYSTEM\n");
            Console.WriteLine("-----------------------------------------------\n");

            Console.Write("To start, please enter the number of leagues: ");
            int numberOfLeagues = Convert.ToInt32(Console.ReadLine());
            for (int leagueCount = 0; leagueCount < numberOfLeagues; leagueCount++)
            {
                Console.Write($"Enter the name of the {leagueCount + 1} league: ");
                string? nameOfLeague = Console.ReadLine();
                Console.Write("Enter the sport name for this league (football, basketball, tennis): ");
                string? sportName = Console.ReadLine();
                League league = new(nameOfLeague!);

                Console.Write("Enter the number of teams: ");
                int numberOfTeams = Convert.ToInt32(Console.ReadLine());
                for (int teamCount = 0; teamCount < numberOfTeams; teamCount++)
                {
                    Console.Write($"Enter the name of the {teamCount + 1} team: ");
                    string? nameOfTeam = Console.ReadLine();
                    Team team = new(nameOfTeam!);

                    Console.Write("Enter the number of players: ");
                    int numberOfPlayers = Convert.ToInt32(Console.ReadLine());
                    for (int playerCount = 0; playerCount < numberOfPlayers; playerCount++)
                    {
                        Console.Write($"Enter the name of the {playerCount + 1} player: ");
                        string? nameOfPlayer = Console.ReadLine();
                        Console.Write($"Enter the age of the {playerCount + 1} player: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Console.Write($"Enter the rank of the {playerCount + 1} player: ");
                        int rank = Convert.ToInt32(Console.ReadLine());

                        Player player = sportName!.ToLower() switch
                        {
                            "football" => new FootballPlayer(nameOfPlayer!, age, rank),
                            "basketball" => new BasketballPlayer(nameOfPlayer!, age, rank),
                            "tennis" => new TennisPlayer(nameOfPlayer!, age, rank),
                            _ => new(nameOfPlayer!, age, rank)
                        };
                        team.AddPlayer(player);
                    }

                    Console.WriteLine();
                    Console.Write($"Enter the name for the coach of team {team.Name}: ");
                    string? nameOfCoach = Console.ReadLine();
                    Console.Write("Enter the age of the couch: ");
                    int coachAge = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the experience of the couch: ");
                    int coachExperience = Convert.ToInt32(Console.ReadLine());

                    Coach couch = new(nameOfCoach!, coachAge, coachExperience, team.Name);
                    coaches.Add(couch);
                    league.AddTeam(team);
                }

                Console.WriteLine();
                Console.Write($"Enter the name for the referee of league {league.Name}: ");
                string? nameOfReferee = Console.ReadLine();
                Console.Write("Enter the age of the referee: ");
                int refereeAge = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the experience of the referee: ");
                int experience = Convert.ToInt32(Console.ReadLine());

                Referee referee = new(nameOfReferee!, refereeAge, experience, league.Name);
                referees.Add(referee);
                leagues.Add(league);
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select one of the following options:\n");
                Console.WriteLine("1. Schedule a match\n2. Train teams\n3. Get the leaderboard\n4. Exit\n");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write($"Select the league you want to schedule a match for [ {string.Join(", ", leagues.Select(league => league.Name))} ]: ");
                        string? leagueName = Console.ReadLine();
                        for (int i = 0; i < leagues.Count; i++)
                        {
                            if (leagues[i].Name!.Equals(leagueName, StringComparison.OrdinalIgnoreCase))
                            {
                                leagues[i].ScheduleMatch();
                                leagues[i].Teams!.ForEach(team => team.CheckPlayers());
                                referees.ForEach(referee => referee.DisqualifyPlayer(leagues));
                                Console.ReadKey(true);
                                break;
                            }
                        }
                        break;
                    case 2:
                        Console.Write($"Select the league you want to get the teams trained [ {string.Join(", ", leagues.Select(league => league.Name))} ]: ");
                        leagueName = Console.ReadLine();
                        for (int i = 0; i < leagues.Count; i++)
                        {
                            if (leagues[i].Name!.Equals(leagueName, StringComparison.OrdinalIgnoreCase))
                            {
                                leagues[i].Teams!.ForEach(team => coaches.ForEach(coach => coach.TrainTeam(leagues[i])));
                                Console.ReadKey(true);
                                break;
                            }
                        }
                        break;
                    case 3:
                        Console.Write($"Select the league you want to get the leaderboard [ {string.Join(", ", leagues.Select(league => league.Name))} ]: ");
                        leagueName = Console.ReadLine();
                        for (int i = 0; i < leagues.Count; i++)
                        {
                            if (leagues[i].Name!.Equals(leagueName, StringComparison.OrdinalIgnoreCase))
                            {
                                leagues[i].GetLeaderboard();
                                Console.ReadKey(true);
                                break;
                            }
                        }
                        break;
                    case 4:
                        Console.ReadKey(true);
                        return;
                }
            }
        }
    }

    #region Interfaces
    public interface ISport
    {
        public void PlayMatch();
        public void Train();
        public int GetPerformanceStats();
    }

    public interface ITeam
    {
        public void AddPlayer(Player player);
        public void RemovePlayer(Player player);
        public int GetTeamStats();
    }

    public interface ILeague
    {
        public void AddTeam(Team team);
        public void ScheduleMatch();
        public void GetLeaderboard();
    }
    #endregion

    #region Abstract classes
    public abstract class Person(string? name, int age, string? role)
    {
        public string? Name { get; set; } = name;
        public string? Role { get; set; } = role;
        public int Age { get; set; } = age;
    }
    #endregion

    #region Normal classes
    public class Player(string? name, int age, int rank) : Person(name, age, "Player")
    {
        public int Rank { get; set; } = rank;
        public int Points { get; set; } = 0;
        public bool HasViolation { get; set; } = false;
    }

    public class Coach(string? name, int age, int experience, string? teamName) : Person(name, age, "Coach")
    {
        public int Experience { get; set; } = experience;
        public string? TeamName { get; set; } = teamName;

        public void TrainTeam(League? league)
        {
            foreach (Team team in league!.Teams!)
            {
                if (team.Name!.Equals(TeamName, StringComparison.OrdinalIgnoreCase))
                {
                    foreach (Player player in team!.Players!)
                    {
                        switch (player.GetType().Name)
                        {
                            case "FootballPlayer":
                                (player as FootballPlayer)!.Train();
                                Experience++;
                                break;
                            case "BasketballPlayer":
                                (player as BasketballPlayer)!.Train();
                                Experience++;
                                break;
                            case "TennisPlayer":
                                (player as TennisPlayer)!.Train();
                                Experience++;
                                break;
                            default:
                                continue;
                        }
                    }
                }
            }
        }
    }

    public class Referee(string? name, int age, int experience, string? leagueName) : Person(name, age, "Referee")
    {
        public int Experience { get; set; } = experience;
        public string? LeagueName { get; set; } = leagueName;

        public void DisqualifyPlayer(List<League>? leagues)
        {
            foreach (League league in leagues!)
            {
                if (league.Name!.Equals(LeagueName, StringComparison.OrdinalIgnoreCase))
                {
                    foreach (Team team in league!.Teams!)
                    {
                        for (int i = 0; i < team.Players!.Count; i++)
                        {
                            if (team.Players[i].HasViolation)
                            {
                                Console.WriteLine($"{team.Players[i].Name} has been disqualified from team {team.Name} by referee {Name}!");
                                team.Players.Remove(team.Players[i]);
                                Experience++;
                            }
                        }
                    }
                }
            }
        }
    }

    public class FootballPlayer(string? name, int age, int rank) : Player(name, age, rank), ISport
    {
        public void PlayMatch()
        {
            Random randomCase = new();
            bool isChanceToScore = randomCase.Next(-10, 10) > 0;
            if (isChanceToScore)
            {
                Points++;
                Console.WriteLine($"{Name} scores a goal!");
            }

            bool isChanceToViolation = randomCase.Next(-10, 10) > 0;
            if (isChanceToViolation)
            {
                Console.WriteLine($"{Name} has a violation!");
                HasViolation = true;
            }
        }

        public void Train()
        {
            Console.WriteLine($"{Name} is training football!");
            Rank += 10;
        }

        public int GetPerformanceStats()
        {
            return Points;
        }
    }

    public class BasketballPlayer(string? name, int age, int rank) : Player(name, age, rank), ISport
    {
        public void PlayMatch()
        {
            Random randomCase = new();
            int pointChance = randomCase.Next(-10, 11);
            if (pointChance > 0 && pointChance < 5)
            {
                Points++;
                Console.WriteLine($"{Name} make a free throw!");
            }
            else if (pointChance > 5 && pointChance < 10)
            {
                Points += 2;
                Console.WriteLine($"{Name} make a 2-point shot!");
            }
            else if (pointChance == 10)
            {
                Points += 3;
                Console.WriteLine($"{Name} make a 3-point shot!");
            }

            bool isChanceToViolation = randomCase.Next(-10, 10) > 0;
            if (isChanceToViolation)
            {
                Console.WriteLine($"{Name} has a violation!");
                HasViolation = true;
            }
        }

        public void Train()
        {
            Console.WriteLine($"{Name} is training basketball!");
            Rank += 10;
        }

        public int GetPerformanceStats()
        {
            return Points;
        }
    }

    public class TennisPlayer(string? name, int age, int rank) : Player(name, age, rank), ISport
    {
        public void PlayMatch()
        {
            Random randomCase = new();
            bool isChance = randomCase.Next(-10, 10) > 0;
            if (isChance)
            {
                Points++;
                Console.WriteLine($"{Name} make a point!");
            }
        }

        public void Train()
        {
            Console.WriteLine($"{Name} is training tennis!");
            Rank += 10;
        }

        public int GetPerformanceStats()
        {
            return Points;
        }
    }

    public class Team(string? name) : ITeam
    {
        public List<Player>? Players { get; set; } = [];
        public string? Name { get; set; } = name;

        public void CheckPlayers()
        {
            if (Players!.Count == 2)
            {
                foreach (Player player in Players)
                {
                    player.HasViolation = false;
                }
            }
        }

        public void AddPlayer(Player player)
        {
            if (player != null)
            {
                Players!.Add(player);
            }
            else
            {
                throw new Exception("The player is not valid!");
            }
        }
        public void RemovePlayer(Player player)
        {
            if (Players!.Contains(player))
            {
                Console.WriteLine($"{player.Name} has been removed from the team {Name}!");
                Players.Remove(player);
            }
            else
            {
                throw new Exception("The player is not in the team!");
            }
        }
        public int GetTeamStats()
        {
            return Players!.Sum(player => player.Points);
        }
    }

    public class League(string? name) : ILeague
    {
        public List<Team>? Teams { get; set; } = [];
        public string? Name { get; set; } = name;

        public void AddTeam(Team team)
        {
            if (team != null)
            {
                Teams!.Add(team);
            }
            else
            {
                throw new Exception("The team is not valid!");
            }
        }

        public void ScheduleMatch()
        {
            Random randomIndex = new();
            Team team1 = Teams![randomIndex.Next(Teams!.Count)];
            Team team2 = Teams![randomIndex.Next(Teams!.Count)];

            if (team1 != team2)
            {
                PlayMatch(team1, team2);
            }
            else
            {
                team2 = Teams![randomIndex.Next(Teams!.Count)];
                PlayMatch(team1, team2);
            }
        }

        private static void PlayMatch(Team team1, Team team2)
        {
            foreach (Player player in team1.Players!)
            {
                (player as ISport)!.PlayMatch();
            }
            foreach (Player player in team2.Players!)
            {
                (player as ISport)!.PlayMatch();
            }
        }

        public void GetLeaderboard()
        {
            string[]? leaderboard = new string[Teams!.Count];
            int[] points = Teams!.Select(team => team.GetTeamStats()).ToArray();
            Array.Sort(points);
            for (int i = 0; i < Teams!.Count; i++)
            {
                if (Teams[i].GetTeamStats() == points[i])
                {
                    leaderboard[i] = Teams[i].Name!;
                }
            }

            int position = 1;
            Console.WriteLine("Leaderboard:");
            Console.WriteLine("Team - Points");
            for (int i = leaderboard.Length - 1; i >= 0 ; i--)
            {
                Console.WriteLine($"{position}. {leaderboard[i]} - {points[i]}");
                position++;
            }
        }
    }
    #endregion
}
