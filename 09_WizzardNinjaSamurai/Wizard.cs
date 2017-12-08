using System;
using System.Linq;

namespace _09_WizzardNinjaSamurai
{
    public class Wizard : Human{
        public Wizard(string name) : base(name){
            Health = 50;
            Intelligence = 25;
        }
        public void Heal(){
            Health += 10 * Intelligence;
        }
        public void Fireball(Human target){
            Random rand = new Random();
            int damage = rand.Next(20,51);
            target.Health -= damage;
            System.Console.WriteLine("{0} was hit with {2} damange. {0} health is now {1}", target.Name, target.Health, damage);

        }

    }

}