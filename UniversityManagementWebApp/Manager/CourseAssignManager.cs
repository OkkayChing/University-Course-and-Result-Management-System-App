using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class CourseAssignManager
    {
        CourseAssignGateway courseAssignGateway=new CourseAssignGateway();

        public object GetTeachersRemaningCreditAndTotalCredit(int id)
        {
            return courseAssignGateway.CheckTeachersCredit(id);
        }

        public string SaveAssignCourse(AssignCourse assignedCourse)
        {
            if (!courseAssignGateway.IsCourseIsAssined(assignedCourse.CourseId))
            {
                if (courseAssignGateway.SaveAssignCourse(assignedCourse)>0)
                {
                    return "New Course are Assigned Into Teacher's ";
                }
                else
                {
                    return "Course Assigned Failed to Teacher's!!! ";
                }
            }
            else
            {
                return "Sorry this Course isn't availeable to Assigned !!! Select Another Course .";
            }
        }

        public string UnAssignAllCourse()
        {
            if (courseAssignGateway.UnAssignAllCourse() > 0)
            {
                return "All Course's Unassign From Teacher's ";
            }
            else
            {
                return "Course's Unassign  Failled From Teacher's";
            }
        }
             
        
    }
}