using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class DischargeTypeRepository:IDischargeTypeRepository
    {
         private Entities _entities;

         public DischargeTypeRepository()
         {
            this._entities = new Entities();
        }

         public object GetAllDischarType()
         {
             return _entities.discharge_type.ToList();
         }

         public object GetDischarTypeById(int dischargeId)
         {
             return _entities.discharge_type.FirstOrDefault(d => d.discharge_type_id == dischargeId);
         }

         public bool CheckDuplicateForDischargeTypeName(discharge_type discharge)
         {
             var chkDischargeTypeNameExists = _entities.discharge_type.FirstOrDefault(b=>b.discharge_type_name == discharge.discharge_type_name);
             return chkDischargeTypeNameExists == null ? false : true;
         }

         public bool InsertDischargeType(discharge_type discharge)
         {
             try
             {
                 discharge_type dis = new discharge_type
                 {
                     discharge_type_name = discharge.discharge_type_name
                 };
                 _entities.discharge_type.Add(dis);
                 _entities.SaveChanges();
                 return true;
             }
             catch (Exception)
             {

                 return false;
             }
         }

         public bool UpdateDischargeType(discharge_type discharge)
         {
             try
             {
                 var data =
                     _entities.discharge_type.FirstOrDefault(d => d.discharge_type_id == discharge.discharge_type_id);
                 data.discharge_type_name = discharge.discharge_type_name;
                 _entities.SaveChanges();
                 return true;
             }
             catch (Exception)
             {

                 return false;
             }
         }

         public bool DeleteDischargeType(int dischargeId)
         {
             try
             {
                 var data =
                     _entities.discharge_type.FirstOrDefault(d => d.discharge_type_id == dischargeId);
                 _entities.discharge_type.Attach(data);
                 _entities.discharge_type.Remove(data);
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