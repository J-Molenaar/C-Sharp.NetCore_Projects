using System;
using System.Linq;

namespace _06_PuzzlesREAL
{
    class Program
     {
        static void Main(string[] args) //Main = the name of the function and we are running. Void is the return type which means this function returns nothing. 
        { //Code south of here!

            // Create a function called RandomArray() that returns an integer array
            // Place 10 random integer values between 5-25 into the array Print the min and max values of the array Print the sum of all the values 
            // int[] myRando = RandomArray(); 
            // myRando.Min();
            // myRando.Max();
            // System.Console.WriteLine("The min number is {0} and max is {1}", myRando.Min(), myRando.Max());
            // TossCoin();
            // System.Console.WriteLine(TossMultipleCoins(200));
            System.Console.WriteLine(Names());


        } // Code north of here!
        static int[] RandomArray(){ // function name is RandomArray which is returning int[] array, static              refers to who can call this method
            Random rand= new Random();
            int sum = 0;
            int[] rand_array = new int[10]; 
            for(int i = 0; i<rand_array.Length; i++){
                rand_array[i] = rand.Next(5,26);
                System.Console.WriteLine(rand_array[i]);
                sum = sum + rand_array[i];
            }
            System.Console.WriteLine("The sum is {0}",sum);
            return rand_array;
        } 
        static string TossCoin(Random rand){
            System.Console.WriteLine("Tossing a coin! :) ");
            //         Coin Flip
            // Create a function called TossCoin() that returns a string DONE!
            string result = "TAILS!";
            if (rand.Next(0,2)==1){
                result = "HEADS!";
            }
            System.Console.WriteLine(result);
            return result;


            // Have the function print "Tossing a Coin!"Randomize a coin toss with a result signaling either side of the coin  Have the function print either "Heads" or "Tails" Finally, return the result
        }

        // Create another function called TossMultipleCoins(int num) that returns a Double

        // Have the function call the tossCoin function multiple times based on num value Have the function return a Double that reflects the ratio of head toss to total toss
        static Double TossMultipleCoins(int num){
            int numHeads = 0;
            Random rand = new Random();
            for(int i = 0; i < num; i++){
                if(TossCoin(rand) == "HEADS!"){
                    numHeads++;
                }
            }
            return (Double)numHeads/num;
        }
        static string[] Names(){ //1
            string[] nameArray = new string[5]{"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"}; //2
            string[] longNames = new string[4];
            int lNi = 0;
            for(int i = 0; i<nameArray.Length;i++){ //4
                if(nameArray[i].Length>5){
                    longNames[lNi]=nameArray[i];
                    lNi++;
                }
            }
            Random rnd=new Random();
            string[] MyRandomArray = longNames.OrderBy(x => rnd.Next()).ToArray();
            foreach (string name in MyRandomArray){
                System.Console.WriteLine("THE NAMES ARE LESS THAN 5 AND ÜBER RANDOM {0}", name);
            }
            return MyRandomArray;
            }       
        }

// Names:
// 1) Build a function Names that returns an array of strings

// 2)Create an array with the values: Todd, Tiffany, Charlie, Geneva, Sydney 3)Shuffle the array and print the values in the new order 4)Return an array that only includes names longer than 5 characters
    }