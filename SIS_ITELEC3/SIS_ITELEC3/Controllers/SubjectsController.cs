using SIS_ITELEC3.Models;
using SIS_ITELEC3.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIS_ITELEC3.Controllers
{
    [Authorize]
    public class SubjectsController : Controller
    {
        private ApplicationDbContext _context;

        public SubjectsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Subjects
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageRole))    // Add this
                return View("Index");                        //

            return View("ReadOnlyIndex");
        }

        public ActionResult New()
        {
            var viewModel = new SubjectFormViewModel
            {
                Subject = new Subjects(),
                Instructor = _context.Instructors.ToList()
            };
            return View("SubjectForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var subject = _context.Subjects.SingleOrDefault(s => s.Id == id);

            if (subject == null)
                return HttpNotFound();

            var viewModel = new SubjectFormViewModel
            {
                Subject = subject,
                Instructor = _context.Instructors.ToList()
            };
            return View("SubjectForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Subjects subject)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new SubjectFormViewModel
                {
                    Subject = subject,
                    Instructor = _context.Instructors.ToList()
                };
                return View("SubjectForm", viewModel);   
            }

            if (subject.Id == 0)
            {
                _context.Subjects.Add(subject);
            }
            else
            {
                var subjectInDB = _context.Subjects.Single(s => s.Id == subject.Id);
                subjectInDB.Name = subject.Name;
                subjectInDB.Year = subject.Year;
                subjectInDB.Semester = subject.Semester;
                subjectInDB.isOverload = subject.isOverload;
                subjectInDB.InstructorId = subject.InstructorId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index","Subjects");
        }
    }
}