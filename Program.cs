using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using App.config;
using App.Entites;
using App.Data;
using System.IO.Compression;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var instructor = context.Instructors.Include(x =>x.Office).Include(x => x.Course).FirstOrDefault();

                System.Console.WriteLine($"{instructor!.InstructorName} tech {instructor.Course.CourseName} in {instructor.Office.OfficeName}");
            }   
        }
    }
}