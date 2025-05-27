using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Entites
{
    public class Course
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public decimal Price { get; set; }
        public Instructor? Instructor{ get; set; } // NAV Property
        public List<Section> Sections { get; set; } = new List<Section>();
    }
}
