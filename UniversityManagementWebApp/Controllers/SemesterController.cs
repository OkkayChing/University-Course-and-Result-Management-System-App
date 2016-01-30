using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class SemesterController : Controller
    {

      DepartmentManager departmentManager=new DepartmentManager();

        CourseManager courseManager=new CourseManager();

        TeacherManager teacherManager=new TeacherManager();
        CourseAssignManager courseAssignManager=new CourseAssignManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }


        // -------------for Save a New Department ---------------------
        [HttpPost]
        public ActionResult Save_Department(Department department)
        {
            ViewBag.Message = departmentManager.Save_Department(department);
            return View();
        }

        [HttpGet]
        public ActionResult Save_Department()
        {
            //ViewBag.Message = departmentManager.Save_Department(department);
            return View();
        }

        // -------------for View All Department List ---------------------
        public ActionResult View_Department()
        {
            List<Department> departmentsList = departmentManager.GetDepartmentsList();
            return View(departmentsList);
        }
        
        // -------------for Save a New Course ---------------------
        [HttpGet]
        public ActionResult Save_course()
        {
            List<Department> departmentsList = departmentManager.GetDepartmentsList();
            return View(departmentsList);
        }
        [HttpPost]
        public ActionResult Save_course(Course course)
        {
            ViewBag.Message = courseManager.Save_course(course);
            List<Department> departmentsList = departmentManager.GetDepartmentsList();
            return View(departmentsList);
        }

        // -------------for Save a New Teacher ---------------------

        [HttpGet]
        public ActionResult Save_Teacher()
        {
            List<Department> departmentsList = departmentManager.GetDepartmentsList();
            return View(departmentsList);
        }
        [HttpPost]
        public ActionResult Save_Teacher(Teacher teachers)
        {
            ViewBag.Message = teacherManager.Save_Teacher(teachers);
            List<Department> departmentsList = departmentManager.GetDepartmentsList();
            return View(departmentsList);
        }


        // -------------for Course Asign a Teacher ---------------------

        [HttpGet]
        public ActionResult AssignCourseToTeachers()
        {
            List<Department> departmentsList = departmentManager.GetDepartmentsList();
            return View(departmentsList);
        }
        [HttpPost]
        public ActionResult AssignCourseToTeachers(AssignCourse assignCourse)
        {
            ViewBag.Message = courseAssignManager.SaveAssignCourse(assignCourse);
            List<Department> departmentsList = departmentManager.GetDepartmentsList();
            return View(departmentsList);

        }
        // ------------- End Course Asign a Teacher ---------------------

        public ActionResult About_hacksalsh()
        {
            return View();
        }
        [HttpPost]

        public JsonResult GetTeachersByDepartmentId(int departmentId)
        {

            var getTeachersByDepartmentId = teacherManager.GeTeachersByDepartmentId(departmentId);
            return Json(getTeachersByDepartmentId, JsonRequestBehavior.AllowGet);

        }

        //public JsonResult GetStudentsByDepartmentId(int departmentId)
        //{
        //    var students = GetStudents();
        //    var studentList = students.Where(a => a.DepartmentId == departmentId).ToList();
        //    return Json(studentList, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public JsonResult GetCourseCodeByDepartmentId(int departmentId)
        {
            var getCourseCodeByDepartmentId = courseManager.GetCourseByDepartmentId(departmentId);
            //TempData["getCourseCodeByDepartmentId"] = getCourseCodeByDepartmentId;
            return Json(getCourseCodeByDepartmentId, JsonRequestBehavior.AllowGet);
            
        }
        [HttpPost]
        public JsonResult GetCourseNameAndCreditByCourseId(int courseId)
        {

            var getCourseNameAndCreditByCourseCode = courseManager.GetCourseNameAndCreditByCourseCode(courseId);

            return Json(getCourseNameAndCreditByCourseCode, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetTeachersRemaningCreditAndTotalCredit(int teachersId)
        {

            var getTeachersRemaningCreditAndTotalCredit = courseAssignManager.GetTeachersRemaningCreditAndTotalCredit(teachersId);

            return Json(getTeachersRemaningCreditAndTotalCredit, JsonRequestBehavior.AllowGet);

        }
       

	}
}