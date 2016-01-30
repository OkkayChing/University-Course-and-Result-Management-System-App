using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class DepartmentGatway
    {
        SqlConnection connection=new SqlConnection();
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString;

        public bool IsDepartmentCodeExists(string code)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery="SELECT code from Department WHERE code='"+code+"'";
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
        public bool IsDepartmentNameExists(string name)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT name from Department WHERE name='" + name + "'";
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
        public int Save_Department(Department department)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery="INSERT INTO Department(code,name) VALUES('"+department.Code+"','"+department.Name+"')";
            SqlCommand command=new SqlCommand(sqlQuery,connection);
            connection.Open();
            int isInserted = command.ExecuteNonQuery();
            connection.Close();
            return isInserted;
        }

        public List<Department> VieDepartments()
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT * FROM Department";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Department> departmentsList=new List<Department>();
            while (reader.Read())
            {
                Department departments = new Department
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Code = reader["code"].ToString(),
                    Name = reader["name"].ToString()

                };

                departmentsList.Add(departments);
            }
            reader.Close();
            connection.Close();
            return departmentsList;

        }
        public object GetStudentInfoByStudentREgNum(string regNum)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT a.name AS studentName,a.email,b.id,b.name as DepartmentName FROM students a INNER JOIN Department_tbl b ON a.departmentId=b.id where a.registration_number='" + regNum + "'";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StudentInfoViewModel studentInfo = new StudentInfoViewModel();
            while (reader.Read())
            {

                studentInfo.StudentName = reader["studentName"].ToString();
                studentInfo.StudentEmail = reader["email"].ToString();
                studentInfo.DepartmentName = reader["DepartmentName"].ToString();
                studentInfo.DepartmentId = Convert.ToInt32(reader["id"]);
            };
            reader.Close();
            connection.Close();
            return studentInfo;
        }
        public int GetDepartmentIdByStudentREgNum(string regNum)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT b.id FROM students a INNER JOIN Department b ON a.departmentId=b.id where a.registration_number='" + regNum + "'";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            int departmentId = 0;
            while (reader.Read())
            {

              
               departmentId = Convert.ToInt32(reader["id"]);
            };
            reader.Close();
            connection.Close();
            return departmentId;
        }
      

    }
}