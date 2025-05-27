using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Entites
{
    public class Instructor
    {
        public int Id { get; set; }
        public string InstructorName { get; set; } = null!;
        public int CourseId { get; set; } // foreign key 
        public int OfficeId { get; set; }  // foreign key 
        public Course Course { get; set; } = null!; // NAV Property

        public Office Office { get; set; } = null!;// NAV Property
        public List<Section> Sections { get; set; } = new List<Section>();
    }
}