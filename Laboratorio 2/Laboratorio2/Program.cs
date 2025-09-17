using System;
namespace Laboratori2
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            //ejemplo utilizando las variables de intancia de la clase.
            client.FirstName = "Su_Nombre";
            client.LastName = "Su_apellido";
            client.age = 15;
            client.Id = 1;

            Console.WriteLine(client.GetFullName());

        }
    }



    public class Client

    {
        //declaracion variable de intacia en clase
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int age { get; set; }

        public string GetFullName()
        {
            //utilizando variable de intancia dentro de metodos de la clase
            return FirstName + "" + LastName;
        }
    }
}