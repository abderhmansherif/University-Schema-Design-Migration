using App.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Data;

namespace App.config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.ToTable("Courses");

            builder.Property(x => x.CourseName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Price).HasColumnType("DECIMAL").HasPrecision(15,2).IsRequired();  

            builder.HasData(LoadCourses());
        }
        
        private List<Course> LoadCourses()
        {
            return new List<Course>()
            {
                new Course(){Id = 1, CourseName = "Mathematics", Price = 34323},
                new Course(){Id = 2, CourseName = "Physics", Price = 3234},
                new Course(){Id = 3, CourseName = "Chemistry", Price = 9584},
                new Course(){ Id = 4, CourseName = "Biology", Price = 4453},
                new Course(){Id = 5, CourseName = "Computer Science", Price = 433322},  
            };
        }
    }
}