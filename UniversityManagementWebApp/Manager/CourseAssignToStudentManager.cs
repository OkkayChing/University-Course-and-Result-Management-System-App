using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class CourseAssignToStudentManager
    {
        CourseAssignToStudentGateway courseAssignToStudentGateway=new CourseAssignToStudentGateway();
        public string SaveAssignCourseToStudent(CourseAssignToStudent courseAssignToStudent)
        {
            if (!courseAssignToStudentGateway.IsTakenCourse(courseAssignToStudent))
            {

                if (courseAssignToStudentGateway.AssignedCourseToStudent(courseAssignToStudent) > 0)
                    {
                        return "Course Enrolled Successfull .";
                    }
                    else
                    {
                        return "Course Enrolled Failled !!!";
                    }
               
            }
            else
            {
                return "Course Is Already Assigned !!!";
            }
        }
    }
}