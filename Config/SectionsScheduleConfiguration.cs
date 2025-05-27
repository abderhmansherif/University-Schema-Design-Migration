using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.config
{
    public class SectionsScheduleConfiguration : IEntityTypeConfiguration<SectionsSchedule>
    {
        public void Configure(EntityTypeBuilder<SectionsSchedule> builder)
        {
            builder.ToTable("SectionsSchedules");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne(x => x.Section)
                .WithMany(s => s.SectionsSchedules)
                .HasForeignKey(x => x.SectionId)
                .IsRequired();

            builder.HasOne(x => x.Schedule)
                .WithMany(s => s.SectionsSchedule)
                .HasForeignKey(x => x.ScheduleId)
                .IsRequired();

            builder.Property(x => x.StartsAt)
                .HasColumnType("TIME")
                .IsRequired();

            builder.Property(x => x.EndsAt)
                .HasColumnType("TIME")
                .IsRequired();

            builder.HasData(LoadData());
        }

        private List<SectionsSchedule> LoadData()
        {
            return new List<SectionsSchedule>
        {
            new SectionsSchedule
            {
                Id = 1,
                SectionId = 1,
                ScheduleId = 1,
                StartsAt = TimeSpan.FromHours(8), // 08:00
                EndsAt = TimeSpan.FromHours(10)  // 10:00
            },
            new SectionsSchedule
            {
                Id = 2,
                SectionId = 2,
                ScheduleId = 1,
                StartsAt = TimeSpan.FromHours(8), // 08:00
                EndsAt = TimeSpan.FromHours(10)  // 10:00
            },
            new SectionsSchedule
            {
                Id = 3,
                SectionId = 3,
                ScheduleId = 3,
                StartsAt = TimeSpan.FromHours(10), // 10:00
                EndsAt = TimeSpan.FromHours(15)   // 15:00
            },
            new SectionsSchedule
            {
                Id = 6,
                SectionId = 4,
                ScheduleId = 3,
                StartsAt = TimeSpan.FromHours(10), // 10:00
                EndsAt = TimeSpan.FromHours(15)   // 15:00
            },
            new SectionsSchedule
            {
                Id = 7,
                SectionId = 5,
                ScheduleId = 1,
                StartsAt = TimeSpan.FromHours(10), // 10:00
                EndsAt = TimeSpan.FromHours(12)   // 12:00
            },
             new SectionsSchedule
            {
                Id = 8,
                SectionId = 6,
                ScheduleId = 1,
                StartsAt = TimeSpan.FromHours(10), // 10:00
                EndsAt = TimeSpan.FromHours(12)   // 12:00
            },
             new SectionsSchedule
            {
                Id = 4,
                SectionId = 7,
                ScheduleId = 1,
                StartsAt = TimeSpan.FromHours(10), // 10:00
                EndsAt = TimeSpan.FromHours(12)   // 12:00
            },
            new SectionsSchedule
            {
                Id = 5,
                SectionId = 8,
                ScheduleId = 2,
                StartsAt = TimeSpan.FromHours(16), // 16:00
                EndsAt = TimeSpan.FromHours(18)   // 18:00
            },
            new SectionsSchedule
            {
                Id = 9,
                SectionId = 9,
                ScheduleId = 2,
                StartsAt = TimeSpan.FromHours(16), // 16:00
                EndsAt = TimeSpan.FromHours(18)   // 18:00
            },
            new SectionsSchedule
            {
                Id = 10,
                SectionId = 10,
                ScheduleId = 2,
                StartsAt = TimeSpan.FromHours(16), // 16:00
                EndsAt = TimeSpan.FromHours(18)   // 18:00
            },
            new SectionsSchedule
            {
                Id = 11,
                SectionId = 11,
                ScheduleId = 2,
                StartsAt = TimeSpan.FromHours(9),  // 09:00
                EndsAt = TimeSpan.FromHours(11)   // 11:00
            }
        };

        }
    }
}