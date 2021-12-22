using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandInManagerApp.Application.Model
{
    public class Team
    {
        public Team(string name, string schoolclass, bool visibility, string? comment = null)
        {
            Name = name;
            Schoolclass = schoolclass;
            Created = DateTime.UtcNow;
            Comment = comment;
            Visibility = visibility;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Team() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
                              // ID: Primary key
                              // int Primary key -> AUTO_INCREMENT
        public int Id { get; protected set; }
        public string Name { get; set; }
        public string Schoolclass { get; set; }
        public DateTime Created { get; protected set; }
        public string? Comment { get; set; }
        public bool Visibility { get; set; }
        public int NameLength => Name.Length;
    }
}
