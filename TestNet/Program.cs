using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNet
{
    class Program
    {
        static void Main(string[] args)
        {
            UserModel userModel = new UserModel();

            foreach (var item in userModel.GetUsers())
            {
                Console.WriteLine(
                    $"ID: {item.IdUser}, \t\n" +
                    $"Nombre: {item.Firstname} \t\n" +
                    $"Apellido: {item.Lastname} \t\n" +
                    $"Fecha Nacimiento: {item.Birthday.ToShortDateString()} \t\n" +
                    $"Genero: {item.Gender} \t\n" +
                    $"CID: {item.Document} \t\n" +
                    $"Dirección: {item.UserAddress} \t\n" +
                    $"Notas: {item.Note} \t\n" + 
                    "-------------------------------------------------"
                    );
            }

            Console.WriteLine("Desea eliminar un usuario?");
            string respuesta = Console.ReadLine();

            if (respuesta.Equals("Yes"))
            {
                Console.WriteLine("Digite el codigo del usuario que desea eliminar");
                int Id = int.Parse(Console.ReadLine());
                userModel.IdUser = Id;
                userModel.DeleteUser();
            }

            Console.ReadLine();
        }
    }
}
