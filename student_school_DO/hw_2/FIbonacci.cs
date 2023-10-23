using System;
using System.Drawing;
using System.Reflection.Metadata;

namespace hw_2
{
    internal class Fibonacci
    {

        public void Command()
        {
            int n = GetN();
            int res = GetFibonacci(n);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(res);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Would u like to repeat command (y/n): ");
            string ans = Console.ReadLine();
            if (ans == "y")
            {
                Command();
            }
        }


        static int GetFibonacci(int n)
        {
            int[] fibonacciArray = new int[n];
            //0 1 1 2 3 5 8
            fibonacciArray[0] = 0;
            fibonacciArray[1] = 1;
            for (int i = 2; i < n; i++)
            {
                fibonacciArray[i] = fibonacciArray[i - 1] + fibonacciArray[(i - 2)];
            }
            return fibonacciArray[n - 1];
        }

        static int GetN()
        {
            string? strN;
            bool success;
            int parInt;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"input N: ");
                strN = Console.ReadLine();
                success = int.TryParse(strN, out parInt);
                if (success && parInt > 1)
                {
                    return parInt;
                }
            }
        }

    }
}