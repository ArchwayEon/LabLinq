using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabLinq.Models.Entities
{
   public class Course
   {
      public int Id { get; set; }
      [StringLength(4, MinimumLength = 4)]
      public string Code { get; set; }
      [StringLength(4, MinimumLength = 4)]
      public string Number { get; set; }
      public int CreditHours { get; set; }
      public ICollection<StudentCourseGrade> StudentGrades { get; set; }
         = new List<StudentCourseGrade>();
   }
}
