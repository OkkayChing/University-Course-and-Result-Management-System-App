using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class CourseAssignToStudentGateway
    {
        SqlConnection connection = new SqlConnection();
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString;

        public bool IsTakenCourse(CourseAssignToStudent courses)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery =
                "SELECT student_registration_number,courseId FROM StudentTakenCourse WHERE student_registration_number='" +
                courses.StudentRegNum + "' AND courseId='" + courses.CourseId + "'";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
            return false;

            }
        }

        public int AssignedCourseToStudent(CourseAssignToStudent courseAssignToStudent)
        {

            connection.ConnectionString = connectionString;
            string sqlQuery = "INSERT INTO StudentTakenCourse VALUES('" + courseAssignToStudent.StudentRegNum + "','" +
                              courseAssignToStudent.CourseId + "','"+courseAssignToStudent.Date+"','')";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            int isInserted = command.ExecuteNonQuery();
            connection.Close();
            return isInserted;
        }
    }
}