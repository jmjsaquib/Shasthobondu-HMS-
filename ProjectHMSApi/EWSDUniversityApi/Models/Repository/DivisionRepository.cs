using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.Repository
{
    public class DivisionRepository:IDivisionRepository
    {
        private Entities _entities;

        public DivisionRepository()
        {
            this._entities = new Entities();
        }
        public object GetAllDivision()
        {
            return _entities.divisions.ToList();
        }

        public object GetDivisionById(int divisionid)
        {
            return _entities.divisions.FirstOrDefault(d=>d.division_id==divisionid);
        }

        public bool CheckDuplicateForDivisionName(string divisionname)
        {
            try
            {
                 var chckDivisionNameExists = _entities.divisions.FirstOrDefault(r=>r.division_name==divisionname);
            return chckDivisionNameExists == null ? false : true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool InsertDivision(division oDivision)
        {
            try
            {
                division div = new division {
                    division_name=oDivision.division_name
                };
                _entities.divisions.Add(div);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateDivision(division oDivision)
        {
            try
            {
                var data = _entities.divisions.FirstOrDefault(d=>d.division_id==oDivision.division_id);
                data.division_name = oDivision.division_name;
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool DeleteDivision(int p)
        {
            try
            {
                var data = _entities.divisions.FirstOrDefault(e=>e.division_id==p);
                _entities.divisions.Attach(data);
                _entities.divisions.Remove(data);
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