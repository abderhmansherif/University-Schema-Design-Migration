using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Entites
{
    public class Section
    {
        public int Id { get; set; }
        public string SectionName { get; set; } = null!;
        public int CourseId { get; set; } // foreign key 
        public Course Course { get; set; } = null!;  // Nav Property

        public int? InstructorId { get; set; } // foreign key
        public Instructor? Instructor { get; set; } // Nav Property

        public List<SectionsSchedule> SectionsSchedules {get; set;} = null!; // Nav Property
        public List<Schedule> Schedules { get; set; } = null!; // Nav Property

        public List<Student> Students { get; set; } = null!;
    }
}