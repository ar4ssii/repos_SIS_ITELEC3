using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SIS_ITELEC3.Dtos;
using SIS_ITELEC3.Models;

namespace SIS_ITELEC3.Controllers.api
{
    public class CoursesController : ApiController
    {
        private ApplicationDbContext _context;

        public CoursesController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpGet]
        public IHttpActionResult GetCourses()
        {
            var coursesDto = _context.Courses
                .ToList()
                .Select(Mapper.Map<Courses, CoursesDto>);
            return Ok(coursesDto);
        }

        [HttpGet]
        public IHttpActionResult GetCourse(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();
            var courseDto = Mapper.Map<Courses, CoursesDto>(course);
            return Ok(courseDto);
        }

        [HttpPost]
        public IHttpActionResult CreateCourses(CoursesDto courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var course = Mapper.Map<CoursesDto, Courses>(courseDto);

            _context.Courses.Add(course);
            _context.SaveChanges();

            courseDto.Id = course.Id;

            return Created(new Uri(Request.RequestUri + "/" + course.Id), courseDto);
        }

        [HttpPut]
        public void UpdateCourse(int id, CoursesDto courseDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var courseInDb = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (courseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(courseDto, courseInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCourse(int id)
        {
            var courseInDB = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (courseInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Courses.Remove(courseInDB);
            _context.SaveChanges();
        }
    }
}
