using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    public interface ILoginRepository
    {

        object GetLogin(string employee_user_name, string employee_password);
    }
}
