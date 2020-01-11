using System;
using Domain.Models;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            UserModel userModel = new UserModel();

            foreach (var item in userModel.GetUsers())
            {
                Console.WriteLine(item);
            }
        }
    }
}
