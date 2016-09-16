using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IShiftTypeRepository
    {
        object GetAllShiftType();

        object GetDischarTypeById(int shiftTypeID);

        bool CheckDuplicateForShiftTypeName(StronglyType.ShiftTypeModel shiftType);

        bool InsertShiftType(StronglyType.ShiftTypeModel shiftType);

        bool UpdateShiftType(StronglyType.ShiftTypeModel shiftType);

        bool DeleteShiftType(int shiftTypeId);
    }
}
