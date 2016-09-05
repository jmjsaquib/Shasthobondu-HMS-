using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.StronglyType;

namespace HMSDevelopmentApi.Models.Repository
{
    public class BloodDonationRepository : IBloodDonationRepository
    {
        private Entities _entities;

        public BloodDonationRepository()
        {
            this._entities = new Entities();
        }

        public object GetAllBloodDonation()
        {
            try
            {
                return (from pat in _entities.patients
                        where pat.status=="entry"
                        join med in _entities.patient_health_info on pat.patient_id equals med.patient_id into medTable
                        from subMed in medTable.DefaultIfEmpty()
                        select new GetAllpatientModel
                        {
                            patient_id = pat.patient_id,
                            full_name = pat.full_name,
                            gender = pat.gender,
                            blood_group = subMed.blood_group,
                            dob = pat.dob,
                            status = pat.status,

                        }).ToList().OrderByDescending(p => p.patient_id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object GetBloodDonationById(int donorId)
        {
            try

            {
                var check = _entities.blood_donation.Where(b => b.donor_id == donorId).ToList();

                if (check.Count>0)
               {
                   var MaxDonateId = _entities.blood_donation.Where(b => b.donor_id == donorId).Max(b => b.blood_donation_id);
                   var donationCount = _entities.blood_donation.Count(b => b.donor_id == donorId);
                   return (from blood in _entities.blood_donation
                       where blood.donor_id == donorId && blood.blood_donation_id == MaxDonateId
                       join pat in _entities.patients on blood.donor_id equals pat.patient_id
                       join med in _entities.patient_health_info on pat.patient_id equals med.patient_id into MedTable
                       from subMed in MedTable.DefaultIfEmpty()
                       join div in _entities.divisions on pat.division_id equals div.division_id into DivTable
                       from subDiv in DivTable.DefaultIfEmpty()
                       join dis in _entities.districts on pat.district_id equals dis.district_id into DisTable
                       from subDis in DisTable.DefaultIfEmpty()
                       join meta in _entities.meta_info on blood.donation_place_id equals meta.hospital_id
                           select new BloodDonationDataModel
                       {
                           patient_id = pat.patient_id,
                           full_name = pat.full_name,
                           email = pat.email,
                           address = pat.address,
                           status = pat.status,
                           division_id = pat.division_id,
                           division_name = subDiv.division_name,
                           district_id = pat.district_id,
                           district_name = subDis.district_name,
                           zip_code = pat.zip_code,
                           phone = pat.phone,
                           nid_id = pat.nid_id,
                           gender = pat.gender,
                           blood_group = subMed.blood_group,
                           blood_pressure = subMed.blood_pressure,
                           height = subMed.height,
                           weight = subMed.weight,
                           age = subMed.age,
                           dob = pat.dob,
                           last_donation_date = blood.donation_date,
                           last_donation_place = meta.hospital_name,
                           donation_serial = donationCount
                       }).FirstOrDefault();
               }
               else
               {
                   //var donationCount = _entities.blood_donation.Count(b => b.donor_id == donorId);
                   return (from pat in _entities.patients
                        join med in _entities.patient_health_info on pat.patient_id equals med.patient_id into MedTable
                        from subMed in MedTable.DefaultIfEmpty()
                        join div in _entities.divisions on pat.division_id equals  div.division_id into DivTable
                        from subDiv in DivTable.DefaultIfEmpty()
                        join dis in _entities.districts on pat.district_id equals dis.district_id into DisTable
                        from subDis in DisTable.DefaultIfEmpty()
                        join emr in _entities.patient_emergency_contact on pat.patient_id equals  emr.patient_id into EmerTable
                        from subEmr in EmerTable.DefaultIfEmpty()
                        where pat.patient_id==donorId
                           select new
                           {
                               patient_id = pat.patient_id,
                               full_name = pat.full_name,
                               email = pat.email,
                               address = pat.address,
                               status = pat.status,
                               division_id = pat.division_id,
                               division_name = subDiv.division_name,
                               district_id = pat.district_id,
                               district_name = subDis.district_name,
                               zip_code = pat.zip_code,
                               phone = pat.phone,
                               nid_id = pat.nid_id,
                               gender = pat.gender,
                               blood_group = subMed.blood_group,
                               blood_pressure = subMed.blood_pressure,
                               height = subMed.height,
                               weight = subMed.weight,
                               age = subMed.age,
                               dob = pat.dob,
                               last_donation_date = "N/A",
                               last_donation_place = "N/A",
                               donation_serial = 0
                           }).FirstOrDefault();
               }
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public object InsertBloodDonor(blood_donation obDonation)
        {
            try
            {
                blood_donation donate = new blood_donation
                {
                    donor_id = obDonation.donor_id,
                    donation_place_id = obDonation.donation_place_id,
                    donation_date = obDonation.donation_date,
                    donate_whom = obDonation.donate_whom,
                   no_of_bag = obDonation.no_of_bag
                };
                _entities.blood_donation.Add(donate);
                _entities.SaveChanges();

                var maxId = _entities.blood_donation.Max(b => b.blood_donation_id);
                var blood = _entities.blood_donation.FirstOrDefault(b => b.blood_donation_id == maxId);
                return blood;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}