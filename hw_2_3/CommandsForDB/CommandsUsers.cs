using DbModels;
using Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2_3.CommandsForDB
{
    internal class CommandsUsers
    {
        public void Menu()
        {
            bool repeatOrNot = true;
            while (repeatOrNot)
            {
                Console.Write("hi! you can:\n" +
                    "1. add new user to table\n" +
                    "2. read all table\n" +
                    "3. find user with need Id\n" +
                    "4. update information about user with need id\n" +
                    "5. delete user with need id\n" +
                    "other - back to choosing tables" +
                    "what would you like to choose: ");
                string chosenComand = Console.ReadLine();
                var userRepo = new UserRepository();

                if (chosenComand == "1")
                {
                    AddNewUser(userRepo);
                }
                else if (chosenComand == "2")
                {
                    ReadAllTable(userRepo);
                }
                else if (chosenComand == "3")
                {
                    FindNeedUser(userRepo);
                }
                else if (chosenComand == "4")
                {
                    UpdateUserInfo(userRepo);
                }
                else if (chosenComand == "5")
                {
                    DeleteUser(userRepo);
                }
                else
                {
                    repeatOrNot = false;
                }
            }
        }

        public void ReadAllTable(UserRepository userRepo)
        {
            List<DbUsers> users = userRepo.GetUsersEF();
            Console.WriteLine();
            foreach (DbUsers user in users)
            {
                Console.WriteLine($"{user.Id} - {user.FirstName} - {user.LastName} - {user.CardNumber} - {user.RegistrationDate}");
            }
            Console.WriteLine();
        }

        public void FindNeedUser(UserRepository userRepo)
        {
            Console.Write("Input user Id: ");
            Guid userId = Guid.Parse(Console.ReadLine());
            DbUsers user = userRepo.GetUserEF(userId);

            if (user != null)
            {
                Console.WriteLine($"{user.Id} - {user.FirstName} - " +
                    $"{user.LastName} - {user.CardNumber} - {user.RegistrationDate}");
            }
            else
            {
                Console.WriteLine("no user with such Id");
            }
        }

        public void AddNewUser(UserRepository userRepo)
        {
            DbUsers user = new DbUsers();

            Guid id = Guid.NewGuid();
            user.Id = id;

            Console.Write("Input first name: ");
            string firstName = Console.ReadLine();
            user.FirstName = firstName;

            Console.Write("Input last name: ");
            string lastName = Console.ReadLine();
            user.LastName = lastName;

            string cardNumber = Guid.NewGuid().ToString();
            user.CardNumber = cardNumber;

            DateTime registrationDate = DateTime.Now;
            user.RegistrationDate = registrationDate;

            userRepo.CreateUser(user);
        }

        public void UpdateUserInfo(UserRepository userRepo)
        {
            Console.Write("Input user Id: ");
            Guid userId = Guid.Parse(Console.ReadLine());
            DbUsers user = userRepo.GetUserEF(userId);

            if (user != null)
            {
                Console.Write("input new first name (or leave empty string if no need to change): ");
                string firstName = Console.ReadLine();

                Console.Write("input new last name (or leave empty string if no need to change): ");
                string lastName = Console.ReadLine();

                Console.WriteLine("input new card number (or leave empty string if no need to change): ");
                string cardNumber = Console.ReadLine();

                userRepo.EditUser(userId, firstName, lastName, cardNumber);
            }
            else
            {
                Console.WriteLine("no user with such Id");
            }
        }

        public void DeleteUser(UserRepository userRepo)
        {
            Console.Write("Input user Id: ");
            Guid userId = Guid.Parse(Console.ReadLine());
            DbUsers user = userRepo.GetUserEF(userId);

            if (user != null)
            {
                userRepo.DeleteUser(userId);
            }
            else
            {
                Console.WriteLine("no user with such Id");
            }
        }
    }
}
