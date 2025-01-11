using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Wizard : Hero
    {
        // Fields
        private string? _magicalItem;
        private int _magicalPower;

        // Properties
        public string? MagicalItem
        {
            get => _magicalItem;
            set => _magicalItem = value;
        }

        public int MagicalPower
        {
            get => _magicalPower;
            set => _magicalPower = value;
        }

        // Constructor
        public Wizard() : base()
        {
            MagicalItem = "No magical item";
            MagicalPower = Hero.randomValues.Next(1, 6);
        }
        public Wizard(string? name) : base(name)
        {
            MagicalItem = "No magical item";
            MagicalPower = Hero.randomValues.Next(1, 6);
        }

        public Wizard(string? name, string? magicalItem) : base(name)
        {
            MagicalItem = magicalItem;
            MagicalPower = Hero.randomValues.Next(1, 6);
        }

        // Methods
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Magical item: {_magicalItem}");
            Console.WriteLine($"Magical poewer: {_magicalPower}");
        }

        public override string ShowExperience()
        {
            return base.ShowExperience().Replace("Hero", "Wirzard");
        }

        public void UseMagicalItem()
        {
            Console.WriteLine($"Uisng magical item {_magicalItem} with magical power {_magicalPower}");
        }
    }
}
