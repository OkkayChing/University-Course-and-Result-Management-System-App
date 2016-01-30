using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    
    public class StudentResultManager
    {
        StudentResultGateway studentResultGateway=new StudentResultGateway();

        public string SaveStudentResult(CourseAssignToStudent courseAssignToStudent)
        {
            if (studentResultGateway.SaveStudentResultInCourse(courseAssignToStudent)>0)
            {
                return "Resutl Saved Successfull for : " + courseAssignToStudent.StudentRegNum;
            }
            else
            {
                return "Resutl  failled to Saved for : " + courseAssignToStudent.StudentRegNum+" !!!";
                
            }
        }

        public List<StudentResultInfo> GetStudentResultListByRegNum(string regNum)
        {
            return studentResultGateway.GetStudentResultListByRegNum(regNum);
        }




    }
}