using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class ShiftTypeRepository:IShiftTypeRepository
    {
        private Entities _entities;

        public ShiftTypeRepository()
        {
            this._entities=new Entities();
        }

        public object GetAllShiftType(int hospital_id)
        {
            try
            {
                return _entities.shift_type.Where(s => s.hospital_id == hospital_id).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public object GetDischarTypeById(int shiftTypeID)
        {
            try
            {
                return _entities.shift_type.FirstOrDefault(r => r.shift_type_id == shiftTypeID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool CheckDuplicateForShiftTypeName(StronglyType.ShiftTypeModel shiftType)
        {
            try
            {
                var chkDischargeTypeNameExists = _entities.shift_type.FirstOrDefault(b => b.shift_type_name == shiftType.shift_type_name && b.hospital_id==shiftType.hospital_id);
                return chkDischargeTypeNameExists == null ? false : true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool InsertShiftType(StronglyType.ShiftTypeModel shiftType)
        {
            try
            {
                shift_type dis = new shift_type
                {
                    shift_type_name = shiftType.shift_type_name,
                    shift_from = shiftType.shift_from,
                    shift_to = shiftType.shift_to,
                    hospital_id = shiftType.hospital_id
                };
                _entities.shift_type.Add(dis);
                _entities.SaveChanges();

                var maxId = _entities.shift_type.Max(s => s.shift_type_id);
                doctor_schedule doc = new doctor_schedule
                {
                    shif_type_id = maxId,
                    sat = "no",
                    sun = "no",
                    mon = "no",
                    wed = "no",
                    tues = "no",
                    thurs = "no",
                    fri = "no",
                };
                _entities.doctor_schedule.Add(doc);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        public bool UpdateShiftType(StronglyType.ShiftTypeModel shiftType)
        {
            try
            {
                
                
                var data =
                     _entities.shift_type.FirstOrDefault(d => d.shift_type_id == shiftType.shift_type_id);
                if (shiftType.shift_from.Contains("NaN") )
                {
                    data.shift_type_name = shiftType.shift_type_name;
                    data.shift_from = data.shift_from;
                    data.shift_to = shiftType.shift_to;
                }else if (shiftType.shift_to.Contains("NaN"))
                {
                    data.shift_type_name = shiftType.shift_type_name;
                    data.shift_from = shiftType.shift_from;
                    data.shift_to = data.shift_to;
                }
                else
                {
                    data.shift_type_name = shiftType.shift_type_name;
                    data.shift_from = shiftType.shift_from;
                    data.shift_to = shiftType.shift_to;
                }
                
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool DeleteShiftType(int shiftTypeId)
        {
            try
            {
                var data =
                     _entities.shift_type.FirstOrDefault(d => d.shift_type_id == shiftTypeId);
                _entities.shift_type.Attach(data);
                _entities.shift_type.Remove(data);
                _entities.SaveChanges();

                var docData = _entities.doctor_schedule.FirstOrDefault(d => d.shif_type_id == shiftTypeId);
                
                _entities.doctor_schedule.Attach(docData);
                _entities.doctor_schedule.Remove(docData);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}