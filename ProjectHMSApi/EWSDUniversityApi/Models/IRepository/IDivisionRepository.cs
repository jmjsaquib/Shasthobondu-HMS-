using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IDivisionRepository
    {
        object GetAllDivision();

        object GetDivisionById(int divisionid);

        bool CheckDuplicateForDivisionName(string divisionname);

        bool InsertDivision(division oDivision);

        bool UpdateDivision(division oDivision);

        bool DeleteDivision(int p);
    }
}
