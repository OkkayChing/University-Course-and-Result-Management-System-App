using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class AssignCourse
    {
        public int Id { get; set; }
        public int TeachersId { get; set; }
        public int DepartmentId { get; set; }
        public decimal TakenCredit { get; set; }
        public decimal RemainingCredit { get; set; }
        public int CourseId{ get; set; }
        public decimal CourseCredit { get; set; }


    }
}