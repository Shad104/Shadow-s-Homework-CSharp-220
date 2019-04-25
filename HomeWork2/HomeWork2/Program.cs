using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            var HelloPaswords = from user in users
                                where user.Password.Equals("hello")
                                select user;

            Console.WriteLine("All users with the password hello");
            foreach (Models.User u in HelloPaswords)
            {
                Console.WriteLine("Name: {0}  Password: {1}", u.Name, u.Password);
            }

            users.RemoveAll(User => User.Password.Equals(User.Name.ToLower()));

            users.Remove(users.First(User => User.Password.Equals("hello")));

            Console.WriteLine();
            Console.WriteLine("All users after modification");
            foreach (Models.User u in users)
            {
                Console.WriteLine("Name: {0}  Password: {1}", u.Name, u.Password);
            }
            Console.ReadKey();
        }
    }
}
