using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class CourseAssignToStudent
    {
        public int CourseId { get; set; }
        public string StudentRegNum { get; set; }

        public string Date { get; set; }
        public string Grade { get; set; }
    }
}