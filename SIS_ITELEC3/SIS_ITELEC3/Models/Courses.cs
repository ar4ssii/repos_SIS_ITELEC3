using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}