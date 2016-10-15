using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;
using RepoQuiz.Models;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class NameGeneratorTests
    {
        [TestMethod]
        public void CanMakeNameGenerator()
        {
            var NotNull = new NameGenerator();
            Assert.IsNotNull(NotNull);
        }

        [TestMethod]
        public void CanGenerateRandoStudent()
        {
            var RandoName = new NameGenerator();
            Student Name = RandoName.CreateNew();
            Assert.IsNotNull(Name.FirstName);
            Assert.IsNotNull(Name.LastName);
            Assert.IsNotNull(Name.Major);
        }
    }
}
