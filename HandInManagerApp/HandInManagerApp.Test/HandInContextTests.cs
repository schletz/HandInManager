using HandInManagerApp.Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HandInManagerApp.Test
{
    public class HandInContextTests
    {
        [Fact]
        public void CreateDatabaseSuccessTest()
        {
            var opt = new DbContextOptionsBuilder()
                .UseSqlite("Data Source=HandIn.db")
                .Options;
            using var db = new HandInContext(opt);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            db.Seed();
        }
    }
}
