using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
   public interface IDepartmentRepository
    {
        object GetAlldepartmentById(int departmentId);
        List<department> GetAllDepartment(int hospital_id);
        bool InsertDepartment(department oDep);
        bool UpdateDepartment(department oDep);
        bool DeleteDepartment(int departmentId);
        bool CheckDuplicateForDepartmentName(int? department_id, string department_name);
    }
}
