using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;

namespace UniversityManagementWebApp.Controllers
{
    public class UnassignAllCourseController : Controller
    {
       CourseAssignManager courseAssignManager=new CourseAssignManager();
        public ActionResult UnAssignAllCourses()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnAssignAllCourses(string i)
        {
            ViewBag.Message = courseAssignManager.UnAssignAllCourse();
            return View();
        }
	}
}