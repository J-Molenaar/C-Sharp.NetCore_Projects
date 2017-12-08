using System;
using System.Linq;

namespace _09_WizzardNinjaSamurai
{
    public class Ninja : Human{
        public Ninja(string name) : base(name){
            Dexterity = 175;
        }
        public void Steal(Human target){
            Health += 10;
            target.Health -= 10;
        }
        public void GetAway(){
            Health -= 15;
        }
    }
}