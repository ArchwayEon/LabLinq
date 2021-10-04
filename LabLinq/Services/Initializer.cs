using LabLinq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabLinq.Services
{
	public class Initializer
	{
		private readonly StudentGradesDbContext _db;

		public Initializer(StudentGradesDbContext db)
		{
			_db = db;
		}

		public void SeedDatabase()
		{
         _db.Database.EnsureCreated();

         // If there are any students then the database is already seeded.
         if (_db.Students.Any()) return;

         var students = new List<Student>
         {
            new Student { ENumber = "E00000001", FirstName = "James", LastName = "Smith" },
            new Student { ENumber = "E00000002", FirstName = "Maria", LastName = "Garcia" },
            new Student { ENumber = "E00000003", FirstName = "Chen", LastName = "Li" },
            new Student { ENumber = "E00000004", FirstName = "Aban", LastName = "Hakim" }
         };

         _db.Students.AddRange(students);
         _db.SaveChanges();

         var courses = new List<Course>
         {
             new Course { Code = "CSCI", Number = "3110", CreditHours = 3 },
             new Course { Code = "CSCI", Number = "1250", CreditHours = 4 },
             new Course { Code = "CSCI", Number = "1260", CreditHours = 4 }
         };

         _db.Courses.AddRange(courses);
         _db.SaveChanges();

         Course csci3110 = _db.Courses
            .FirstOrDefault(c => c.Code == "CSCI" && c.Number == "3110");
         Course csci1250 = _db.Courses
            .FirstOrDefault(c => c.Code == "CSCI" && c.Number == "1250");
         Course csci1260 = _db.Courses
            .FirstOrDefault(c => c.Code == "CSCI" && c.Number == "1260");

         Student james = _db.Students
            .FirstOrDefault(s => s.ENumber == "E00000001");
         Student maria = _db.Students
            .FirstOrDefault(s => s.ENumber == "E00000002");
         Student li = _db.Students
            .FirstOrDefault(s => s.ENumber == "E00000003");
         Student hakim = _db.Students
            .FirstOrDefault(s => s.ENumber == "E00000004");

         james.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "B+",
               Course = csci3110
            }
         );
         james.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "C",
               Course = csci1250
            }
         );

         maria.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "A",
               Course = csci3110
            }
         );
         maria.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "D",
               Course = csci1250
            }
         );
         maria.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "F",
               Course = csci1260
            }
         );

         li.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "A-",
               Course = csci1250
            }
         );

         hakim.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "C+",
               Course = csci3110
            }
         );
         hakim.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "A",
               Course = csci1250
            }
         );
         hakim.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "A",
               Course = csci1260
            }
         );
         _db.SaveChanges();
      }
   }
}
