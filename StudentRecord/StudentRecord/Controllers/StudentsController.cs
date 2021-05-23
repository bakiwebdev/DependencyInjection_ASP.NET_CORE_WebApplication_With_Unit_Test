using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRecord.Data;
using StudentRecord.Models;
using StudentRecord.Repository;

namespace StudentRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repo;

        public StudentsController(IStudentRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Students
        [HttpGet]
        public List<Student> GetStudents()
        {
            return _repo.GetAll;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public Student GetStudent(int id)
        {
            var student = _repo.GetStudent(id);

            if (student == null)
            {
                return null;
            }

            return student;
        }

        [HttpPost]
        public void PostStudent(Student student)
        {
            _repo.AddStudent(student);
        }
    }
}
