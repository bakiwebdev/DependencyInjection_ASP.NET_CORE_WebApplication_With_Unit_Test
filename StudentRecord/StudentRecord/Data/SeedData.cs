using StudentRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecord.Data
{
    public class SeedData
    {

        public static void Seed(StudentContext context)
        {
            context.Database.EnsureCreated();

            //Check if any student created in the db
            if(context.Students.Any())
            {
                return; // data already created;
            }

            //else

            var students = new Student[]
            {
                new Student
                {
                    Firstname = "Biruk",
                    Lastname = "Endris"
                },

                new Student
                {
                    Firstname = "Lamrot",
                    Lastname = "Endris"
                }
            };

            foreach(Student s in students)
            {
                context.Students.Add(s);
            }

            context.SaveChanges();
        }
    }
}
