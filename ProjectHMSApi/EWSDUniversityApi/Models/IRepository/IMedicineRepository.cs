using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IMedicineRepository
    {
         object GetAllMedicine();

        object GetAllMedicineById(int medicineId);

        bool CheckDuplicateForMedicineName(string p);

        bool InsertMedicine(medicine med);

        bool UpdateMedicine(medicine med);

        bool DeleteMedicine(int p);
    }
}
