using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabLinq.Models.Entities
{
   public class StudentCourseGrade
   {
      public int Id { get; set; }
      [StringLength(2)]
      public string LetterGrade { get; set; }
      // Foreign keys and navigation properties
      public int StudentId { get; set; }
      public Student Student { get; set; }
      public int CourseId { get; set; }
      public Course Course { get; set; }
   }
}
