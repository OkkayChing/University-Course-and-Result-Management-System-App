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
    public class StudentGateway
    {
        SqlConnection connection = new SqlConnection();
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString;



        public bool IsExistsEmail(string email)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT email from students_tbl WHERE email='" + email + "'";
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

        public string GenerateRegNum(Student student)
        {
            connection.ConnectionString = connectionString;
            string SqlQuery = "SELECT code from Department_tbl WHERE id='" + student.DepartmentId + "'";
            SqlCommand command = new SqlCommand(SqlQuery, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            string departmentName = "";
            while (reader.Read())
            {
                departmentName = reader["code"].ToString();
            }

            reader.Close();
            connection.Close();



            string year = "";
            string[] yearOfReg = student.RegistrationDate.Split('/');
            foreach (string i in yearOfReg)
            {
                year = i;
            }

            string regYearAndDepartment = departmentName + "-" + year;
            string checkRegNumQuery =
                "SELECT TOP 1 registration_number FROM students_tbl WHERE registration_number LIKE '" +
                regYearAndDepartment + "%' ORDER BY id DESC ";
            SqlCommand commandforCheckReg = new SqlCommand(checkRegNumQuery, connection);
            connection.Open();
            SqlDataReader readerForCheckReg = commandforCheckReg.ExecuteReader();
            string foundLastReg = "";
            while (readerForCheckReg.Read())
            {
                foundLastReg = readerForCheckReg["registration_number"].ToString();
            }

            reader.Close();
            connection.Close();
            if (foundLastReg != "")
            {



                string lastRegNumber = "";
                string[] id = foundLastReg.Split('-');
                foreach (string ids in id)
                {
                    lastRegNumber = ids;
                }
                int lastRegNumConvert = Convert.ToInt32(lastRegNumber);
                int incrementRegNum = lastRegNumConvert += 1;
                string stringRegNum = incrementRegNum.ToString();
                string generatedRegOfLastContent = "";

                if (stringRegNum.Length == 1)
                {
                    generatedRegOfLastContent = "00" + stringRegNum;
                }
                else if (stringRegNum.Length == 2)
                {
                    generatedRegOfLastContent = "0" + stringRegNum;
                }
                else
                {
                    generatedRegOfLastContent = stringRegNum;
                }
                String genaretedRegNumber = departmentName + "-" + year + "-" + generatedRegOfLastContent;



                return genaretedRegNumber;
            }

            else
            {
                return regYearAndDepartment + "-001";
            }
        
    }
        

      
        //SELECT TOP 1 registration_number FROM student_tbl WHERE registration_number LIKE 'CSE-2016%' ORDER BY id DESC;

        public int Save_Student(Student student, string regNumber)
        {
           
            connection.ConnectionString = connectionString;
            string sqlQuery = "INSERT INTO students_tbl VALUES(@RegNumber,@Name,@Email,@Phone,@Date,@Address,@DepartmentId)";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Clear();

            command.Parameters.Add("RegNumber", SqlDbType.VarChar);
            command.Parameters["RegNumber"].Value =regNumber;

            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = student.Name;

            command.Parameters.Add("Email", SqlDbType.VarChar);
            command.Parameters["Email"].Value = student.Email;

            command.Parameters.Add("Phone", SqlDbType.VarChar);
            command.Parameters["Phone"].Value = student.Phone;


            command.Parameters.Add("Date", SqlDbType.VarChar);
            command.Parameters["Date"].Value = student.RegistrationDate;

            command.Parameters.Add("Address", SqlDbType.NVarChar);
            command.Parameters["Address"].Value = student.Address;

            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = student.DepartmentId;


            connection.Open();
            int isInserted = command.ExecuteNonQuery();
            connection.Close();
            return isInserted;

        }

        public List<Student> GetStudentsRegNumList()
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT registration_number from students_tbl";
            SqlCommand command=new SqlCommand(sqlQuery,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Student> studentRegNumList=new List<Student>();
            while (reader.Read())
            {
               Student regNumList=new Student
                {
                    RegistrationNumber = reader["registration_number"].ToString()
                };
                studentRegNumList.Add(regNumList);
            }
            reader.Close();
            connection.Close();
            return studentRegNumList;

        } 
    }
}