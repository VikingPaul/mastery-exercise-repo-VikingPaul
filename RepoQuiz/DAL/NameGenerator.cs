using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoQuiz.Models;

namespace RepoQuiz.DAL
{
    public class NameGenerator
    {
        private Random randoNumGen = new Random();
        private List<string> firstNames = new List<string>
        {
            "Steve", "Bob", "Goatface", "Joe", "Zoe", "Jess", "Luke", "Kate", "Noni", "Golbat", "Zues", "Piggy", "Miles", "Valentine", "Sister", "Lopez", "Will", "Tucker", "Church", "Caboose", "Griff"
        };
        private List<string> lastNames = new List<string>
        {
            "son", "fury", "lin"
        };
        private List<string> majors = new List<string>
        {
            "BET", "MVC", "ABC", "123", "XYZ", "LOL", "TST"
        };
        // This class should be used to generate random names and Majors for Students.
        // This is NOT your Repository
        // All methods should be Unit Tested :)
        public Student CreateNew()
        {
            Student freak = new Student();
            int randoNum = randoNumGen.Next(21);
            freak.FirstName = firstNames[randoNum];
            int randoNum2 = randoNumGen.Next(21);
            int randoNum3 = randoNumGen.Next(2);
            int randoNum4 = randoNumGen.Next(3);
            string lastName = "";
            if (randoNum3 <= 1)
            {
                lastName = "Mc";
            }
            freak.LastName = lastName + firstNames[randoNum] + lastNames[randoNum4];
            int randoNum5 = randoNumGen.Next(7);
            freak.Major = majors[randoNum5];
            return freak;
        }
    }
}