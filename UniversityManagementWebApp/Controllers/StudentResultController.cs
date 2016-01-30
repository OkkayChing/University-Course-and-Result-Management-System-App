using System;
using System.Collections.Generic;
using Rotativa;
using System.Linq;
using System.Web;
using System.IO;
using iTextSharp.text;
using itextsharp.pdfa.iTextSharp.text.pdf;


using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class StudentResultController : Controller
    {
        
        StudentManager studentManager=new StudentManager();
        CourseManager courseManager=new CourseManager();
        StudentResultManager studentResultManager=new StudentResultManager();
        public ActionResult SaveResult()
        {
            ViewBag.StudentRegNumList = studentManager.GetStudentRegNumList();
            return View();
        }
        [HttpPost]
        public ActionResult SaveResult(CourseAssignToStudent courseAssignToStudent)
        {
            ViewBag.Message = studentResultManager.SaveStudentResult(courseAssignToStudent);
            ViewBag.StudentRegNumList = studentManager.GetStudentRegNumList();
            return View();
        }
        public JsonResult GetAllCourseByStudentEnrolled(string regNum)
        {
            List<Course> courseList = courseManager.GetCourseByStudentEnrolled(regNum);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewResult()
        {
          
            ViewBag.StudentRegNumList = studentManager.GetStudentRegNumList();
            return View();
        }
        public JsonResult GetStudentResultInfo(string regNum)
        {
            List<StudentResultInfo> studentResultList = studentResultManager.GetStudentResultListByRegNum(regNum);
            return Json(studentResultList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ExportPDF()

        {
            
            ActionAsPdf resultPdf = new ActionAsPdf("GetStudentResultInfo")
            {
                FileName = Server.MapPath("~Content/resultSheet.pdf")
            };
            return resultPdf;

        }


        
	}
}