using System;

namespace Fundamentals_I
{
    class Program //do not delete
    {
        static void Main(string[] args) //do not delete 
        { // Code south of here!
            // for (int i = 1; i < 256; i++)
            // {
            //     Console.WriteLine(i);
            // }
            // for ( int i =1; i<101; i++)
            // {
            //     if ( ((i%3==0) || (i%5==0)) != ((i%3==0)&& (i%5==0)))
            //     {
            //           Console.WriteLine(i);
            //     }
            // }

            //   for ( int i =1; i<101; i++)
            // {
            //     if  ((i%3==0)!= ((i%3==0)&& (i%5==0)))
            //     {
            //         Console.WriteLine("{0} Fizz", i);
            //     }
            //     else if  ((i%5==0)!= ((i%3==0)&& (i%5==0)))
            //     {
            //         Console.WriteLine("{0} Buzz", i);
            //     }
            //     else if ((i%3==0)&& (i%5==0))
            //     {
            //         Console.WriteLine("{0} FizzBuzz", i);
            //     }
                
            // }
            // for (float i =1; i<101; i++)
            // {
            //     if ((i/3==Math.Floor(i/3)) && (i/5==Math.Floor(i/5)))
            //     {
            //         Console.WriteLine("{0} FizzBuzz", i);
            //     }
            //     else if ((i/3!=Math.Floor(i/3)) && (i/5==Math.Floor(i/5)))
            //     {
            //         Console.WriteLine("{0} Buzz", i);
            //     }
            //     else if ((i/3== Math.Floor(i/3)) && (i/5!=Math.Floor(i/5)))
            //     {
            //         Console.WriteLine("{0} Fizz", i);
            //     }
            // }
                Random rand = new Random();
                for (int i = 1; i < 11; i++)
             {
                float x = rand.Next(1,100);
                if ((x/3.0==Math.Floor(x/3.0)) && (x/5.0!=Math.Floor(x/5.0)))
                {
                    Console.WriteLine("{0} FizzBuzz", x);
                }
                else if ((x/3.0!=Math.Floor(x/3.0)) && (x/5.0==Math.Floor(x/5.0)))
                {
                    Console.WriteLine("{0} Buzz", x);
                }
                else if ((x/3.0==Math.Floor(x/3.0)) && (x/5.0!=Math.Floor(x/5.0)))
                {
                    Console.WriteLine("{0} Fizz", x);
                }
                else
                {
                    System.Console.WriteLine(x);
                }
            }
            Console.WriteLine("Hello World!");
        } //Code north of here
    }
}
