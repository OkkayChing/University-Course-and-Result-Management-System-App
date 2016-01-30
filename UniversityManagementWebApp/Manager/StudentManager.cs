using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class StudentManager
    {
        StudentGateway studentGateway=new StudentGateway();

        public string GeneratedRegNumber(Student student)
        {
            return studentGateway.GenerateRegNum(student);
        }
        public string Save_Student(Student student,string regNum)
        {
            if (!studentGateway.IsExistsEmail(student.Email))
            {


                if (studentGateway.Save_Student(student, regNum) > 0)
                {
                    return "Registration Completed for : " + student.Name+" Registration Number : "+ regNum;

                }
                else
                {
                    return "Registration are Failed !!!";
                }
            }
            else
            {
                return student.Email + " Is Duplicate Email Address";
            }
        }

        public List<Student> GetStudentRegNumList()
        {
            return studentGateway.GetStudentsRegNumList();
        } 
    }
}