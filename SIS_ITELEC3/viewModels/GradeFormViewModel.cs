using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.viewModels
{
    public class GradeFormViewModel
    {
        public Grades Grade { get; set; }
        public IEnumerable<Students> Student { get; set; }
        public IEnumerable<Subjects> Subject { get; set; }

        public string Title
        {
            get
            {
                if (Grade != null && Grade.Id != 0)
                    return "Edit Grade";

                return "Add Grade";
            }
        }
    }
}