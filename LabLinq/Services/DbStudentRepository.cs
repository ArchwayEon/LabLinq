using LabLinq.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabLinq.Services
{
   public class DbStudentRepository : IStudentRepository
   {
      private readonly StudentGradesDbContext _db;

      public DbStudentRepository(StudentGradesDbContext db)
      {
         _db = db;
      }

      public Student Read(string id)
      {
         return _db.Students
            .Include(s => s.Grades)
            .ThenInclude(scg => scg.Course)
            .FirstOrDefault(s => s.ENumber == id);
      }

      public ICollection<Student> ReadAll()
      {
         return _db.Students
            .Include(s => s.Grades)
            .ThenInclude(scg => scg.Course)
            .ToList();
      }
   }
}
