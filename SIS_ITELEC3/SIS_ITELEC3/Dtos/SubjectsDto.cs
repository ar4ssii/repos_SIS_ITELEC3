using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.Dtos
{
    public class SubjectsDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Semester { get; set; }
        public bool isOverload { get; set; }

        public InstructorsDto Instructor { get; set; }
    }
}