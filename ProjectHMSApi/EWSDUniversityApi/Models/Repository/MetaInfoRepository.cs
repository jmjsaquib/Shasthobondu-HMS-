using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.StronglyType;

namespace HMSDevelopmentApi.Models.Repository
{
    public class MetaInfoRepository:IMetaInfoRepository
    {
        private Entities _entities;

        public MetaInfoRepository()
        {
            this._entities = new Entities();
        }
        public object GetAllMetaInfo()
        {
            return _entities.meta_info.ToList();
        }


        public object GetMetainfoById(int hospitalId)
        {
            return _entities.meta_info.FirstOrDefault(p=>p.hospital_id==hospitalId);
        }
        public bool InsertMetainfo(HospitalInfoModel oMetainfo)
        {
            try
            {
                var hospitalSerial = _entities.meta_info.Max(e=>e.hospital_id);
                if (hospitalSerial==null)
                {
                    hospitalSerial = 0001;
                }
                else
                {
                    hospitalSerial++;
                }

                meta_info meta = new meta_info
                {
                    hospital_id = hospitalSerial,
                    hospital_name = oMetainfo.hospital_name,
                    address = oMetainfo.address,
                    district_id = oMetainfo.district_id,
                    division_id = oMetainfo.division_id,
                    email = oMetainfo.email,
                    phone = oMetainfo.phone,
                    web = oMetainfo.web,
                    fax = oMetainfo.fax,
                    logo_path = oMetainfo.logo_path,
                    created_date = DateTime.Now.Date
                };
                   
                _entities.meta_info.Add(meta);
                _entities.SaveChanges();

                //role_type role = new role_type
                //{
                //    role_name = "Admin",
                //    role_description = "This is "+oMetainfo.hospital_name+" admin.",
                //    hospital_id = hospitalSerial

                //};
                //_entities.role_type.Add(role);
                //_entities.SaveChanges();

                //var maxAdminRoleID = _entities.role_type.Max(e => e.role_type_id);

                employee emp = new employee
                {
                    employee_name = oMetainfo.employee_name,
                    employee_email = oMetainfo.employee_email,
                    employee_user_name = oMetainfo.employee_user_name,
                    employee_password = oMetainfo.employee_password,
                    hospital_id = hospitalSerial,
                    role_type_id = 1
                };

                _entities.employees.Add(emp);
                _entities.SaveChanges();

                //var permisson = _entities.role_permission.Where(r => r.role_type_id == 1).ToList();

                //foreach (var item in permisson)
                //{
                //    role_permission rolePermission = new role_permission
                //    {
                //        role_type_id = 1,
                //        module_id = item.module_id
                     
                //    };
                //    _entities.role_permission.Add(rolePermission);
                //    _entities.SaveChanges();
                //}
                
                
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateMetainfo(meta_info oMetainfo)
        {
            try
            {
                var data = _entities.meta_info.FirstOrDefault(d => d.meta_info_id == oMetainfo.meta_info_id);
                data.hospital_id = oMetainfo.hospital_id;
                data.hospital_name = oMetainfo.hospital_name;
                data.division_id = oMetainfo.division_id;
                data.district_id = oMetainfo.district_id;
                data.address = oMetainfo.address;
                data.email = oMetainfo.email;
                data.fax = oMetainfo.fax;
                data.phone = oMetainfo.phone;
                data.web = oMetainfo.web;
                data.fax = oMetainfo.fax;
                data.logo_path = oMetainfo.logo_path;
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DelateInfo(int p)
        {

            try
            {
                var data = _entities.meta_info.FirstOrDefault(e => e.meta_info_id == p);
                _entities.meta_info.Attach(data);
                _entities.meta_info.Remove(data);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool CheckDuplicateForHospitalName(string p)
        {
            try
            {
                var chckHospitalnNameExists = _entities.meta_info.FirstOrDefault(r => r.hospital_name == p);
                return chckHospitalnNameExists == null ? false : true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}