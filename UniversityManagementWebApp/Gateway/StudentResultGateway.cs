using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class StudentResultGateway
    {
        SqlConnection connection = new SqlConnection();
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString;
        public int SaveStudentResultInCourse(CourseAssignToStudent courseAssignToStudent)
        {

            connection.ConnectionString = connectionString;
            string sqlQuery = "UPDATE StudentTakenCourse SET grade='"+courseAssignToStudent.Grade+"' WHERE student_registration_number='" +
                              courseAssignToStudent.StudentRegNum + "' AND courseId='" + courseAssignToStudent.CourseId +
                              "'";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            int isInserted = command.ExecuteNonQuery();
            connection.Close();
            return isInserted;
        }
        public List<StudentResultInfo> GetStudentResultListByRegNum(string regNum)
        {

            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT c.code AS courseCode,c.Name AS courseName, a.grade  FROM StudentTakenCourse a INNER JOIN courses c ON a.courseId=c.id where a.student_registration_number='"+regNum+"'";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<StudentResultInfo> studentResultList = new List<StudentResultInfo>();
            while (reader.Read())
            {
                StudentResultInfo resultList = new StudentResultInfo
                {

                    Code = reader["courseCode"].ToString(),
                    Name = reader["courseName"].ToString(),
                   Grade = reader["grade"].ToString()

                };

                studentResultList.Add(resultList);
            }
            reader.Close();
            connection.Close();
            return studentResultList;


        } 

    }
}