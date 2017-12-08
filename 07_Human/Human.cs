namespace _07_Human
{
    public class Human{
        public string Name{get; set;}
        public int Strength{get; set;}
        public int Intelligence {get; set;}
        public int  Dexterity {get; set;}
        public int Health {get; set;}
        public Human(string name){
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Health = 100;
        
        }
        public Human(string name, int strength, int intel, int dex, int health){
            Name = name;
            Strength = strength;
            Intelligence = intel;
            Dexterity = dex;
            Health = health;
        }
        public void Attack(Human target, int times){
            target.Health -= times*(Strength*5);

        }
        public void Attack2(object target, int times){
            Human enemy = target as Human;
            if (enemy is Human){
                enemy.Health -= 5*Strength*times;
                System.Console.WriteLine("{0} was attacked. Health is now {1}.", enemy.Name, enemy.Health);
            }
            else{
                System.Console.WriteLine("You aren't attacking another human...so stop.");
            }
        }
    }
}
    















