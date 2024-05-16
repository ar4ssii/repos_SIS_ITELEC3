using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Semester { get; set; }
        public bool isOverload { get; set; }

        public Instructors Instructor { get; set; }

        [Display(Name = "Instructors")]
        public int InstructorId { get; set; }

    }
}