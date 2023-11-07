using DbModels;
using Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2_3.CommandsForDB
{
    internal class CommandsStocks
    {
        public void Menu()
        {
            bool repeatOrNot = true;

            while (repeatOrNot)
            {
                Console.Write("hi! you can:\n" +
                    "1. add new stock to table\n" +
                    "2. read all table\n" +
                    "3. find stock with need Id\n" +
                    "4. update information about stock with need id\n" +
                    "5. delete stock with need id\n" +
                    "other - back to choosing tables" +
                    "what would you like to choose: ");
                string chosenComand = Console.ReadLine();
                var stockRepo = new StockRepository();

                if (chosenComand == "1")
                {
                    AddNewStock(stockRepo);
                }
                else if (chosenComand == "2")
                {
                    ReadAllTable(stockRepo);
                }
                else if (chosenComand == "3")
                {
                    FindNeedStock(stockRepo);
                }
                else if (chosenComand == "4")
                {
                    UpdateStockInfo(stockRepo);
                }
                else if (chosenComand == "5")
                {
                    DeleteStock(stockRepo);
                }
                else
                {
                    repeatOrNot = false;
                }
            }
        }

        public void ReadAllTable(StockRepository stockRepo)
        {
            List<DbStocks> stocks = stockRepo.GetStocksEF();
            foreach (DbStocks stock in stocks)
            {
                Console.WriteLine($"{stock.Id} - {stock.Adress}");
            }
        }

        public void FindNeedStock(StockRepository stockRepo)
        {
            Console.Write("Input stock Id: ");
            Guid stockId = Guid.Parse(Console.ReadLine());
            DbStocks stock = stockRepo.GetStockEF(stockId);

            if (stock != null)
            {
                Console.WriteLine($"{stock.Id} - {stock.Adress}");
            }
            else
            {
                Console.WriteLine("no stock with such Id");
            }
        }

        public void AddNewStock(StockRepository stockRepo)
        {
            DbStocks stock = new DbStocks();

            Guid id = Guid.NewGuid();
            stock.Id = id;

            Console.Write("Input adress: ");
            string adress = Console.ReadLine();
            stock.Adress = adress;

            stockRepo.CreateStock(stock);
        }

        public void UpdateStockInfo(StockRepository stockRepo)
        {
            Console.Write("Input stock Id: ");
            Guid stockId = Guid.Parse(Console.ReadLine());
            DbStocks stock = stockRepo.GetStockEF(stockId);

            if (stock != null)
            {
                Console.Write("input new name (or leave empty string if no need to change): ");
                string name = Console.ReadLine();

                Console.Write("input new adress (or leave empty string if no need to change): ");
                string adress = Console.ReadLine();

                stockRepo.EditStock(stockId, name, adress);
            }
            else
            {
                Console.WriteLine("no stock with such Id");
            }
        }

        public void DeleteStock(StockRepository stockRepo)
        {
            Console.Write("Input stock Id: ");
            Guid stockId = Guid.Parse(Console.ReadLine());
            DbStocks stock = stockRepo.GetStockEF(stockId);

            if (stock != null)
            {
                stockRepo.DeleteStock(stockId);
            }
            else
            {
                Console.WriteLine("no stock with such Id");
            }
        }
    }
}
