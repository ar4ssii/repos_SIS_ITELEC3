using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIS_ITELEC3.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private ApplicationDbContext _context;

        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Courses
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageRole))    // Add this
                return View("Index");                        //

            return View("ReadOnlyIndex");
        }

        public ActionResult New()
        {
            var course = new Courses();
            return View("CourseForm", course);
        }

        public ActionResult Edit(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null)
                return HttpNotFound();

            return View("CourseForm", course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(Courses course)
        {
            if (!ModelState.IsValid)
            {
                var courses = _context.Courses.ToList();
                return View("CourseForm", courses);
            }

            if (course.Id == 0)
            {
                _context.Courses.Add(course);
            }
            else
            {
                var courseInDB = _context.Courses.Single(c => c.Id == course.Id);
                courseInDB.Name = course.Name;
                courseInDB.Description = course.Description;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Courses");
        }
    }
}