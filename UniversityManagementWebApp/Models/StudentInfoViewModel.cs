using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class StudentInfoViewModel
    {
        public int DepartmentId { get; set; }
        public string StudentName { get; set; }
        public string DepartmentName { get; set; }
        public string StudentEmail { get; set; }

    }
}