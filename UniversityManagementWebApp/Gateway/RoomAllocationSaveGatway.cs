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
    public class RoomAllocationSaveGatway
    {
        SqlConnection connection = new SqlConnection();
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString;

        public int SaveRoomAllocte(RoomAllocation roomAllocation)
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "INSERT INTO roomAllocation_tbl VALUES('" + roomAllocation.DepartmentId + "','" + roomAllocation.CourseId + "','" + roomAllocation.RoomNo + "','" + roomAllocation.DayList + "','" + roomAllocation.FromTime + " " + roomAllocation.FromExtension + "','" + roomAllocation.ToTime + " " + roomAllocation.ToExtension + "',1)";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            int isInserted = command.ExecuteNonQuery();
            connection.Close();
            return isInserted;

        }
    }
}