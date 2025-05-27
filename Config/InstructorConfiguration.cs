using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using App.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            // Set the primary key and disable automatic value generation for the Id field
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            // mapping to table name Instructores
            builder.ToTable("Instructores");

            // set the type varchar to Instructor Name and make it required
            builder.Property(x => x.InstructorName)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(255)
                    .IsRequired();

            // Define the one-to-one relationship between Instructor and Course entities
            builder.HasOne(x => x.Course)
                    .WithOne(c => c.Instructor)
                    .HasForeignKey<Instructor>(x =>x.CourseId)
                    .IsRequired(); // make it required so any instructor must have a course

            // Ensure the foreign key is unique to guarantee that each Instructor is associated with a unique Course
            builder.HasIndex(x => x.CourseId).IsUnique();

            builder.HasOne(x => x.Office)
                .WithOne(o => o.Instructor)
                .HasForeignKey<Instructor>(x => x.OfficeId)
                .IsRequired();
            
            builder.HasIndex(x => x.OfficeId).IsUnique();

            builder.HasData(LoadInstructores());
        }

        private List<Instructor> LoadInstructores()
        {
            return new List<Instructor>()
            {
                new Instructor(){ Id = 1, InstructorName = "Ahmed Abdullah", CourseId = 1, OfficeId = 1},
                new Instructor(){ Id = 2, InstructorName = "Yasmeen Mohammed", CourseId = 2 , OfficeId = 2},
                new Instructor(){ Id = 3, InstructorName = "Khalid Hassan", CourseId = 3 , OfficeId = 3},
                new Instructor(){ Id = 4, InstructorName = "Nadia Ali", CourseId = 4, OfficeId = 4},
                new Instructor(){ Id = 5, InstructorName = "Omar Ibrahim", CourseId = 5 , OfficeId = 5},

            };
        }
    }
}