using DbModels;
using Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2_3.CommandsForDB
{
    internal class CommandsShops
    {
        public void Menu()
        {
            bool repeatOrNot = true;
            while (repeatOrNot)
            {
                Console.Write("hi! you can:\n" +
                    "1. add new shop to table\n" +
                    "2. read all table\n" +
                    "3. find shop with need Id\n" +
                    "4. update information about shop with need id\n" +
                    "5. delete shop with need id\n" +
                    "other - back to choosing tables" +
                    "what would you like to choose: ");
                string chosenComand = Console.ReadLine();
                var shopRepo = new ShopRepository();

                if (chosenComand == "1")
                {
                    AddNewShop(shopRepo);
                }
                else if (chosenComand == "2")
                {
                    ReadAllTable(shopRepo);
                }
                else if (chosenComand == "3")
                {
                    FindNeedShop(shopRepo);
                }
                else if (chosenComand == "4")
                {
                    UpdateShopInfo(shopRepo);
                }
                else if (chosenComand == "5")
                {
                    DeleteShop(shopRepo);
                }
                else
                {
                    repeatOrNot = false;
                }
            }
        }

        public void ReadAllTable(ShopRepository shopRepo)
        {
            List<DbShops> shops = shopRepo.GetShopsEF();
            foreach (DbShops shop in shops)
            {
                Console.WriteLine($"{shop.Id} - {shop.Name} - {shop.OwnerInfo} - {shop.RegistrationDate}");
            }
        }

        public void FindNeedShop(ShopRepository shopRepo)
        {
            Console.Write("Input shop Id: ");
            Guid shopId = Guid.Parse(Console.ReadLine());
            DbShops shop = shopRepo.GetShopEF(shopId);

            if (shop != null)
            {
                Console.WriteLine($"{shop.Id} - {shop.Name} - {shop.OwnerInfo} - {shop.RegistrationDate}");
            }
            else
            {
                Console.WriteLine("no shop with such Id");
            }
        }

        public void AddNewShop(ShopRepository shopRepo)
        {
            DbShops shop = new DbShops();

            Guid id = Guid.NewGuid();
            shop.Id = id;

            Console.Write("Input name: ");
            string name = Console.ReadLine();
            shop.Name = name;

            Console.Write("Input owner information: ");
            string ownerInfo = Console.ReadLine();
            shop.OwnerInfo = ownerInfo;

            DateTime registrationDate = DateTime.Now;
            shop.RegistrationDate = registrationDate;

            shopRepo.CreateShop(shop);
        }

        public void UpdateShopInfo(ShopRepository shopRepo)
        {
            Console.Write("Input shop Id: ");
            Guid shopId = Guid.Parse(Console.ReadLine());
            DbShops shop = shopRepo.GetShopEF(shopId);

            if (shop != null)
            {
                Console.Write("input new name (or leave empty string if no need to change): ");
                string name = Console.ReadLine();

                Console.Write("input new owner information (or leave empty string if no need to change): ");
                string ownerInfo = Console.ReadLine();

                shopRepo.EditShop(shopId, name, ownerInfo);
            }
            else
            {
                Console.WriteLine("no shop with such Id");
            }
        }

        public void DeleteShop(ShopRepository shopRepo)
        {
            Console.Write("Input shop Id: ");
            Guid shopId = Guid.Parse(Console.ReadLine());
            DbShops shop = shopRepo.GetShopEF(shopId);

            if (shop != null)
            {
                shopRepo.DeleteShop(shopId);
            }
            else
            {
                Console.WriteLine("no shop with such Id");
            }
        }
    }
}
