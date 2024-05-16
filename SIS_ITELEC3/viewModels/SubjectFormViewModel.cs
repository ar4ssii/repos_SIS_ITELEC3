using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.viewModels
{
    public class SubjectFormViewModel
    {
        public Subjects Subject { get; set; }

        public IEnumerable<Instructors> Instructor { get; set; }

        public string Title
        {
            get
            {
                if (Subject != null && Subject.Id != 0)
                    return "Edit Subject";

                return "New Subject";
            }
        }
    }
}