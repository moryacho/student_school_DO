
using Provider;

namespace lesson_30_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new UserRepository();
            Guid userId = Guid.Parse("EDC7B7B3-25BF-4D00-8163-89D37533DB66");
            userRepository.DeleteUser(userId);

            List<DbModels.DbUser> usersList = userRepository.GetUsersEF();
            foreach (DbModels.DbUser userCycle in usersList)
            {
                Console.WriteLine($"{userCycle.Id} - {userCycle.FirstName} - {userCycle.LastName}");
            }
        }
    }
}