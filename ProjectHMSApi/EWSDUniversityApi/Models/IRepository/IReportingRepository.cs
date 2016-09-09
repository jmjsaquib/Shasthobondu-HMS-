using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IReportingRepository
    {
        object GetAllPatientInfo(string status);

        object GetAllPatientTrackingByStatus(string track);

        object GetAllTransactionCrystalReport();

        object GetAllDailyTransaction(int departmentId, string today);
    }
}
