using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class CourseStaticsController : Controller
    {
        DepartmentManager departmentManager=new DepartmentManager();
        CourseStaticsManager courseStaticsManager=new CourseStaticsManager();
        public ActionResult CourseStatics()
        {
           List<Department> departmentsList =departmentManager.GetDepartmentsList();
           return View(departmentsList);
        }

        public JsonResult GetCourseStatics(int departmentId)
        {
            var getCourseStatichs = courseStaticsManager.GetCourseStaticsesByDepartmentId(departmentId);
            return Json(getCourseStatichs, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GetCourseCodeByDepartmentId(int departmentId)
        //{
        //    var getCourseCodeByDepartmentId = courseManager.GetCourseByDepartmentId(departmentId);
        //    TempData["getCourseCodeByDepartmentId"] = getCourseCodeByDepartmentId;
        //    return Json(getCourseCodeByDepartmentId, JsonRequestBehavior.AllowGet);

        //}
	}
}