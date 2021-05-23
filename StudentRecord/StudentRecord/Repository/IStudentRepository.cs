using StudentRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecord.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAll { get; }
        Student GetStudent(int id);
        void AddStudent(Student student);
    }
}
