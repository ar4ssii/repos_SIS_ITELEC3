using SIS_ITELEC3.Models;
using SIS_ITELEC3.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIS_ITELEC3.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new StudentFormViewModel {
                Student = new Students(),
                Course = _context.Courses.ToList()
            };
            return View("StudentForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var students = _context.Students.SingleOrDefault(s => s.Id == id);
            if (students == null)
                return HttpNotFound();

            var viewModel = new StudentFormViewModel
            {
                Student = students,
                Course = _context.Courses.ToList()
            };
            return View("StudentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Students student)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StudentFormViewModel
                {
                    Student = student,
                    Course = _context.Courses.ToList()
                };
                return View("StudentForm", viewModel);
            }

            if (student.Id == 0)
            {
                _context.Students.Add(student);
            }
            else
            {
                var studentInDB = _context.Students.Single(s => s.Id == student.Id);
                studentInDB.Name = student.Name;
                studentInDB.Address = student.Address;
                studentInDB.Year = student.Year;
                studentInDB.Section = student.Section;
                studentInDB.Age = student.Age;
                studentInDB.Birthdate = student.Birthdate;
                studentInDB.CourseId = student.CourseId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Students");
        }
    }
}