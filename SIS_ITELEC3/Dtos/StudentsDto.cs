using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.Dtos
{
    public class StudentsDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Section { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }

        public CoursesDto Course { get; set; }
    }
}