using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2_3
{
    internal class MenuForDB
    {
        public void Menu()
        {
            bool repeatOrNot = true;
            while (repeatOrNot)
            {
                Console.Write("hi! Welcome to database 'Dikie Yagodki'!\n" +
                    "You can go to tables and make magic there!\n" +
                    "Let's choose table:\n" +
                    "1. Products\n" +
                    "2. Stocks\n" +
                    "3. Pick up points\n" +
                    "4. Shops\n" +
                    "5. Users\n" +
                    "6. Orders\n" +
                    "other - back to main menu\n" +
                    "what would you like to choose: ");
                string chosenComand = Console.ReadLine();

                if (chosenComand == "1")
                {
                    CommandsForDB.CommandsProducts cmd = new CommandsForDB.CommandsProducts();
                    cmd.Menu();
                }
                else if (chosenComand == "2")
                {
                    CommandsForDB.CommandsStocks cmd = new CommandsForDB.CommandsStocks();
                    cmd.Menu();
                }
                else if (chosenComand == "3")
                {
                    CommandsForDB.CommandsPickUpPoints cmd = new CommandsForDB.CommandsPickUpPoints();
                    cmd.Menu();
                }
                else if (chosenComand == "4")
                {
                    CommandsForDB.CommandsShops cmd = new CommandsForDB.CommandsShops();
                    cmd.Menu();
                }
                else if (chosenComand == "5")
                {
                    CommandsForDB.CommandsUsers cmd = new CommandsForDB.CommandsUsers();
                    cmd.Menu();
                }
                else if (chosenComand == "6")
                {
                    CommandsForDB.CommandsOrders cmd = new CommandsForDB.CommandsOrders();
                    cmd.Menu();
                }
                else
                {
                    repeatOrNot = false;
                }
            }
        }
    }
}
