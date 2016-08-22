using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    public interface IEmployeeRepository
    {

         object GetAllEmployee();


         object Delete(int employee_id);

         bool insert(employee emp);

         bool CheckUsername(string employee_user_name, string empolyee_email);

         bool UpdateEmployee(employee emp);

         bool UpdateFulldataEmployee(employee emp);

         object GetAllEmployeeDoctor();
    }
}
