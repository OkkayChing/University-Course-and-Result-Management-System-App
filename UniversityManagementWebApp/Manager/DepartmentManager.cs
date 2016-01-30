using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class DepartmentManager
    {
        DepartmentGatway departmentGatway=new DepartmentGatway();

        public string Save_Department(Department department)
        {
            if (!departmentGatway.IsDepartmentCodeExists(department.Code))
            {
                if (!departmentGatway.IsDepartmentNameExists(department.Name))
                {
                    if (departmentGatway.Save_Department(department)>0)
                    {
                        return department.Name+"  Department Save Successfully .";
                    }
                    else
                    {
                        return department.Name + " Department Failed to Save !";
                    }
                }
                else
                {
                    return "Sorry this "+department.Name + " Name Is Duplicate Department Name !";
                }
            }
            else
            {
                return "Sorry this " + department.Code + " Code Is Duplicate Department Code !";
            }
        }

        public List<Department> GetDepartmentsList()
        {
           return departmentGatway.VieDepartments();
        }

        public object GetStudentInfoByStudentREgNum(string regNum)
        {
            return departmentGatway.GetStudentInfoByStudentREgNum(regNum);
        }
        public int GetDepartmentIdByStudentREgNum(string regNum)
        {
            return departmentGatway.GetDepartmentIdByStudentREgNum(regNum);
        }
    }
}