using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    
    public class CourseStaticsManager
    {
        CourseStaticsGateway courseStaticsGateway=new CourseStaticsGateway();

        public List<CourseStatics> GetCourseStaticsesByDepartmentId(int departmentId)
        {
            return courseStaticsGateway.GetCourseStaticsesByDepartment(departmentId);
        }
    }
}