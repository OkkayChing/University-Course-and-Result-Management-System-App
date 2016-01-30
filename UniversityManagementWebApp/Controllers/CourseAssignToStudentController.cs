using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class CourseAssignToStudentController : Controller
    {
       StudentManager studentManager=new StudentManager();
        DepartmentManager departmentManager=new DepartmentManager();
        CourseManager courseManager=new CourseManager();
        CourseAssignToStudentManager courseAssignToStudentManager=new CourseAssignToStudentManager();
        public ActionResult CourseAssignToStudents()
        {
            ViewBag.StudentRegNumList = studentManager.GetStudentRegNumList();
            return View();
        }
        [HttpPost]
        public ActionResult CourseAssignToStudents(CourseAssignToStudent courseAssignToStudent)
        {
            ViewBag.Message = courseAssignToStudentManager.SaveAssignCourseToStudent(courseAssignToStudent);
            ViewBag.StudentRegNumList = studentManager.GetStudentRegNumList();
            return View();
        }
        [HttpPost]
        public JsonResult GetDepartmentName(string RegNum)
        {
            var departmentName = departmentManager.GetStudentInfoByStudentREgNum(RegNum);
            return Json(departmentName, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllCourseByStudentRegNum(string RegNum)
        {

            int departmentid = departmentManager.GetDepartmentIdByStudentREgNum(RegNum);
            List<Course> courseList = courseManager.GetCourseByDepartmentId(departmentid);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
	}
}