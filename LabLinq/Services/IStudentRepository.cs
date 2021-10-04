using LabLinq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabLinq.Services
{
   public interface IStudentRepository
   {
      ICollection<Student> ReadAll();
      Student Read(string id);
   }
}
