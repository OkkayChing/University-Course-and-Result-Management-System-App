using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class StudentController : Controller
    {

        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();
        public ActionResult Save_Student()
        {
          

            List<Department> departmentsList = departmentManager.GetDepartmentsList();
            return View(departmentsList);

        }

        [HttpPost]
        public ActionResult Save_Student(Student student)
        {
            string regNumber=studentManager.GeneratedRegNumber(student);
            ViewBag.Message = studentManager.Save_Student(student, regNumber);

            List<Department> departmentsList = departmentManager.GetDepartmentsList();
            return View(departmentsList);
           
        }
	}
}