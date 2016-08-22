using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface ITestTypeRepository
    {
        object GetAllTestType();

        object GetAllTestTypeById(int testTypeId);

        bool CheckDuplicateForTestTypeName(string p);

        bool InsertTestType(test_type test);

        bool UpdateTestType(test_type test);

        bool DeleteTestType(int p);
    }
}
