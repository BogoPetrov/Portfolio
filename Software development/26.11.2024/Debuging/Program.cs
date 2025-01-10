namespace Debuging
{
    class Maze
    {
        private char[,]? grid;
        private readonly Random random = new();
        private readonly List<(int X, int Y)> treasures = [];
        private readonly List<(int X, int Y)> traps = [];

        public char[,]? Grid => grid;

        public void GenerateMaze()
        {
            int lenght = random.Next(1, 15);
            int width = random.Next(1, 15);
            grid = new char[lenght, width];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = '.';
                }
            }

            // Place treasures
            for (int i = 0; i < random.Next(2, 8); i++)
            {
                int x = random.Next(1, grid.GetLength(0));
                int y = random.Next(1, grid.GetLength(1));
                try
                {
                    grid[x, y] = 'T';
                    treasures.Add((x, y));
                }
                catch (Exception)
                {
                    continue;
                }
            }

            // Place traps
            for (int i = 0; i < random.Next(4, 10); i++)
            {
                int x = random.Next(1, grid.GetLength(0));
                int y = random.Next(1, grid.GetLength(1));
                try
                {
                    grid[x, y] = 'X';
                    traps.Add((x, y));
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        public void DisplayMaze(Player player, Enemy enemy)
        {
            for (int i = 0; i < grid!.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (i == player.X && j == player.Y)
                    {
                        Console.Write("P ");
                    }
                    else if (i == enemy.X && j == enemy.Y)
                    {
                        Console.Write("E ");
                    }
                    else
                    {
                        Console.Write(grid[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public bool IsTreasure(int x, int y) => treasures.Contains((x, y));

        public bool IsTrap(int x, int y) => traps.Contains((x, y));

        public void RemoveTreasure(int x, int y)
        {
            treasures.Remove((x, y));
            grid![x, y] = '.';
        }

        public void RemoveTrap(int x, int y)
        {
            traps.Remove((x, y));
            grid![x, y] = '.';
        }

        public bool AllTreasuresCollected()
        {
            foreach (var treasure in treasures)
            {
                if (treasure != default)
                    return false;
            }
            return true;
        }
    }

    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Score { get; set; }

        public Player()
        {
            X = 0;
            Y = 0;
            Score = 0;
        }

        public bool Move(string direction, Maze maze)
        {
            int newX = X, newY = Y;
            switch (direction)
            {
                case "N":
                    newX--; break;
                case "S":
                    newX++; break;
                case "E":
                    newY++; break;
                case "W":
                    newY--; break;
                default:
                    return false;
            }

            if (newX < 0 || newX >= maze.Grid!.GetLength(0) || newY < 0 || newY >= maze.Grid!.GetLength(1))
                return false;

            X = newX;
            Y = newY;
            return true;
        }
    }

    class Enemy(Maze maze)
    {
        public int X { get; set; } = maze.Grid!.GetLength(0) - 1;
        public int Y { get; set; } = maze.Grid!.GetLength(1) - 1;
        private readonly Random random = new();

        public void ChasePlayer(Player player, Maze maze)
        {
            // Simple random chase logic
            int moveX = random.Next(-2, 3);
            int moveY = random.Next(-2, 3);
            int newX = X;
            int newY = Y;
            
            if (player.X - (newX + moveX) < player.X - (newX - moveX) && player.Y - (newY + moveY) < player.Y - (newY - moveY))
            {
                newX += moveX;
                newY += moveY; 
            }
            else
            {
                newX -= moveX;
                newY -= moveY;
            }

            if (newX > 0 && newX < maze.Grid!.GetLength(0) && newY > 0 && newY < maze.Grid!.GetLength(1))
            {
                X = newX;
                Y = newY;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Ultimate Maze Adventure Game!");
            Maze maze = new();
            maze.GenerateMaze();

            Player player = new();
            Enemy enemy = new(maze);
            int moves = 0;
            int maxMoves = 20;
            Console.ReadKey(true);

            while (moves <= maxMoves)
            {
                Console.Clear();
                Console.WriteLine($"\nMove {moves + 1} of {maxMoves}");
                Console.WriteLine($"Player Position: ({player.X}, {player.Y}) | Score: {player.Score}");
                Console.WriteLine($"Enemy Position: ({enemy.X}, {enemy.Y})");
                Console.WriteLine("Choose a direction: (N)orth, (S)outh, (E)ast, (W)est or (Q)uit");
                maze.DisplayMaze(player, enemy);

                string? direction = Console.ReadLine()?.ToUpper();
                if (direction == "Q")
                {
                    Console.WriteLine("You gave up! Game over.");
                    break;
                }

                bool moved = player.Move(direction!, maze);
                if (!moved)
                {
                    Console.WriteLine("Invalid move! You hit a wall.");
                }
                else
                {
                    moves++;
                    if (maze.IsTreasure(player.X, player.Y))
                    {
                        Console.WriteLine("You found a treasure! +10 points.");
                        player.Score += 10;
                        maze.RemoveTreasure(player.X, player.Y);
                    }
                    if (maze.IsTrap(player.X, player.Y))
                    {
                        Console.WriteLine("Oh no! You fell into a trap. -5 points.");
                        player.Score -= 5;
                        maze.RemoveTrap(player.X, player.Y);
                    }
                }

                enemy.ChasePlayer(player, maze);
                if (enemy.X == player.X && enemy.Y == player.Y)
                {
                    Console.WriteLine("The enemy caught you! Game over.");
                    break;
                }

                if (maze.AllTreasuresCollected())
                {
                    Console.WriteLine("Congratulations! You collected all the treasures!");
                    break;
                }
                Console.ReadKey(true);
            }

            Console.WriteLine($"\nGame Over! Your final score: {player.Score}");
            Console.WriteLine($"Total moves taken: {moves}");
            Console.ReadKey(true);
        }
    }
}
