namespace hw_2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("hi! here are comands:\n" +
                "1 - read file\n" +
                "2 - fibonacci numbers\n" +
                "3 - web page's code\n" +
                "4 - db 'Dikie Yagodki'\n" +
                "other - exit\n" +
                "what would you like to choose: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                var readCommand = new ReadFile();
                readCommand.Command();
                Main(args);
            }
            else if (choice == "2")
            {
                var fibonacciComand = new Fibonacci();
                fibonacciComand.Command();
                Main(args);
            }
            else if (choice == "3")
            {
                var webPageCommand = new CodeWebPage();
                webPageCommand.Command();
                Main(args);
            }
            else if (choice == "4")
            {
                var DBCommand = new MenuForDB();
                DBCommand.Menu();
                Main(args);
            }
        }
    }
}