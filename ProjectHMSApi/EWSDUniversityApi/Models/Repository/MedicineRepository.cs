using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class MedicineRepository:IMedicineRepository
    {
        private Entities _entities;

        public MedicineRepository()
        {
            this._entities=new Entities();
        }

        public object GetAllMedicine()
        {
            return _entities.medicines.ToList();
        }


        public object GetAllMedicineById(int medicineId)
        {
            return _entities.medicines.FirstOrDefault(m => m.medicine_id == medicineId);
        }

        public bool CheckDuplicateForMedicineName(string p)
        {
            var check = _entities.medicines.FirstOrDefault(m => m.medicine_name == p);
            if (check!=null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool InsertMedicine(medicine med)
        {
            try
            {
                medicine medicine = new medicine
                {
                    medicine_name = med.medicine_name,
                    company_name = med.company_name
                };
                _entities.medicines.Add(medicine);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateMedicine(medicine med)
        {
            try
            {
                var data = _entities.medicines.FirstOrDefault(m => m.medicine_id == med.medicine_id);
                data.medicine_name = med.medicine_name;
                data.company_name = med.company_name;
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool DeleteMedicine(int p)
        {
            try
            {
                var data = _entities.medicines.FirstOrDefault(t => t.medicine_id == p);
                _entities.medicines.Attach(data);
                _entities.medicines.Remove(data);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}