using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public bool InsertMetainfo(meta_info oMetainfo)
        {
            try
            {
                var hospitalSerial = _entities.meta_info.Max(e=>e.hospital_id);
                if (hospitalSerial==null)
                {
                    hospitalSerial = 1;
                }
                else
                {
                    hospitalSerial++;
                }

                meta_info meta = new meta_info { 
                    hospital_id=hospitalSerial,
                    hospital_name=oMetainfo.hospital_name,
                    address=oMetainfo.address,
                    district_id=oMetainfo.district_id,
                    division_id=oMetainfo.division_id,
                    email=oMetainfo.email,
                    phone=oMetainfo.phone,
                    web=oMetainfo.web,
                    fax=oMetainfo.fax,
                    logo_path = oMetainfo.logo_path
                };
                _entities.meta_info.Add(meta);
                _entities.SaveChanges();
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