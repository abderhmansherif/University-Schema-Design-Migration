using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using App.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace App.config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.ToTable("Sections");

            builder.Property(x => x.SectionName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(x => x.Course)
                .WithMany(c => c.Sections)
                .HasForeignKey(x => x.CourseId)
                .IsRequired();

            builder.HasOne(x => x.Instructor)
                .WithMany(i => i.Sections)
                .HasForeignKey(x => x.InstructorId)
                .IsRequired(false);


            builder.HasData(LoadSections());
        }
        private List<Section> LoadSections()
        {
            return new List<Section>()
            {
                new Section(){ Id = 1, SectionName = "S_MA1", CourseId = 1, InstructorId = 1},
                new Section(){ Id = 2, SectionName = "S_MA2", CourseId = 1 , InstructorId = 2 },
                new Section(){ Id = 3, SectionName = "S_PH1", CourseId = 2 , InstructorId = 1},
                new Section(){ Id = 4, SectionName = "S_PH2", CourseId = 2 , InstructorId = 3 },
                new Section(){ Id = 5, SectionName = "S_CH2", CourseId = 3 , InstructorId = 2},
                new Section(){ Id = 6, SectionName = "S_CS1", CourseId = 3 , InstructorId = 3},
                new Section(){ Id = 7, SectionName = "S_CS2", CourseId = 4 , InstructorId = 4},
                new Section(){ Id = 8, SectionName = "S_CH1", CourseId = 4 , InstructorId = 5},
                new Section(){ Id = 9, SectionName = "S_CS3", CourseId = 5, InstructorId = 4},
                new Section(){ Id = 10, SectionName = "S_BI1", CourseId = 5, InstructorId = 5},
                new Section(){ Id = 11, SectionName = "S_BI2", CourseId = 5, InstructorId = 4},
            };
        }
    }
}