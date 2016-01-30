using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class CourseStatics
    {
        public string Code { set; get; }
        public string Name { get; set; }
        public string SemesterId { get; set; }
        public string AssignedTo { get; set; }
    }
}