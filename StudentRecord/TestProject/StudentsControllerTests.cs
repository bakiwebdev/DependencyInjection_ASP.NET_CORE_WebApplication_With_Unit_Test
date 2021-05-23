using Microsoft.EntityFrameworkCore;
using StudentRecord.Controllers;
using Microsoft.EntityFrameworkCore;
using StudentRecord.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StudentRecord.Repository;

namespace TestProject
{
    public  class StudentsControllerTests
    {
        private readonly DbContextOptions<StudentContext> dbContextOptions = new
            DbContextOptionsBuilder<StudentContext>()
                .UseInMemoryDatabase(databaseName: "StudentRecord").Options;

        private StudentsController controller;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedData.Seed(new StudentContext(dbContextOptions));
            IStudentRepository repo = new StudentRepository(new StudentContext(dbContextOptions));


            controller = new StudentsController(repo);
        }

        [Test]
        public void Students_Controller_Unit_Test()
        {
            /*Get All Registerd Students*/
            //Arragne
            int count;
            int total = 2;

            //Act
            var studentList = controller.GetStudents();
            count = studentList.Count;

            //Assert
            Assert.AreEqual(total, count);

            /*First student record*/
            //Arrange
            int firstID = 1;

            //Act
            var student1 = controller.GetStudent(firstID);

            //Assert
            Assert.AreEqual(firstID, student1.ID);
            Assert.AreEqual("Biruk", student1.Firstname);
            Assert.AreEqual("Endris", student1.Lastname);

            /*second student record*/
            //Arrange
            int secondID = 2;

            //Act
            var student2 = controller.GetStudent(secondID);

            //Assert
            Assert.AreEqual(secondID, student2.ID);
            Assert.AreEqual("Lamrot", student2.Firstname);
            Assert.AreEqual("Endris", student2.Lastname);
        }
    }
}
