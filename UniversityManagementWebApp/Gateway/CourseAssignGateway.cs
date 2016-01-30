using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class CourseAssignGateway
    {
        SqlConnection connection = new SqlConnection();
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString;
        public bool IsCourseIsAssined(int courseId)
        {


            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT course_id from assigned_course_tbl WHERE course_id='" + courseId + "' AND status=1";
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

        public object CheckTeachersCredit(int teachersId)
        {
            connection.ConnectionString = connectionString;
           
            string sqlQueryTaknCredit = "SELECT credit  FROM assigned_course_tbl where teachers_id='"+teachersId+"' AND status=1";
            SqlCommand command = new SqlCommand(sqlQueryTaknCredit, connection);
            connection.Open();
            SqlDataReader creditReader = command.ExecuteReader();
            decimal takenCredit = 0;
            
            while (creditReader.Read())
            {
                decimal credit  = Convert.ToDecimal(creditReader["credit"]);
                takenCredit += credit;
            }
            creditReader.Close();
            connection.Close();
            string teachersTotalCredit = "SELECT taken_credit  FROM teachers_tbl where id='" + teachersId + "'";
            SqlCommand command2 = new SqlCommand(teachersTotalCredit, connection);
            connection.Open();
            SqlDataReader creditReaderforTeacher = command2.ExecuteReader();
            decimal takenCreditTotal = 0;
            while (creditReaderforTeacher.Read())
            {
                takenCreditTotal = Convert.ToDecimal(creditReaderforTeacher["taken_credit"]);
            }
            creditReaderforTeacher.Close();
            connection.Close();
            decimal remainingTeachersCredit = takenCreditTotal - takenCredit;
            Teacher teachers = new Teacher
            {
                TakenCredit = takenCreditTotal,
                RemainingCredit = remainingTeachersCredit

            };
            return teachers;

        }
        public int SaveAssignCourse(AssignCourse assignCourse)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "INSERT INTO assigned_course_tbl VALUES(@teachersId,@courseId,@departmentId,@credit,1)";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Clear();
            command.Parameters.Add("teachersId", SqlDbType.Int);
            command.Parameters["teachersId"].Value = assignCourse.TeachersId;

            command.Parameters.Add("courseId", SqlDbType.Int);
            command.Parameters["courseId"].Value = assignCourse.CourseId;

            command.Parameters.Add("departmentId", SqlDbType.Int);
            command.Parameters["departmentId"].Value = assignCourse.DepartmentId;

            command.Parameters.Add("credit", SqlDbType.Decimal);
            command.Parameters["credit"].Value = assignCourse.CourseCredit;

           
            connection.Open();
            int isInserted = command.ExecuteNonQuery();
            connection.Close();
            return isInserted;
        }

        public int UnAssignAllCourse()
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "UPDATE assigned_course_tbl SET status=0 WHERE status= 1";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            int isInserted = command.ExecuteNonQuery();
            connection.Close();
            return isInserted;
            
        }


    }
}