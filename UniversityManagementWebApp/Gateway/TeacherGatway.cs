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
    public class TeacherGatway
    {
        SqlConnection connection = new SqlConnection();
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString;

        public bool IsExistsEmail(string email)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT email from teachers_tbl WHERE email='" + email + "'";
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

        public int Save_Teacher(Teacher teacher)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "INSERT INTO teachers_tbl VALUES(@Name,@Address,@Email,@Phone,@Designation,@DepartmentId,@TakenCredit)";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Clear();
            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = teacher.Name;

            command.Parameters.Add("Address", SqlDbType.VarChar);
            command.Parameters["Address"].Value = teacher.Address;

            command.Parameters.Add("Email", SqlDbType.VarChar);
            command.Parameters["Email"].Value = teacher.Email;

            command.Parameters.Add("Phone", SqlDbType.VarChar);
            command.Parameters["Phone"].Value = teacher.Phone;

            command.Parameters.Add("Designation", SqlDbType.VarChar);
            command.Parameters["Designation"].Value = teacher.Designation;

            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = teacher.DepartmentId;

            command.Parameters.Add("TakenCredit", SqlDbType.Decimal);
            command.Parameters["TakenCredit"].Value = teacher.TakenCredit;

            connection.Open();
            int isInserted = command.ExecuteNonQuery();
            connection.Close();
            return isInserted;
        }

        public List<Teacher> GetTeacherByDepartment(int departmentId)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT * FROM teachers_tbl WHERE department_id='" + departmentId + "'";
            SqlCommand command=new SqlCommand(sqlQuery,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Teacher> teachersList=new List<Teacher>();
            while (reader.Read())
            {
                Teacher teacher = new Teacher
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString()
                };
                teachersList.Add(teacher);
            }
            return teachersList;
        }
    }
}