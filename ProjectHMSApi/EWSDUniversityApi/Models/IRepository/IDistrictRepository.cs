using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IDistrictRepository
    {
        object GetAllDistrict();

        object GetDistrictById(int districtid);

        bool CheckDuplicateForDistrictName(string p);

        bool InsertDistrict(district oDistrict);

        bool DeleteDistrict(int p);

        bool UpdateDistrict(district oDistrict);
    }
}
