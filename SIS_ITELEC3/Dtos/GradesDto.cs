using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.Dtos
{
    public class GradesDto
    {
        public int Id { get; set; }

        public StudentsDto Student { get; set; }

        public SubjectsDto Subject { get; set; }

        [Range(1.0, 5.0)]
        public double Rating { get; set; }
    }
}