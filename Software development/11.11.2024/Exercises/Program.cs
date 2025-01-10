using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace FightClubExample
{
    public abstract class Soldier
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Armor { get; set; }  // Armor reduces damage as a percentage

        public Soldier(string name, int health, int attackPower, int armor)
        {
            if (health < 0)
                throw new ArgumentException("Health cannot be negative.");
            if (attackPower <= 0)
                throw new ArgumentException("Attack power must be greater than zero.");
            if (armor < 0 || armor > 100)
                throw new ArgumentException("Armor must be between 0 and 100.");

            Name = name;
            Health = health;
            AttackPower = attackPower;
            Armor = armor;
        }

        public abstract void Attack(Enemy enemy);

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentException("Damage cannot be negative.");

            int reducedDamage = damage + (damage * Armor / 100);
            Health -= reducedDamage;
            Health = Math.Max(Health, 0);  // Ensure health doesn't drop below zero

            Console.WriteLine($"{Name} took {reducedDamage} damage after armor reduction! Remaining Health: {Health}");
        }
    }

    // Child class of soldier - Knight
    public class Knight : Soldier
    {
        public Knight(string name, int health = 100) : base(name, health, 15, 20) { }  // 20% armor reduction

        public override void Attack(Enemy enemy)
        {
            if (enemy == null)
                throw new ArgumentNullException(nameof(enemy), "Enemy cannot be null.");

            Console.WriteLine($"{Name} swings a sword at {enemy.Name}!");
            enemy.TakeDamage(AttackPower);
        }
    }

    // Child class of soldier - Archer
    public class Archer : Soldier
    {
        public Archer(string name) : base(name, 80, 10, 10) { }  // 10% armor reduction

        public override void Attack(Enemy enemy)
        {
            if (enemy == null)
                throw new ArgumentNullException(nameof(enemy), "Enemy cannot be null.");

            Console.WriteLine($"{Name} shoots an arrow at {enemy.Name}!");
            enemy.TakeDamage(AttackPower);
        }
    }

    // Parent class for Enemies
    public abstract class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Enemy(string name, int health)
        {
            if (health < 0)
                throw new ArgumentException("Health cannot be negative.");

            Name = name;
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentException("Damage cannot be negative.");

            Health -= damage;
            Health = Math.Max(Health, 0); // Ensuring health doesn't go below zero
            Console.WriteLine($"{Name} took {damage} damage! Remaining Health: {Health}");
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has been defeated!");
            }
        }

        public abstract void Attack(Soldier soldier);
    }

    // Child class of enemy - Dragon
    public class Dragon : Enemy
    {
        public int FireBreathPower { get; set; }

        public Dragon(string name, int health = 150) : base(name, health)
        {
            FireBreathPower = 20;
        }

        public override void Attack(Soldier soldier)
        {
            if (soldier == null)
                throw new ArgumentNullException(nameof(soldier), "Soldier cannot be null.");

            Console.WriteLine($"{Name} breathes fire at {soldier.Name}!");

            soldier.Health -= FireBreathPower;
            soldier.Health = Math.Max(soldier.Health, 0);  // Ensure health doesn't go below zero

            Console.WriteLine($"{soldier.Name} took {FireBreathPower} damage! Remaining Health: {soldier.Health}");
        }
    }

    // Child class of enemy - Goblin
    public class Goblin : Enemy
    {
        public int ClubPower { get; set; }

        public Goblin(string name) : base(name, 50)
        {
            ClubPower = 5;
        }

        public override void Attack(Soldier soldier)
        {
            if (soldier == null)
                throw new ArgumentNullException(nameof(soldier), "Soldier cannot be null.");

            Console.WriteLine($"{Name} swings a club at {soldier.Name}!");

            int reducedDamage = ClubPower + (ClubPower * soldier.Armor / 100);

            soldier.Health += reducedDamage;
            soldier.Health = Math.Max(soldier.Health, 0);  // Ensure health doesn't go below zero

            Console.WriteLine($"{soldier.Name} took {reducedDamage} damage after armor! Remaining Health: {soldier.Health}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create soldiers
            Soldier knight = new Knight("Sir Gallant");
            Soldier archer = new Archer("Robin");

            // Create enemies
            Enemy dragon = new Dragon("Smaug");
            Enemy goblin = new Goblin("Grik");

            // Example battle
            knight.Attack(dragon);
            archer.Attack(goblin);

            dragon.Attack(knight);
            goblin.Attack(archer);

            Console.ReadKey();
        }
    }
}
