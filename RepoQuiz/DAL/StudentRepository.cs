using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoQuiz.Models;

namespace RepoQuiz.DAL
{
    public class StudentRepository
    {
        public StudentRepository()
        {
            Context = new StudentContext();
        }

        public StudentRepository(StudentContext _context)
        {
            Context = _context;
        }

        public StudentContext Context { get; set; }

        public void AddStudent(Student newStudent)
        {
            Context.Students.Add(newStudent);
            Context.SaveChanges();
        }

        public List<Student> GetStudents()
        {
            return Context.Students.ToList<Student>();
        }
    }
}