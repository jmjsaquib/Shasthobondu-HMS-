using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IBloodDonationRepository
    {
        object GetAllBloodDonation();

        object GetBloodDonationById(int donorId);

        object InsertBloodDonor(blood_donation obDonation);
    }
}
