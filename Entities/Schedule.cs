using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Entites
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool Sat { get; set; }
        public bool Sun { get; set; }
        public bool Mon { get; set; }
        public bool Tue { get; set; }
        public bool Wed { get; set; }
        public bool Thu { get; set; }
        public bool Fri { get; set; }

        public List<SectionsSchedule> SectionsSchedule { get; set; } = null!; // Nav Property
        public List<Section> Sections { get; set; } = null!; // Nav Property
    }

}