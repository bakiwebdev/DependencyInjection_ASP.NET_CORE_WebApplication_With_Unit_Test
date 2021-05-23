using Microsoft.EntityFrameworkCore;
using StudentRecord.Data;
using StudentRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecord.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _dbContext;

        public StudentRepository( StudentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Student> GetAll => _dbContext.Students.ToList();

        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChangesAsync();
        }

        public Student GetStudent(int id)
        {
            var student = _dbContext.Students.Find(id);

            if (student == null)
            {
                return null;
            }

            return student;
        }
    }
}
