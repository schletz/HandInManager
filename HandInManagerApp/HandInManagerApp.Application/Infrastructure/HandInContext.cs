using Bogus;
using HandInManagerApp.Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HandInManagerApp.Application.Infrastructure
{
    public class HandInContext : DbContext
    {
        public HandInContext(DbContextOptions opt) : base(opt) { }
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Task> Tasks => Set<Task>();

        public void Seed()
        {
            Randomizer.Seed = new Random(1648);

            var departments = new string[] { "KIF", "AIF", "HIF" };
            var subjects = new string[] { "POS", "DBI", "D", "AM" };

            var teams = new Faker<Team>("de").CustomInstantiator(f =>
            {
                var klasse = $"{f.Random.Int(1, 5)}{f.Random.String2(1, "ABCD")}{f.Random.ListItem(departments)}";
                return new Team(
                    name: $"SJ21/22_{klasse}",
                    schoolclass: klasse,
                    visibility: f.Random.Bool(0.5f),
                    comment: f.Music.Genre().OrDefault(f, 0.25f));  // OrDefault für NULL
            })
            .Generate(10)
            .ToList();
            Teams.AddRange(teams);
            SaveChanges();

            var teachers = new Faker<Teacher>("de").CustomInstantiator(f =>
            {
                var firstname = f.Name.FirstName();
                var lastname = f.Name.LastName();
                return new Teacher(
                    firstname: firstname,
                    lastname: lastname,
                    email: $"{firstname.ToLower()}.{lastname.ToLower()}@spengergasse.at");
            })
            .Generate(10)
            .ToList();
            Teachers.AddRange(teachers);
            SaveChanges();

            var tasks = new Faker<Task>("de").CustomInstantiator(f =>
            {
                return new Task(
                    subject: f.Random.ListItem(subjects),
                    title: f.Commerce.ProductName(),
                    team: f.Random.ListItem(teams),
                    teacher: f.Random.ListItem(teachers),
                    expirationDate: new DateTime(2021, 9, 1).AddSeconds(f.Random.Int(0, 3 * 30 * 86400)),
                    maxPoints: f.Random.Int(16,48).OrNull(f, 0.5f) // OrNull bei Value Types
                    );
            })
            .Generate(40)
            .ToList();
            Tasks.AddRange(tasks);
            SaveChanges();
        }
    }
}
