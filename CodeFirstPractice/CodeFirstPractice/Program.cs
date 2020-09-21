using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CodeFirstPractice.Migrations;
using CodeFirstPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstPractice
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
            Create models and a context for a simple database with the following:
            A table called “Shelves” with:
                An int primary key called ID.
                A varchar of length 50 called Name.
            Use Entity Framework to create a database called “code_first_practice” using your models.
            This must be done in a migration.
            Write a program that will take in a shelf name and add it to the database. For example, CreateShelf(“Games Shelf”) or AddShelf(“Movies Shelf”).
            */

            /*
             * Update your code in Program.cs to include:
                A parameter for “shelfMaterial”
                Ensure the material exists in the “ShelfMaterial” table
                if material does not exist, let the user know and exit.
                “shelfMaterial” parameter should be case insensitive.
                “shelfMaterial” parameter should be trimmed.
                When you add the new shelf, ensure the foreign key for “ShelfMaterial” is populated correctly.
             */

            Console.Write("Please enter the name of the shelf to add: ");
            try
            {
                AddShelf(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Shelf Addition Failed: {e.Message}");
            }

            Console.Write("Please enter the name of the material to add: ");
            // string material = Console.ReadLine();
            try
            {
                AddMaterial(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Material Addition Failed: {e.Message}");
            }

        }
        public static void AddShelf(string name)
        {
            using (ShelvesContext context = new ShelvesContext())
            {
                if (context.Shelves.Where(x => x.Name.ToUpper() == name.Trim().ToUpper()).Count() != 0)
                {
                    throw new Exception("That shelf already exists.");
                }             


            //  context.Shelves.Add(new Shelves() { Name = name.Trim() });
                

               // context.Add(context.ShelfMaterials.Include(b => b.ID));

                var s1 = context.ShelfMaterials.Include(b => b.Shelves).First();
                var s2 = new Shelves { Name = name.Trim() };

                s1.Shelves.Add(s2);

                context.SaveChanges();
                
            }
        }



        public static void AddMaterial(string shelfMaterial)
        {
            using (ShelvesContext context = new ShelvesContext())
            {
                string materialName = shelfMaterial;
                if (context.ShelfMaterials.Where(x => x.MaterialName == materialName.Trim()).Count() != 0)
                {
                    throw new Exception("That material already exists.");
                }
                context.ShelfMaterials.Add(new ShelfMaterials { MaterialName = materialName.Trim() });
                context.SaveChanges();
                Console.WriteLine($"Self MaterialName is {materialName}");
            }
        }

    }
}
