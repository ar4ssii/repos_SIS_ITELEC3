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
    public class StudentsController : ApiController
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            var studentsDto = _context.Students
                .Include(s => s.Course)
                .ToList()
                .Select(Mapper.Map<Students, StudentsDto>);
            return Ok(studentsDto);
        }

        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            var studentDto = Mapper.Map<Students, StudentsDto>(student);
            return Ok(studentDto);
        }

        [HttpPost]
        public IHttpActionResult CreateStuden(StudentsDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = Mapper.Map<StudentsDto, Students>(studentDto);

            _context.Students.Add(student);
            _context.SaveChanges();

            studentDto.Id = student.Id;

            return Created(new Uri(Request.RequestUri + "/" + student.Id), studentDto);
        }

        [HttpPut]
        public void UpdateStudent(int id, StudentsDto studentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(studentDto, studentInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteStudent(int id)
        {
            var studentInDB = _context.Students.SingleOrDefault(s => s.Id == id);
            if (studentInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Students.Remove(studentInDB);
            _context.SaveChanges();
        }
    }
}
