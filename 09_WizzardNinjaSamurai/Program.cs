using System;

namespace _09_WizzardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Bob = new Human("Bob");
            Wizard Merlin = new Wizard("Merlin");
            Ninja Goku = new Ninja("Goku");
            Samurai Keanu = new Samurai("Keanu");
            Samurai Rohan = new Samurai("Rohan");
            // System.Console.WriteLine("Wizard {0} has intel of {1} and health {2}", Merlin.Name, Merlin.Intelligence, Merlin.Health );
            // Merlin.Heal();
            // System.Console.WriteLine("Wizard {0} has intel of {1} and health {2}", Merlin.Name, Merlin.Intelligence, Merlin.Health );
            // Merlin.Fireball(Bob);
            Goku.Steal(Merlin);
            System.Console.WriteLine("{0} was attacked by {1}. {0} health is now {2} and {1} health is now {3}", Merlin.Name, Goku.Name, Merlin.Health, Goku.Health);
            Keanu.DeathBlow(Goku);

        }
    }
}
