using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Game
{
    internal class Knight : Hero
    {
        // Fields
        private string? _magicalItem;

        // Properties
        public string? MagicalItem
        {
            get => _magicalItem;
            set => _magicalItem = value;
        }

        // Constructors
        public Knight() : base()
        {
            Status = "Low Ranked Knight";
            MagicalItem = "No magical item";
        }
        public Knight(string? name) : base(name)
        {
            Status = "Low Ranked Knight";
            MagicalItem = "No magical item";
        }
        public Knight(string? name, string? magicalItem) : base(name)
        {
            Status = "Low Ranked Knight";
            MagicalItem = magicalItem;
        }

        // Methods
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Magical item: {_magicalItem}");
        }

        public override string ShowExperience()
        {
            CheckForPromotionOrDemotion();
            return base.ShowExperience().Replace("Hero", $"{Status}");
        }

        public void CheckForPromotionOrDemotion()
        {
            Promote();
            Demote();
        }

        public void Promote()
        {
            if (BattlesWon == 3)
            {
                Console.WriteLine($"{Name} has been promoted to high ranked knight!");
                Status = "High Ranked Knight";
            }
        }

        public void Demote()
        {
            if (BattlesWon < 3)
            {
                Status = "Low Ranked Knight";
            }
        }
    }
}
