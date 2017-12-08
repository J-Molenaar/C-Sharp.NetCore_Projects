using System;
using System.Collections.Generic;


namespace _03_BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        { //start
            List<object> myList = new List<object>();
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add(true);
            myList.Add("chair");
            foreach(object item in myList)
            {
                if(item is int)
                {
                    System.Console.WriteLine("Item {0} is a number", item);
                }
                else if(item is string){
                    System.Console.WriteLine("Item {0} is a string", item);
                }
                else if(item is bool){
                    System.Console.WriteLine("Item {0} is a boolean", item);
                }
            }
            int sum=0;
            foreach(object item in myList)
            {
                if(item is int)
                {
                    int item1 = (int)item;
                    sum = sum + item1;
                    System.Console.WriteLine(sum);
                }
                }
            
        } //end
    }
}
