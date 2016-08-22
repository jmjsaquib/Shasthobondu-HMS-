using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.Repository
{
    public class DistrictRepository:IDistrictRepository
    {
        private Entities _entities;

        public DistrictRepository()
        {
            this._entities = new Entities();
        }
        public object GetAllDistrict()
        {
            return (from dis in _entities.districts
                    join div in _entities.divisions on dis.division_id equals div.division_id
                        into divtable
                    from subDiv in divtable.DefaultIfEmpty()
                    select new {
                        district_id=dis.district_id,
                        district_name=dis.district_name,
                        division_id=dis.division_id,
                        division_name=subDiv.division_name
                    }).ToList();
        }

        public object GetDistrictById(int districtid)
        {
            return _entities.districts.FirstOrDefault(d=>d.district_id==districtid);
        }

        public bool CheckDuplicateForDistrictName(string p)
        {
            try
            {
                var chckDistrictnNameExists = _entities.districts.FirstOrDefault(r => r.district_name == p);
                return chckDistrictnNameExists == null ? false : true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool InsertDistrict(district oDistrict)
        {
            try
            {
                district dis = new district
                {
                    district_name = oDistrict.district_name,
                    division_id=oDistrict.division_id
                };
                _entities.districts.Add(dis);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteDistrict(int p)
        {
            try
            {
                var data = _entities.districts.FirstOrDefault(e => e.district_id == p);
                _entities.districts.Attach(data);
                _entities.districts.Remove(data);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool UpdateDistrict(district oDistrict)
        {
            try
            {
                var data = _entities.districts.FirstOrDefault(d => d.district_id == oDistrict.district_id);
                data.district_name = oDistrict.district_name;
                data.division_id = oDistrict.division_id;
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