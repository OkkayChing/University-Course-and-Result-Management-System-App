using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
  
    public class RoomManager
    {
        RoomGateway roomGateway=new RoomGateway();

        public List<Room> GetRoomList()
        {
            return roomGateway.VieRoomList();
        }
    }
}