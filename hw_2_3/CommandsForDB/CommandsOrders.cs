using DbModels;
using Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2_3.CommandsForDB
{
    internal class CommandsOrders
    {
        public void Menu()
        {
            bool repeatOrNot = true;

            while (repeatOrNot)
            {
                Console.Write("hi! you can:\n" +
                    "1. add new order to table\n" +
                    "2. read all table\n" +
                    "3. find order with need Id\n" +
                    "4. delete order with need id\n" +
                    "other - back to choosing tables" +
                    "what would you like to choose: ");
                string chosenComand = Console.ReadLine();
                var orderRepo = new OrderRepository();

                if (chosenComand == "1")
                {
                    AddNewOrder(orderRepo);
                }
                else if (chosenComand == "2")
                {
                    ReadAllTable(orderRepo);
                }
                else if (chosenComand == "3")
                {
                    FindNeedOrder(orderRepo);
                }
                else if (chosenComand == "4")
                {
                    DeleteOrder(orderRepo);
                }
                else
                {
                    repeatOrNot = false;
                }
            }
        }

        public void ReadAllTable(OrderRepository orderRepo)
        {
            List<DbOrders> orders = orderRepo.GetOrdersEF();

            foreach (DbOrders order in orders)
            {
                Console.WriteLine($"{order.Id} - {order.ProductId} - {order.PickUpPointId} - {order.UserId} - {order.OrderDate}");
            }
        }

        public void FindNeedOrder(OrderRepository orderRepo)
        {
            Console.Write("Input order Id: ");
            Guid orderId = Guid.Parse(Console.ReadLine());
            DbOrders order = orderRepo.GetOrderEF(orderId);

            if (order != null)
            {
                Console.WriteLine($"{order.Id} - {order.ProductId} - {order.PickUpPointId} - {order.UserId} - {order.OrderDate}");
            }
            else
            {
                Console.WriteLine("no order with such Id");
            }
        }

        public void AddNewOrder(OrderRepository orderRepo)
        {
            DbOrders order = new DbOrders();

            Guid id = Guid.NewGuid();
            order.Id = id;

            Console.Write("Input product id: ");
            Guid productId = Guid.Parse(Console.ReadLine());
            order.ProductId = productId;

            Console.Write("Input pick up point id: ");
            Guid pickUpPointId = Guid.Parse(Console.ReadLine());
            order.PickUpPointId = pickUpPointId;

            Console.Write("Input user id: ");
            Guid userId = Guid.Parse(Console.ReadLine());
            order.UserId = userId;

            DateTime orderDate = DateTime.Now;
            order.OrderDate = orderDate;

            orderRepo.CreateOrder(order);
        }

        public void DeleteOrder(OrderRepository orderRepo)
        {
            Console.Write("Input order Id: ");
            Guid orderId = Guid.Parse(Console.ReadLine());
            DbOrders order = orderRepo.GetOrderEF(orderId);

            if (order != null)
            {
                orderRepo.DeleteOrder(orderId);
            }
            else
            {
                Console.WriteLine("no order with such Id");
            }
        }
    }
}
