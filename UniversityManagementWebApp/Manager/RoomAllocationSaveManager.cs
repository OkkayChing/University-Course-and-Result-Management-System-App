using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class RoomAllocationSaveManager
    {
        RoomAllocationSaveGatway roomAllocationSaveGatway=new RoomAllocationSaveGatway();

        public string SaveRoomAllocation(RoomAllocation roomAllocation)
        {
            if (roomAllocationSaveGatway.SaveRoomAllocte(roomAllocation) > 0)
            {
                return "Allocation Successfull .";

            }
            else
            {
                return "Allocation Failed";
            }
        }
        
    }
}