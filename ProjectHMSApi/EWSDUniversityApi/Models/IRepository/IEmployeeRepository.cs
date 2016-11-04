using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    public interface IEmployeeRepository
    {

        object GetAllEmployee(int hospital_id);


         object Delete(int employee_id);

         bool insert(employee emp);

         bool CheckUsername(string employee_user_name, string empolyee_email);

         bool UpdateEmployee(employee emp);

         bool UpdateFulldataEmployee(employee emp);

         object GetAllEmployeeDoctor(string empStatus, int hospital_id);

         object GetAllDepartmentWiseDoctor(int hospital_id);

         object GetAllDoctorBydepartmentId(int departmentID);

         object GetEmployeeById(int employeeId);

         object GetEmployeeDoctorById(int employeeId);

         bool UpdatePasswordEmployee(StronglyType.PasswordResetModel empPeResetModel);
    }
}
