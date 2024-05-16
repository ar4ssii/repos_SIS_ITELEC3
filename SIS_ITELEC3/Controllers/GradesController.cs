using SIS_ITELEC3.Models;
using SIS_ITELEC3.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIS_ITELEC3.Controllers
{
    public class GradesController : Controller
    {
        private ApplicationDbContext _context;

        public GradesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Grades
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new GradeFormViewModel
            {
                Grade = new Grades(),
                Student = _context.Students.ToList(),
                Subject = _context.Subjects.ToList()
            };
            return View("GradeForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var grade = _context.Grades.SingleOrDefault(g => g.Id == id);

            if (grade == null)
                return HttpNotFound();

            var viewModel = new GradeFormViewModel
            {
                Grade = grade,
                Student = _context.Students.ToList(),
                Subject = _context.Subjects.ToList()
            };
            return View("GradeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Grades grade)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GradeFormViewModel
                {
                    Grade = grade,
                    Student = _context.Students.ToList(),
                    Subject = _context.Subjects.ToList()
                };
                return View("GradeForm", viewModel);
            }

            if (grade.Id == 0)
            {
                _context.Grades.Add(grade);
            }
            else
            {
                var gradeInDB = _context.Grades.Single(g => g.Id == grade.Id);
                gradeInDB.Rating = grade.Rating;
                gradeInDB.StudentId = grade.StudentId;
                gradeInDB.SubjectId = grade.SubjectId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Grades");
        }
    }
}