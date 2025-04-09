namespace Pet_Clinic
{
    internal class Program
    {
        static void Main()
        {
            List<Clinic> clinics = [];
            List<string?>? commands;
            string? input;
            List<string?>? results = [];

            if (int.TryParse(Console.ReadLine(), out int count))
            {
                for (int i = 0; i < count; i++)
                {
                    input = Console.ReadLine();
                    commands = [.. input!.Split(' ')];

                    switch (commands.Count)
                    {
                        case 5:
                            {
                                Clinic.CreatePet(commands[2]!, int.Parse(commands[3]!), commands[4]!);
                            }
                            break;
                        case 4:
                            {
                                if (int.TryParse(commands[3], out int capacity))
                                {
                                    if (capacity % 2 != 0)
                                    {
                                        Clinic clinic = new(capacity)
                                        {
                                            Name = commands[2]
                                        };

                                        clinics.Add(clinic);
                                    }
                                    else
                                    {
                                        results.Add("Invalid Operation!");
                                    }
                                }
                            }
                            break;
                        case 3:
                            {
                                if (commands[0]!.Equals("Add", StringComparison.OrdinalIgnoreCase))
                                {
                                    results.Add(clinics.Select(clinic => clinic).First(clinic => clinic.Name == commands[2]!).AddPet(commands[1]!).ToString());
                                }
                                else if (commands[0]!.Equals("Print", StringComparison.OrdinalIgnoreCase))
                                {
                                    results.Add(clinics.Select(clinic => clinic).First(clinic => clinic.Name == commands[1]!).Rooms[int.Parse(commands[2]!)].Print());
                                }
                            }
                            break;
                        case 2:
                            {
                                if (commands[0]!.Equals("HasEmptyRooms", StringComparison.OrdinalIgnoreCase))
                                {
                                    results.Add(clinics.Select(clinic => clinic).First(clinic => clinic.Name == commands[1]!).HasEmptyRoom().ToString());
                                }
                                else if (commands[0]!.Equals("Release", StringComparison.OrdinalIgnoreCase))
                                {
                                    results.Add(clinics.Select(clinic => clinic).First(clinic => clinic.Name == commands[1]!).RemovePet().ToString());
                                }
                                else if (commands[0]!.Equals("Print", StringComparison.OrdinalIgnoreCase))
                                {
                                    results.Add(clinics.Select(clinic => clinic).First(clinic => clinic.Name == commands[1]!).Print());
                                }
                            }
                            break;
                    }
                }
            }

            Console.WriteLine();
            foreach (string? result in results!)
            {
                Console.WriteLine(result);
            }
            Console.ReadKey(true);
        }
    }

    public class Pet
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Species { get; set; }

        public string? Print()
        {
            return $"Name: {Name}, Age: {Age}, Species: {Species}";
        }
    }

    public class Clinic
    {
        public string? Name { get; set; }
        public int Capacity { get; set; }

        private int CentralRoom => (Capacity / 2) + 1;

        private int _nextFreeRoomBeforeCentral;
        private int _nextFreeRoomAfterCentral;
        private bool _beforeOrAfter = true;

        public Dictionary<int, Pet> Rooms { get; set; } = [];
        public static List<Pet> Pets { get; set; } = [];

        public Clinic() { }
        public Clinic(int capacity)
        {
            Capacity = capacity;
            _nextFreeRoomBeforeCentral = CentralRoom - 1;
            _nextFreeRoomAfterCentral = CentralRoom + 1;
            for (int i = 1; i <= capacity; i++)
            {
                Rooms.Add(i, null!);
            }
        }

        public static bool CreatePet(string name, int age, string species)
        {
            if (age > 0)
            {
                Pet pet = new()
                {
                    Name = name,
                    Age = age,
                    Species = species
                };
                Pets.Add(pet);
                return true;
            }
            return false;
        }

        public bool AddPet(string? petName)
        {
            if (Pets.Contains(Pets.Select(pet => pet).First(pet => pet.Name == petName)))
            {
                if (Rooms[CentralRoom] == null)
                {
                    Rooms[CentralRoom] = Pets.Select(pet => pet).First(pet => pet.Name == petName);
                    return true;
                }

                if (!(_nextFreeRoomAfterCentral > Capacity || _nextFreeRoomBeforeCentral < 1))
                {
                    if (_beforeOrAfter)
                    {
                        Rooms[_nextFreeRoomBeforeCentral--] = Pets.Select(pet => pet).First(pet => pet.Name == petName);
                        _beforeOrAfter = false;
                        return true;
                    }
                    else if (!_beforeOrAfter)
                    {
                        Rooms[_nextFreeRoomAfterCentral++] = Pets.Select(pet => pet).First(pet => pet.Name == petName);
                        _beforeOrAfter = true;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool RemovePet()
        {
            bool flag = true;
            if (Rooms[CentralRoom] != null)
            {
                Rooms[CentralRoom] = null!;
                return true;
            }

            while (flag)
            {
                for (int i = CentralRoom + 1; i <= Capacity; i++)
                {
                    if (Rooms[i] != null)
                    {
                        Rooms[i] = null!;
                        if (!(_nextFreeRoomAfterCentral - 1 == CentralRoom))
                        {
                            _nextFreeRoomAfterCentral--;
                        }
                        else
                        {
                            _nextFreeRoomAfterCentral = CentralRoom + 1;
                        }
                        _beforeOrAfter = true;
                        return true;
                    }
                }

                for (int i = 1; i < CentralRoom; i++)
                {
                    if (Rooms[i] != null)
                    {
                        Rooms[i] = null!;
                        if (!(_nextFreeRoomBeforeCentral + 1 == CentralRoom))
                        {
                            _nextFreeRoomBeforeCentral++;
                        }
                        else
                        {
                            _nextFreeRoomBeforeCentral = CentralRoom - 1;
                        }
                        _beforeOrAfter = false;
                        return true;
                    }
                }

                flag = false;
            }

            return false;
        }

        public bool HasEmptyRoom()
        {
            return Rooms.Values.Any(pet => pet == null);
        }

        public string? Print()
        {
            string? result = "";
            foreach (var room in Rooms)
            {
                if (room.Value != null)
                {
                    result += room.Value.Print() + "\n";
                }
                else
                {
                    result += $"Room {room.Key} is empty\n";
                }
            }
            result = result.TrimEnd('\n');
            return result;
        }
    }
}