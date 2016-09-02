using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IAppoinmentRepository
    {
        object GetAllAppoinment();

        object Delete(int appoinmentId);

        bool insert(appoinment appo);

        object AppoinmentListForDoctor(int employeeId);

        object AppoinmentValiadationForDoctor(int doctorId, string today);

        object AppoinmentListForDoctor(int doctorId, string expectedDate);
    }
}
