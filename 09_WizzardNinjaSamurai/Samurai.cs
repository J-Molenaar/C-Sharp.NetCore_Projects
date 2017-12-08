using System;
using System.Linq;

namespace _09_WizzardNinjaSamurai
{
    public class Samurai : Human{
        static int numSamurai = 0;
        public Samurai(string name) : base(name){
            Health = 200;
            numSamurai += 1;
            
        }
        public void DeathBlow(Human target){
            if( target.Health <= 50){
                target.Health = 0;
                System.Console.WriteLine("{0} has DIED!", target.Name);
            }
            else{
                System.Console.WriteLine("{0} health is above 50. {0} ducked... You missed. Haha", target.Name);
            }
        }
        public void Meditate(){
            Health = 200;
        }
        public int HowMany(){
            System.Console.WriteLine("There are currently {0}", numSamurai);
            return numSamurai;
            }
            
        }

    }
