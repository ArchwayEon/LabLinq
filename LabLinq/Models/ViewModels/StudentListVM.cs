using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LabLinq.Models.ViewModels
{
   public class StudentListVM
   {
      [DisplayName("E-Number")]
      public string ENumber { get; set; }
      [DisplayName("Full Name")]
      public string FullName { get; set; }
      [DisplayName("Courses and Grades")]
      public string CourseGrades { get; set; }
   }
}
