using System;

namespace _04_Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
           //1)Print 1-255
           //print1to255();
           //2)Print odd numbers between 1-255
           //printodd();
           //3)Print Sum
           //sum();
           //4)Print Array
           int[] array = new int[5];
           int[] array2= {1,2,3,4,5};
           //printArr(array2);
           //5, 6, 11) Print Max, Min, Average
           //printMaxMinAv(array2);
           //7)Array with Odd

           //8)Greater than y

           //9)Square Values

           //10)Eliminate Negative Numbers

           //12)Shifting the values in an array

           //13)Number to String





        }
            public static void print1to255(){
            for (int i = 1; i <=255; i++){
             System.Console.WriteLine(i);
            }
        }
            public static void printodd(){
            for (int i = 1; i <=255; i++){
                if(i%2==1){
                System.Console.WriteLine(i);
                }
            }
        }
            public static void sum(){
            int sum = 0;
            for (int i = 0; i <=255; i++){
                sum = sum + i;
                System.Console.WriteLine(i);
                System.Console.WriteLine(sum);
            }
            }
            public static int[] printArr(int[] arr){
            foreach(int num in arr){
                System.Console.WriteLine(num);
            }
            return arr;
        }
            public static void printMaxMinAv(int[] arr){
                int max = arr[0];
                int min = arr[0];
                int count=0;
                int sum = 0;
            for (int i = 0; i <arr.Length; i++){
                sum = sum + i;
                count ++;
                foreach(int num in arr){
                    if(num>max){
                        max=num;
                    }
                    else if(num<min){
                        min=num;
                    }
                    }
            }
            System.Console.WriteLine(max);
            System.Console.WriteLine(min);
            System.Console.WriteLine(sum/count); 
        } 

    }
}
