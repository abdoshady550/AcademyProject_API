using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyProject_API.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AcademyProject_API.Model.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instractor> Instractors { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }




    }
}
