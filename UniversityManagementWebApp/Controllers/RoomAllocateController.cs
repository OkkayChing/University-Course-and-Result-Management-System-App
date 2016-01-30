using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class RoomAllocateController : Controller
    {
        
        DepartmentManager departmentManager=new DepartmentManager();
        CourseManager courseManager=new CourseManager();
        RoomManager roomManager=new RoomManager();
        RoomAllocationSaveManager roomAllocationSaveManager=new RoomAllocationSaveManager();
        public ActionResult RoomAllocation()
        {
            List<Department> departmentsList = departmentManager.GetDepartmentsList();
            List<Room> roomList = roomManager.GetRoomList();
            ViewBag.departmentsList = departmentsList;
            ViewBag.roomList = roomList;
            return View();
        }
        [HttpPost]
        public ActionResult RoomAllocation(RoomAllocation roomAllocation)
        {
            ViewBag.Message = roomAllocationSaveManager.SaveRoomAllocation(roomAllocation);
            List<Department> departmentsList = departmentManager.GetDepartmentsList();
            List<Room> roomList = roomManager.GetRoomList();
            ViewBag.departmentsList = departmentsList;
            ViewBag.roomList = roomList;
            return View();
        }
       
        public JsonResult GetCourseListByDepartmentId(int departmentId)
        {

            var getCourseListByDepartmentId = courseManager.GetCourseByDepartmentId(departmentId);

            return Json(getCourseListByDepartmentId, JsonRequestBehavior.AllowGet);

        }
	}
}