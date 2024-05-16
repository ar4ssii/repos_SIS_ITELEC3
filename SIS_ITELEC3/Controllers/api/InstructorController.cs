using AutoMapper;
using SIS_ITELEC3.Dtos;
using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace SIS_ITELEC3.Controllers.api
{
    public class InstructorController : ApiController
    {
        private ApplicationDbContext _context;

        public InstructorController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpGet]
        public IHttpActionResult GetInstructors()
        {
            var instructorsDto = _context.Instructors
                .ToList()
                .Select(Mapper.Map<Instructors, InstructorsDto>);
            return Ok(instructorsDto);
        }

        [HttpGet]
        public IHttpActionResult GetInstructor(int id)
        {
            var instructor = _context.Instructors.SingleOrDefault(i => i.Id == id);
            if (instructor == null)
                return NotFound();
            var instructorDto = Mapper.Map<Instructors, InstructorsDto>(instructor);
            return Ok(instructorDto);
        }

        [HttpPost]
        public IHttpActionResult CreateInstructor(InstructorsDto instructordto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var instructor = Mapper.Map<InstructorsDto, Instructors>(instructordto);

            _context.Instructors.Add(instructor);
            _context.SaveChanges();

            instructordto.Id = instructor.Id;

            return Created(new Uri(Request.RequestUri + "/" + instructor.Id), instructordto);
        }

        [HttpPut]
        public void UpdateInstructor(int id, InstructorsDto instructordto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var instructorInDb = _context.Instructors.SingleOrDefault(i => i.Id == id);

            if (instructorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(instructordto, instructorInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteInstructor(int id)
        {
            var instructorInDB = _context.Instructors.SingleOrDefault(i => i.Id == id);
            if(instructorInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Instructors.Remove(instructorInDB);
            _context.SaveChanges();
        }
    }
}
