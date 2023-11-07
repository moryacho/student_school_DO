using DbModels;
using Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2_3.CommandsForDB
{
    internal class CommandsPickUpPoints
    {
        public void Menu()
        {
            bool repeatOrNot = true;

            while (repeatOrNot)
            {
                Console.Write("hi! you can:\n" +
                    "1. add new pick up point to table\n" +
                    "2. read all table\n" +
                    "3. find pick up point with need Id\n" +
                    "4. update information about pick up points with need id\n" +
                    "5. delete pick up point with need id\n" +
                    "other - back to choosing tables" +
                    "what would you like to choose: ");
                string chosenComand = Console.ReadLine();
                var pickUpPointRepo = new PickUpPointRepository();

                if (chosenComand == "1")
                {
                    AddNewPickUpPoint(pickUpPointRepo);
                }
                else if (chosenComand == "2")
                {
                    ReadAllTable(pickUpPointRepo);
                }
                else if (chosenComand == "3")
                {
                    FindNeedPickUpPoint(pickUpPointRepo);
                }
                else if (chosenComand == "4")
                {
                    UpdatePickUpPointInfo(pickUpPointRepo);
                }
                else if (chosenComand == "5")
                {
                    DeletePickUpPoint(pickUpPointRepo);
                }
                else
                {
                    repeatOrNot = false;
                }
            }
        }

        public void ReadAllTable(PickUpPointRepository pickUpPointRepo)
        {
            List<DbPickUpPoints> pickUpPoints = pickUpPointRepo.GetPickUpPointsEF();

            foreach (DbPickUpPoints pickUpPoint in pickUpPoints)
            {
                Console.WriteLine($"{pickUpPoint.Id} - {pickUpPoint.Adress}");
            }
        }

        public void FindNeedPickUpPoint(PickUpPointRepository pickUpPointRepo)
        {
            Console.Write("Input pick up point Id: ");
            Guid pickUpPointId = Guid.Parse(Console.ReadLine());
            DbPickUpPoints pickUpPoint = pickUpPointRepo.GetPickUpPointEF(pickUpPointId);

            if (pickUpPoint != null)
            {
                Console.WriteLine($"{pickUpPoint.Id} - {pickUpPoint.Adress}");
            }
            else
            {
                Console.WriteLine("no pick up point with such Id");
            }
        }

        public void AddNewPickUpPoint(PickUpPointRepository pickUpPointRepo)
        {
            DbPickUpPoints pickUpPoint = new DbPickUpPoints();

            Guid id = Guid.NewGuid();
            pickUpPoint.Id = id;

            Console.Write("Input adress: ");
            string adress = Console.ReadLine();
            pickUpPoint.Adress = adress;

            pickUpPointRepo.CreatePickUpPoint(pickUpPoint);
        }

        public void UpdatePickUpPointInfo(PickUpPointRepository pickUpPointRepo)
        {
            Console.Write("Input pick up point Id: ");
            Guid pickUpPointId = Guid.Parse(Console.ReadLine());
            DbPickUpPoints pickUpPoint = pickUpPointRepo.GetPickUpPointEF(pickUpPointId);

            if (pickUpPoint != null)
            {
                Console.Write("input new adress (or leave empty string if no need to change): ");
                string adress = Console.ReadLine();

                pickUpPointRepo.EditPickUpPoint(pickUpPointId, adress);
            }
            else
            {
                Console.WriteLine("no pick up point with such Id");
            }
        }

        public void DeletePickUpPoint(PickUpPointRepository pickUpPointRepo)
        {
            Console.Write("Input pick up point Id: ");
            Guid pickUpPointId = Guid.Parse(Console.ReadLine());
            DbPickUpPoints pickUpPoint = pickUpPointRepo.GetPickUpPointEF(pickUpPointId);

            if (pickUpPoint != null)
            {
                pickUpPointRepo.DeletePickUpPoint(pickUpPointId);
            }
            else
            {
                Console.WriteLine("no pick up point with such Id");
            }
        }
    }
}
