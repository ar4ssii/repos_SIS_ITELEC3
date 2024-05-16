using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIS_ITELEC3.Controllers
{
    public class InstructorController : Controller
    {
        private ApplicationDbContext _context;

        public InstructorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Instructor

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var instructor = new Instructors();
            return View("InstructorForm", instructor);
        }

        public ActionResult Edit(int id)
        {
            var instructor = _context.Instructors.SingleOrDefault(i => i.Id == id);

            if (instructor == null)
                return HttpNotFound();

            return View("InstructorForm", instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(Instructors instructor)
        {
            if (!ModelState.IsValid)
            {
                var instructors = _context.Instructors.ToList();
                return View("InstructorForm", instructors);
            }

            if (instructor.Id == 0)
            {
                _context.Instructors.Add(instructor);
            }
            else
            {
                var instructorInDB = _context.Instructors.Single(i => i.Id == instructor.Id);
                instructorInDB.Name = instructor.Name;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Instructor");
        }
    }
}