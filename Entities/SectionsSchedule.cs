using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Entites;

namespace App.Entites
{
    public class SectionsSchedule
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int ScheduleId { get; set; }
        public TimeSpan StartsAt { get; set; }
        public TimeSpan EndsAt { get; set; }

        public Section Section { get; set; } = null!; // Nav Property
        public Schedule Schedule { get; set; } = null!; // Nav Property
    }
}