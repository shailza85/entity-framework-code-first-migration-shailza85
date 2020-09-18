using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CodeFirstPractice.Models;

namespace CodeFirstPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ShelvesCodeFirstContext context = new ShelvesCodeFirstContext())
            {
                string shelfName;
                Console.Write("Please enter a Shelf Name: ");
                shelfName = Console.ReadLine().ToLower().Trim();

                CodeFirstShelf name = new CodeFirstShelf();
                name.Name = shelfName;
                context.Add(name);
                context.SaveChanges();

            }
        }
    }
}
