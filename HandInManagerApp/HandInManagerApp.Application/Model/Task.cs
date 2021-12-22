using System;

namespace HandInManagerApp.Application.Model
{
    public class Task
    {
        public Task(string subject, string title, Team team, Teacher teacher, DateTime expirationDate, int? maxPoints = null)
        {
            Subject = subject;
            Title = title;
            Team = team;
            TeamId = team.Id;
            Teacher = teacher;
            TeacherId = teacher.Id;
            ExpirationDate = expirationDate;
            MaxPoints = maxPoints;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Task() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int Id { get; protected set; }
        public string Subject { get; set; }
        public string Title { get; set; }
        public int TeamId { get; set; }  // PK des Properties Team ist Id --> TeamId
        public Team Team { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int? MaxPoints { get; set; }
    }
}
