using DbModels;
using Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2_3.CommandsForDB
{
    internal class CommandsProducts
    {
        public void Menu()
        {
            bool repeatOrNot = true;

            while (repeatOrNot)
            {
                Console.Write("hi! you can:\n" +
                    "1. add new product to table\n" +
                    "2. read all table\n" +
                    "3. find product with need Id\n" +
                    "4. update information about product with need id\n" +
                    "5. delete product with need id\n" +
                    "other - back to choosing tables" +
                    "what would you like to choose: ");
                string chosenComand = Console.ReadLine();
                var productRepo = new ProductRepository();

                if (chosenComand == "1")
                {
                    AddNewProduct(productRepo);
                }
                else if (chosenComand == "2")
                {
                    ReadAllTable(productRepo);
                }
                else if (chosenComand == "3")
                {
                    FindNeedProduct(productRepo);
                }
                else if (chosenComand == "4")
                {
                    UpdateProductInfo(productRepo);
                }
                else if (chosenComand == "5")
                {
                    DeleteUser(productRepo);
                }
                else
                {
                    repeatOrNot = false;
                }
            }
        }

        public void ReadAllTable(ProductRepository productRepo)
        {
            List<DbProducts> products = productRepo.GetProductsEF();

            foreach (DbProducts product in products)
            {
                Console.WriteLine($"{product.Id} - {product.Name} - {product.Description} - " +
                    $"{product.ShopId} - {product.QuantityStock} - {product.StockId}");
            }
        }

        public void FindNeedProduct(ProductRepository productRepo)
        {
            Console.Write("Input product Id: ");
            Guid productId = Guid.Parse(Console.ReadLine());
            DbProducts product = productRepo.GetProductEF(productId);

            if (product != null)
            {
                Console.WriteLine($"{product.Id} - {product.Name} - {product.Description} - " +
                    $"{product.ShopId} - {product.QuantityStock} - {product.StockId}");
            }
            else
            {
                Console.WriteLine("no product with such Id");
            }
        }

        public void AddNewProduct(ProductRepository productRepo)
        {
            DbProducts product = new DbProducts();

            Guid id = Guid.NewGuid();
            product.Id = id;

            Console.Write("Input name: ");
            string name = Console.ReadLine();
            product.Name = name;

            Console.Write("Input description: ");
            string description = Console.ReadLine();
            product.Description = description;

            Console.Write("Input shop Id: ");
            Guid shopId = Guid.Parse(Console.ReadLine());
            product.ShopId = shopId;

            Console.Write("Input quantity stock: ");
            int quantityStock = int.Parse(Console.ReadLine());
            product.QuantityStock = quantityStock;

            Console.Write("Input stock Id: ");
            Guid stockId = Guid.Parse(Console.ReadLine());
            product.StockId = stockId;

            productRepo.CreateProduct(product);
        }

        public void UpdateProductInfo(ProductRepository productRepo)
        {
            Console.Write("Input product Id: ");
            Guid userId = Guid.Parse(Console.ReadLine());
            DbProducts user = productRepo.GetProductEF(userId);

            if (user != null)
            {
                Console.Write("input new name (or leave empty string if no need to change): ");
                string name = Console.ReadLine();

                Console.Write("input new description (or leave empty string if no need to change): ");
                string description = Console.ReadLine();

                Console.WriteLine("input new quantity stock (or leave empty string if no need to change): ");
                int quantityStock = int.Parse(Console.ReadLine());

                productRepo.EditProduct(userId, name, description, quantityStock);
            }
            else
            {
                Console.WriteLine("no user with such Id");
            }
        }

        public void DeleteUser(ProductRepository productRepo)
        {
            Console.Write("Input user Id: ");
            Guid productId = Guid.Parse(Console.ReadLine());
            DbProducts product = productRepo.GetProductEF(productId);

            if (product != null)
            {
                productRepo.DeleteProduct(productId);
            }
            else
            {
                Console.WriteLine("no product with such Id");
            }
        }
    }
}