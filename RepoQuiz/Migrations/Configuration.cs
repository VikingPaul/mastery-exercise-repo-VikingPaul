namespace RepoQuiz.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RepoQuiz.DAL.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RepoQuiz.DAL.StudentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Students.AddOrUpdate(
                x => x.FirstName,
                new Student { FirstName = "Alpha", LastName = "Five", Major = "Pain in the Ass"},
                new Student { FirstName = "Zoro", LastName = "MaskOf", Major = "Slice and Dice"},
                new Student { FirstName = "Pika", LastName = "Chu", Major = "Thunder Mouse"},
                new Student { FirstName = "Beta", LastName = "Ceti", Major = "Letters"},
                new Student { FirstName = "Free", LastName = "Willy", Major = "Theater History"},
                new Student { FirstName = "Friday", LastName = "Saturday", Major = "Day Planning"},
                new Student { FirstName = "Three", LastName = "Hundred", Major = "Spartan History"},
                new Student { FirstName = "Lul", LastName = "Cat", Major = "Memes"},
                new Student { FirstName = "La", LastName = "Tin", Major = "Dead Languages"},
                new Student { FirstName = "Hip", LastName = "Star", Major = "Dumb"}
            );
        }
    }
}
