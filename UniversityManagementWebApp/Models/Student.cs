using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class Student
    {
        public int id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RegistrationDate { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }

    }
}