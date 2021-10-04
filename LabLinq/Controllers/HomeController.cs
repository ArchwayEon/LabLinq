using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LabLinq.Models;
using LabLinq.Services;
using LabLinq.Models.ViewModels;

namespace LabLinq.Controllers
{
   public class HomeController : Controller
   {
      private IStudentRepository _studentRepo;

      public HomeController(IStudentRepository studentRepo)
      {
         _studentRepo = studentRepo;
      }

      public IActionResult Index()
      {
         var model = new List<StudentListVM>();
         var students = _studentRepo.ReadAll();
         foreach (var student in students)
         {
            var modelItem = new StudentListVM
            {
               ENumber = student.ENumber,
               FullName = $"{student.LastName}, {student.FirstName}",
               CourseGrades = ""
            };
            var courseGradeList = new List<string>();
            foreach (var grade in student.Grades)
            {
               var courseGrade = $"{grade.Course.Code}{grade.Course.Number} {grade.LetterGrade}";
               courseGradeList.Add(courseGrade);
            }
            modelItem.CourseGrades = String.Join(",  ", courseGradeList);
            model.Add(modelItem);
         }
         return View(model);
      }

      public IActionResult Privacy()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
