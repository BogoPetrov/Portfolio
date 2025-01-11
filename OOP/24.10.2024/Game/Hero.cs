using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Game
{
    public class Hero
    {
        // Static fields
        protected readonly static Random randomValues = new();

        // Fields
        private int _attack;
        private int _shield;
        private int _health;
        private string? _name;
        private string? _status;
        private int _battlesWon;
        private int _totalAttacks;

        // Properties
        public int Attack
        {
            get => _attack;
            set => _attack = value;
        }

        public int Shield
        {
            get => _shield;
            set => _shield = value;
        }

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        public string? Name
        {
            get => _name;
            set => _name = value;
        }

        public string? Status
        {
            get => _status;
            set => _status = value;
        }

        public int BattlesWon
        {
            get => _battlesWon;
            set => _battlesWon = value;
        }

        public int TotalAttacks
        {
            get => _totalAttacks;
            set => _totalAttacks = value;
        }

        // Constructors
        public Hero()
        {
            Attack = randomValues.Next(50, 100);
            Shield = randomValues.Next(50, 100);
            Health = randomValues.Next(50, 100);
            Name = "No name";
            Status = "Hero";
            BattlesWon = 0;
            TotalAttacks = 0;
        }

        public Hero(string? name)
        : this()
        {
            Name = name;
        }

        // Methods
        public virtual void Show()
        {
            Console.WriteLine($"Name of hero: {_name} ");
            Console.WriteLine($"Health: {_health}");
            Console.WriteLine($"Attack: {_attack}");
            Console.WriteLine($"Shield: {_shield}");
        }

        public void Battle(Hero other)
        {
            int thisLiveBar = this.Health + this.Shield;
            int otherLiveBar = other.Health + other.Shield;
            while (true)
            {
                // Second hero win in else statement!
                if (thisLiveBar > 0)
                {
                    if (GetType() == typeof(Knight) || GetType() == typeof(Hero))
                    {
                        otherLiveBar -= this.Attack;
                    }
                    else if (GetType() == typeof(Wizard))
                    {
                        if (TotalAttacks % 3 == 0 && (this as Wizard)!.MagicalItem != "")
                        {
                            otherLiveBar -= this.Attack + (this.Attack * (this as Wizard)!.MagicalPower);
                        }
                        else
                        {
                            otherLiveBar -= this.Attack;
                        }
                    }
                    TotalAttacks++;
                }
                else
                {
                    Console.WriteLine($"{Name} (Wins:{BattlesWon}) vs {other.Name} (Wins:{other.BattlesWon})");
                    Console.WriteLine($"Lose <--> Win");
                    other.BattlesWon++;
                    if (other.GetType() == typeof(Knight))
                    {
                        (other as Knight)!.CheckForPromotionOrDemotion();
                    }
                    if (BattlesWon > 0)
                        BattlesWon--;
                    break;
                }

                // First hero win in else statement!
                if (otherLiveBar > 0)
                {
                    if (other.GetType() == typeof(Knight) || other.GetType() == typeof(Hero))
                    {
                        thisLiveBar -= other.Attack;
                    }
                    else if (other.GetType() == typeof(Wizard))
                    {
                        if (other.TotalAttacks % 3 == 0 && (other as Wizard)!.MagicalItem != "")
                        {
                            thisLiveBar -= other.Attack + (other.Attack * (other as Wizard)!.MagicalPower);
                        }
                        else
                        {
                            thisLiveBar -= other.Attack;
                        }
                    }
                    other.TotalAttacks++;
                }
                else
                {
                    Console.WriteLine($"{Name} (Wins:{BattlesWon}) vs {other.Name} (Wins:{other.BattlesWon})");
                    Console.WriteLine("Win <--> Lose");
                    if (GetType() == typeof(Knight))
                    {
                        (this as Knight)!.CheckForPromotionOrDemotion();
                    }
                    if (GetType() == typeof(Knight) && other.GetType() == typeof(Wizard))
                    {
                        if ((other as Wizard)!.MagicalItem != "")
                        {
                            Console.WriteLine($"{Name} defeat {other.Name} and take magical item {(other as Wizard)!.MagicalItem}");
                            (this as Knight)!.MagicalItem = (other as Wizard)!.MagicalItem;
                            (other as Wizard)!.MagicalItem = "";
                        }
                    }

                    BattlesWon++;
                    if (other.BattlesWon > 0)
                        other.BattlesWon--;
                    break;
                }
            }
        }

        public virtual string ShowExperience()
        {
            return $"Hero: {Name}\nBattles won: {BattlesWon}\nTotal attacks: {TotalAttacks}";
        }
    }
}
