using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SIS_ITELEC3.Dtos;
using SIS_ITELEC3.Models;
using System.Data.Entity;

namespace SIS_ITELEC3.Controllers.api
{
    public class GradesController : ApiController
    {
        private ApplicationDbContext _context;

        public GradesController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpGet]
        public IHttpActionResult GetGrades()
        {
            var gradesDto = _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .ToList()
                .Select(Mapper.Map<Grades, GradesDto>);
            return Ok(gradesDto);
        }

        [HttpGet]
        public IHttpActionResult GetGrade(int id)
        {
            var grade = _context.Grades.SingleOrDefault(g => g.Id == id);
            if (grade == null)
                return NotFound();
            var gradeDto = Mapper.Map<Grades, GradesDto>(grade);
            return Ok(gradeDto);
        }

        [HttpPost]
        public IHttpActionResult CreateGrade(GradesDto gradeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var grade = Mapper.Map<GradesDto, Grades>(gradeDto);

            _context.Grades.Add(grade);
            _context.SaveChanges();

            gradeDto.Id = grade.Id;

            return Created(new Uri(Request.RequestUri + "/" + grade.Id), gradeDto);
        }

        [HttpPut]
        public void UpdateCourse(int id, GradesDto gradeDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var gradeInDb = _context.Grades.SingleOrDefault(g => g.Id == id);

            if (gradeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(gradeDto, gradeInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteGrades(int id)
        {
            var gradeInDB = _context.Grades.SingleOrDefault(g => g.Id == id);
            if (gradeInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Grades.Remove(gradeInDB);
            _context.SaveChanges();
        }
    }
}
