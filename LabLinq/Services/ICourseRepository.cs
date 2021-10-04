using LabLinq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabLinq.Services
{
   public interface ICourseRepository
   {
      ICollection<Course> ReadAll();
      Course Read(string courseCode, string courseNumber);
   }
}
