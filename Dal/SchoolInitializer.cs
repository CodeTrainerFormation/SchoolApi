using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class ContextInitializer
    {
        public static void Initialize(this SchoolContext context, bool dropAlways = false)
        {
            //To drop database or not
            if (dropAlways)
                context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            //if db has been already seeded
            if (context.People.Any())
                return;

            #region Classrooms
            var classrooms = new List<Classroom>()
            {
                new Classroom
                {
                    Name = "Salle Bill Gates",
                    Floor = 5,
                    Corridor = "Rouge",
                },
                new Classroom
                {
                    Name = "Salle Satya Nadella",
                    Floor = 2,
                    Corridor = "Jaune",
                },
                new Classroom
                {
                    Name = "Salle Scott Hanselman",
                    Floor = 3,
                    Corridor = "Bleu",
                },
            };
            context.Classrooms.AddRange(classrooms);
            #endregion

            #region Students
            var students = new List<Student>()
            {
                new Student()
                {
                    FirstName = "Ted",
                    LastName = "Mosby",
                    Average = 12.0,
                    IsClassDelegate = false,
                    Age = 32,
                },
                new Student()
                {
                    FirstName = "John",
                    LastName = "Dorian",
                    Average = 19.0,
                    IsClassDelegate = false,
                    Age = 28,
                },
                new Student()
                {
                    FirstName = "Marshall",
                    LastName = "Eriksen",
                    Average = 9.0,
                    IsClassDelegate = false,
                    Age = 30,
                },
                new Student()
                {
                    FirstName = "Robin",
                    LastName = "Scherbatsky",
                    Average = 13.0,
                    IsClassDelegate = false,
                    Age = 38,
                },
                new Student()
                {
                    FirstName = "Lily",
                    LastName = "Aldrin",
                    Average = 14.0,
                    IsClassDelegate = true,
                    Age = 35,
                },
            };

            context.Students.AddRange(students);
            #endregion

            #region Teachers
            var teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    FirstName = "Barney",
                    LastName = "Stinson",
                    Discipline = "Economie",
                    HiringDate = new DateTime(2012, 12, 20),
                    Age = 40,
                    //Salary = 3000,
                },
                new Teacher()
                {
                    FirstName = "Perry",
                    LastName = "Cox",
                    Discipline = "Medecine",
                    HiringDate = new DateTime(2018, 05, 20),
                    Age = 45,
                    //Salary = 2800,
                },
            };
            context.Teachers.AddRange(teachers);
            #endregion

            context.SaveChanges();
        }
    }
}
