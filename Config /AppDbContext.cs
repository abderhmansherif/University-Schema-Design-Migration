using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using App.Entites;
using Microsoft.Extensions.Configuration;
using App.config;

namespace App.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Instructor> Instructors {get; set;}
        public DbSet<Course> Courses {get; set;}
        public DbSet<Office> Offices { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SectionsSchedule> SectionsSchedule { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder()
                .AddJsonFile(@"D:\EF.NET\Migration02\appsettings.json")
                .Build();
            
            var ConnectionString = config.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);
        }
    }
}
