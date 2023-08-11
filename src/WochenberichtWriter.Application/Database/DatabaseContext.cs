using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WochenberichtWriter.Data.Entities;

namespace WochenberichtWriter.Application.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<LearnModule> Modules { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
