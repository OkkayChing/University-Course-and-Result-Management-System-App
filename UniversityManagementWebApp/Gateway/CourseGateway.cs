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
    public class CourseGateway
    {
        SqlConnection connection = new SqlConnection();
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString;

        public bool IsCourseNameExis(string name)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT name from courses WHERE name='" + name + "'";
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
        public bool IsCourseCodeExists(string code)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT code from courses WHERE code='" + code + "'";
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
        public int Save_Course(Course course)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "INSERT INTO courses VALUES(@Code,@Name,@Credit,@Description,@DepartmentId,@SemesterId)";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Clear();
            command.Parameters.Add("Code", SqlDbType.VarChar);
            command.Parameters["Code"].Value = course.Code;

            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = course.Name;

            command.Parameters.Add("Credit", SqlDbType.Decimal);
            command.Parameters["Credit"].Value = course.Credit;

            command.Parameters.Add("Description", SqlDbType.VarChar);
            command.Parameters["Description"].Value = course.Description;

            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = course.DepartmentId;

            command.Parameters.Add("SemesterId", SqlDbType.Int);
            command.Parameters["SemesterId"].Value = course.SemesterId;

            connection.Open();
            int isInserted = command.ExecuteNonQuery();
            connection.Close();
            return isInserted;
        }

        public List<Course> ViewCourseByDepartmentId(int departmentId)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT * FROM courses WHERE department_id='" + departmentId + "'";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> CourseList = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    Code = reader["code"].ToString(),

                };

                CourseList.Add(course);
            }
            reader.Close();
            connection.Close();
            return CourseList;

        }
        public List<Course> GetCourseNameAndCreditByDepartmentId(int courseId)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT * FROM courses WHERE id='" + courseId + "'";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> CourseList = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course
                {
                    Name = reader["name"].ToString(),
                    Credit = Convert.ToDecimal(reader["credit"]),
                };

                CourseList.Add(course);
            }
            reader.Close();
            connection.Close();
            return CourseList;

        }

        public List<Course> ViewCourseByStudentEnrolled(string regNum)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery =
                "SELECT a.courseId,c.Name  FROM StudentTakenCourse a INNER JOIN courses c ON a.courseId=c.id where a.student_registration_number='" +
                regNum + "'";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course
                {
                    Id = Convert.ToInt32(reader["courseId"]),
                    Name = reader["name"].ToString(),

                };

                courseList.Add(course);
            }
            reader.Close();
            connection.Close();
            return courseList;

        }
       
    }
}