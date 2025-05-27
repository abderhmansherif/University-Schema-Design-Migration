using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Entites;

namespace App.config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .IsRequired();

            builder.HasMany(x => x.Sections)
                .WithMany(s => s.Schedules)
                .UsingEntity<SectionsSchedule>(); // the joint entity 

            builder.HasData(LoadSchedules());
            
        }
        
    
        private List<Schedule> LoadSchedules()
        {
            return new List<Schedule>()
            {
                new Schedule() { Id = 1, Title = "Daily", Sun = true, Mon = true, Thu = true, Tue = true, Wed = true, Sat = false, Fri = false},
                new Schedule() { Id = 2, Title = "Weekend", Sun = false, Mon = false, Thu = false, Tue = false, Wed = false, Sat = true, Fri = true},
                new Schedule() { Id = 3, Title = "Compact", Sun = true, Mon = true, Thu = true, Tue = true, Wed = true, Sat = true, Fri = true},

            };
        }
    }
}