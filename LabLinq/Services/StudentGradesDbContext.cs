using LabLinq.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabLinq.Services
{
   public class StudentGradesDbContext : DbContext
   {
      public StudentGradesDbContext(DbContextOptions options) : base(options)
      {
      }

      public DbSet<Student> Students { get; set; }
      public DbSet<Course> Courses { get; set; }
      public DbSet<StudentCourseGrade> StudentCourseGrades { get; set; }
   }
}
