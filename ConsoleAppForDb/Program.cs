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
                context.Initialize(true);

                var classrooms = context.Classrooms.ToList();

                Console.WriteLine("OKI !!!");
            }
        }
    }
}
