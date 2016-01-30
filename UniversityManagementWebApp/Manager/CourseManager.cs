using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class CourseManager
    {
        private CourseGateway courseGateway = new CourseGateway();

        public string Save_course(Course course)
        {
            if (!courseGateway.IsCourseCodeExists(course.Code))
            {


                if (!courseGateway.IsCourseNameExis(course.Name))
                {
                    if (courseGateway.Save_Course(course) > 0)
                    {
                        return course.Name + " Course are Saved";
                    }
                    else
                    {
                        return course.Name + " Course are Failed to Save";
                    }
                }
                else
                {
                    return course.Name + " Course Is Duplicate ! Choose another Course Name";
                }
            }
            else
            {
                return course.Code + " Course  Code Is Duplicate ! Choose another  Code";
            }
        }

        public List<Course> GetCourseByDepartmentId(int departmentId)
         {
             return courseGateway.ViewCourseByDepartmentId(departmentId);
        }
        public List<Course> GetCourseNameAndCreditByCourseCode(int courseId)
        {
            return courseGateway.GetCourseNameAndCreditByDepartmentId(courseId);
        }
        public List<Course> GetCourseByStudentEnrolled(string regNum)
        {
            return courseGateway.ViewCourseByStudentEnrolled(regNum);
        }
    }
}
