using System;
using System.Drawing;
using System.Reflection.Metadata;

namespace hw_2
{
    internal class ReadFile
    {
        const string FILEPATH = "C:\\Users\\yanaz\\OneDrive\\Рабочий стол\\выбирай итмо и не  выбирай вообще\\ланит\\hw_s\\student_school_DO\\hw_2\\dataFiles\\text.txt";

        public void Command()
        {
            int quantityLines = GetAllQuantityLines();
            int n = GetN(quantityLines);
            GetNLines(n);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Would u like to repeat command (y/n): ");
            string ans = Console.ReadLine();

            if (ans == "y")
            {
                Command();
            }
        }

        static int GetAllQuantityLines()
        {
            var file = new StreamReader(FILEPATH).ReadToEnd(); // big string
            //var lines = file.Split(new char[] { '\n' });      // big array
            var lines = file.Split("\n");s
            var count = lines.Length;

            return count;
        }


        static int GetN(int quantity)
        {
            string? strN;
            bool success;
            int parInt;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"input N (from 0 to {quantity}): ");
                strN = Console.ReadLine();
                success = int.TryParse(strN, out parInt);
                if (success && parInt >= 0 && parInt <= quantity)
                {
                    return parInt;
                }
            }
        }

        static void GetNLines(int n)
        {
            var file = new StreamReader(FILEPATH);
            for (int i = 0; i < n; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(file.ReadLine());
            }
        }
    }
}