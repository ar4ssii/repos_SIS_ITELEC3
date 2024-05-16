using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.Models
{
    public class Grades
    {
        public int Id { get; set; }

        public Students Student { get; set; }

        [Display(Name = "Students")]
        public int StudentId { get; set; }

        public Subjects Subject { get; set; }

        [Display(Name = "Subjects")]
        public int SubjectId { get; set; }

        [RatingRangeValidation]
        public double Rating { get; set; }

    }
}