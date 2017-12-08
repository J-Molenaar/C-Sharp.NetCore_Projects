using System;
using System.Collections.Generic;

namespace _02_Collections
{
    class Program
    {
        static void Main(string[] args)
        { //start code
        // //1. Create an array to hold integer values 0 through 9
        //     int[] numArray;
        //     numArray = new int[] {0,1,2,3,4,5,6,7,8,9,};
        //     Console.WriteLine(numArray[4]);

        // //2. Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
        //     string[] nameArray;
        //     nameArray = new string[]{"Tim", "Martin", "Nikki", "Sarah"};
        //     Console.WriteLine(String.Join(", ", nameArray));
        // //3. Create an array of length 10 that alternates between true and false values, starting with true
        //     bool[] tfArray = new bool[10];
        //     for (int i = 0; i<10; i++){
        //         if (i%2==0){
        //             tfArray[i] = true;
        //         }
        //         else{
        //             tfArray[i] = false;
        //         }
        //     }
        //     System.Console.WriteLine(String.Join(", ", tfArray));
        //3. With the values 1-10, use code to generate a multiplication table
            int[,] multTable = new int[10,10];
            for (int i=0; i<10; i++)
            {
                for(int j = 0 ; j <10; j++)
                {
                    multTable[i, j] = (i+1)*(j+1);
                }
            }
            for (int i=0; i<10; i++)
            {
                for(int j = 0 ; j <10; j++)
                {
                    System.Console.Write(string.Format("{0, -3}", multTable[i,j]));
                }
                System.Console.WriteLine();
            }

        
        // //4.  List of Ice Cream flavors that holds at least 5 different flavors: print length of list, print 3rd flavor, remove 3rd, print length again
        //     List<string> iceCream = new List<string>();
        //     iceCream.Add("Vanilla");
        //     iceCream.Add("Chocolate");
        //     iceCream.Add("Hazelnut");
        //     iceCream.Add("Mint & Chip");
        //     iceCream.Add("Rockey Road");
        //     System.Console.WriteLine(String.Join(", ", iceCream));
        //     System.Console.WriteLine(iceCream.Count);
        //     System.Console.WriteLine(iceCream[3]);
        //     iceCream.RemoveAt(3);
        //     System.Console.WriteLine(iceCream.Count);
        // //5.  Create a dictionary using names and icecream flavors
        //     Dictionary<string, string> nameFlavor= new Dictionary<string, string>();
        //     Random rand= new Random();
        //     for (int i = 0; i<nameArray.Length;i++){
        //         int x = rand.Next(0,3);
        //         nameFlavor.Add(nameArray[i], iceCream[x]);
        //     }
        //     foreach(var entry in nameFlavor){
        //     System.Console.WriteLine(entry.Key + ": " + entry.Value);
        //     }
        } //end code
    }
}
