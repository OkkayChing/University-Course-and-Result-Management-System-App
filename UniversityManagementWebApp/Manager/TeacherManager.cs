using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class TeacherManager
    {
        TeacherGatway teacherGatway=new TeacherGatway();

        public string Save_Teacher(Teacher teacher)
        {
            if (!teacherGatway.IsExistsEmail(teacher.Email))
            {


                if (teacherGatway.Save_Teacher(teacher) > 0)
                {
                    return "New Teacher Are Joined Name : " + teacher.Name;

                }
                else
                {
                    return "Teacher are Failed to Save !!!";
                }
            }
            else
            {
                return "Teacher's Email Address Is Duplicate";
            }
        }

        public List<Teacher> GeTeachersByDepartmentId(int departmentId)
        {
            return teacherGatway.GetTeacherByDepartment(departmentId);
        }
    }
}