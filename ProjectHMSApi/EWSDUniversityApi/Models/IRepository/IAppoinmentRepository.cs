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

        object insert(StronglyType.AppoinmentValidationModel appo);

        object AppoinmentListForDoctor(int employeeId);

        object AppoinmentValiadationForDoctor(int doctorId, string today);

        object AppoinmentListForDoctor(int doctorId, string expectedDate);
    }
}
