using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Entites;

namespace App.Entites
{
    public class Office 
    {
        public int Id { get; set; }
        public string OfficeName { get; set; } = null!;
        public string OfficeLocation { get; set; } = null!;

        public Instructor? Instructor { get; set; }
    }
}