using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class CourseStaticsGateway
    {
        SqlConnection connection = new SqlConnection();
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString;

        public List<CourseStatics> GetCourseStaticsesByDepartment(int departmentId)
        {
      
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT * FROM CourseStatics WHERE department_id='"+departmentId+"'";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<CourseStatics> courseStaticsList = new List<CourseStatics>();
            while (reader.Read())
            {
                CourseStatics courseList = new CourseStatics
                {
                   
                    Code = reader["code"].ToString(),
                    Name = reader["courseName"].ToString(),
                    SemesterId = reader["semester_id"].ToString(),
                    AssignedTo = reader["teachersName"].ToString()

                };

                courseStaticsList.Add(courseList);
            }
            reader.Close();
            connection.Close();
            return courseStaticsList;

       
        } 
        
    }
}