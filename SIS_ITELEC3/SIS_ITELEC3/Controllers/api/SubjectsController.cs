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
    public class SubjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public SubjectsController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpGet]
        public IHttpActionResult GetSubjects()
        {
            var subjectDto = _context.Subjects
                .Include(s => s.Instructor)
                .ToList()
                .Select(Mapper.Map<Subjects, SubjectsDto>);
            return Ok(subjectDto);
        }

        [HttpGet]
        public IHttpActionResult GetSubject(int id)
        {
            var subject = _context.Subjects.SingleOrDefault(s => s.Id == id);
            if (subject == null)
                return NotFound();
            var subjectDto = Mapper.Map<Subjects, SubjectsDto>(subject);
            return Ok(subjectDto);
        }

        [HttpPost]
        public IHttpActionResult CreateSubject(SubjectsDto subjectDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var subject = Mapper.Map<SubjectsDto, Subjects>(subjectDto);

            _context.Subjects.Add(subject);
            _context.SaveChanges();

            subjectDto.Id = subject.Id;

            return Created(new Uri(Request.RequestUri + "/" + subject.Id), subjectDto);
        }

        [HttpPut]
        public void UpdateSubject(int id, SubjectsDto subjectDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var subjectInDb = _context.Subjects.SingleOrDefault(s => s.Id == id);

            if (subjectInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(subjectDto, subjectInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteSubject(int id)
        {
            var subjectInDB = _context.Subjects.SingleOrDefault(s => s.Id == id);
            if (subjectInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Subjects.Remove(subjectInDB);
            _context.SaveChanges();
        }
    }
}
