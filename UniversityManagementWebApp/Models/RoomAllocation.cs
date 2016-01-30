using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class RoomAllocation
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public string RoomNo { get; set; }
        public string DayList { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string FromExtension { get; set; }
        public string ToExtension { get; set; }
    }
}