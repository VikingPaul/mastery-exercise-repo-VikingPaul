using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;
using RepoQuiz.Models;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class StudentRepositoryTests
    {

        Mock<StudentContext> moq_context { get; set; }
        Mock<DbSet<Student>> moq_author { get; set; }
        List<Student> student_list { get; set; }
        StudentRepository repo { get; set; }

        public void ConnectMockToData()
        {
            var queryList = student_list.AsQueryable();
            moq_author.As<IQueryable<Student>>().Setup(x => x.Provider).Returns(queryList.Provider);
            moq_author.As<IQueryable<Student>>().Setup(x => x.Expression).Returns(queryList.Expression);
            moq_author.As<IQueryable<Student>>().Setup(x => x.ElementType).Returns(queryList.ElementType);
            moq_author.As<IQueryable<Student>>().Setup(x => x.GetEnumerator()).Returns(() => queryList.GetEnumerator());
            moq_context.Setup(x => x.Students).Returns(moq_author.Object);
            moq_author.Setup(x => x.Add(It.IsAny<Student>())).Callback((Student x) => student_list.Add(x));
        }

        [TestInitialize]
        public void init()
        {
            moq_context = new Mock<StudentContext>();
            moq_author = new Mock<DbSet<Student>>();
            student_list = new List<Student>();
            ConnectMockToData();
            repo = new StudentRepository(moq_context.Object);
        }
        [TestMethod]
        public void CanMakeStudentClass()
        {
            StudentRepository stud = new StudentRepository();
            Assert.IsNotNull(stud);
        }

        [TestMethod]
        public void RepoHasContext()
        {
            StudentRepository repo = new StudentRepository();
            StudentContext context = repo.Context;
            Assert.IsInstanceOfType(context, typeof(StudentContext));
        }
        [TestMethod]
        public void RepoNoAuthors()
        {
            List<Student> authors = repo.GetStudents();
            Assert.AreEqual(0, authors.Count);
        }

        [TestMethod]
        public void CanAddStudents()
        {
            Student newStudent = new Student { FirstName = "Ennie", LastName = "Minnie", Major = "Minnie Mo" };
            repo.AddStudent(newStudent);
            int authors = repo.GetStudents().Count;
            Assert.AreEqual(1, authors);
        }
        [TestMethod]
        public void CanGetStudent()
        {
            Student newStudent = new Student { FirstName = "Ennie", LastName = "Minnie", Major = "Minnie Mo" };
            repo.AddStudent(newStudent);
            int authors = repo.GetStudents().Count;
            Assert.AreEqual(1, authors);
        }
    }
}
