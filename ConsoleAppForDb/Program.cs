using Dal;
using System;
using System.Linq;

namespace ConsoleAppForDb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SchoolContext context = new SchoolContext())
            {
                //destruction de la database
                context.Database.EnsureDeleted();

                //création de la database
                context.Database.EnsureCreated();


                var classrooms = context.Classrooms.ToList();

                Console.WriteLine("OKI !!!");
            }
        }
    }
}
