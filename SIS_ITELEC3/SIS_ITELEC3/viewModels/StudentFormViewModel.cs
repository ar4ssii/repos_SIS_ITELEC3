using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.viewModels
{
    public class StudentFormViewModel
    {
        public Students Student { get; set; }
        public IEnumerable<Courses> Course { get; set; }

    public string Title
        {
            get
            {
                if (Student != null && Student.Id != 0)
                    return "Edit Student";

                return "New Student";
            }
        }
    }
}