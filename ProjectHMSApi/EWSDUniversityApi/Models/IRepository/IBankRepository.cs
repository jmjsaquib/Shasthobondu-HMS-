using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IBankRepository
    {
        object GetAllBank(int hospital_id);

        object GetBankById(int bankId);

        bool CheckDuplicateForBankName(bank oBank);

        bool InsertBank(bank oBank);

        bool UpdateBank(bank oBank);

        bool Deletebank(int p);
    }
}
