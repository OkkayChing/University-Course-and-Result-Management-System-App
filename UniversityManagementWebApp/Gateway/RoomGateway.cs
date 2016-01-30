using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class RoomGateway
    {
        SqlConnection connection = new SqlConnection();
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString;
        public List<Room> VieRoomList()
        {
            connection.ConnectionString = connectionString;
            string sqlQuery = "SELECT * FROM room_tbl";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Room> roomList = new List<Room>();
            while (reader.Read())
            {
                Room room = new Room
                {
                    Id = Convert.ToInt32(reader["id"]),
                    RoomNo = reader["room_no"].ToString(),
                   

                };

                roomList.Add(room);
            }
            reader.Close();
            connection.Close();
            return roomList;

        }
    }
}