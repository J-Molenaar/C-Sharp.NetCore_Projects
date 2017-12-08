using System;

namespace _07_Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Bob= new Human("Bob", 4, 5, 6, 150 );
            System.Console.WriteLine(Bob.Name);
            Human Tom= new Human("Tom", 4, 5, 6, 150 );
            System.Console.WriteLine(Tom.Name);

            object Dory = "Confused Fish";

            Bob.Attack(Tom, 2);
            System.Console.WriteLine("Tom's health is now {0}.", Tom.Health);
            
            Bob.Attack2(Dory, 2);
            Tom.Attack2(Bob, 3);
        }
    }
}
