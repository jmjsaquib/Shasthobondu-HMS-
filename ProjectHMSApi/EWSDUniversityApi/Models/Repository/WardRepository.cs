using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.StronglyType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HMSDevelopmentApi.Models.Repository
{
    public class WardRepository:IWardRepository
    {
        private Entities _entities;

        public WardRepository()
        {
            this._entities = new Entities();
        }
    
        public object GetAllWard()
        {
 	        return (from war in _entities.wards
                        join dep in _entities.departments on war.department_id equals dep.department_id
                        join fl in _entities.floors on war.floor_id equals fl.floor_id
                        select new {
                            ward_id=war.ward_id,
                            ward_no=war.ward_no,
                            ward_name=war.ward_name,
                            department_id=war.department_id,
                            department_name=dep.department_name,
                            total_bed=war.total_bed,
                            floor_id=war.floor_id,
                            floor_name=fl.floor_name,
                            ward_type=war.ward_type,
                            ward_for_whom=war.ward_for_whom,
                            bed_cost=war.bed_cost,
                            wing=war.wing
                        }).ToList().OrderByDescending(p=>p.ward_id);
        }

        public object GetWardById(int wardId)
        {
 	        return (from war in _entities.wards
                    where war.ward_id==wardId
                        join dep in _entities.departments on war.department_id equals dep.department_id
                        join fl in _entities.floors on war.floor_id equals fl.floor_id
                        select new {
                            ward_id=war.ward_id,
                            ward_no=war.ward_no,
                            ward_name=war.ward_name,
                            department_id=war.department_id,
                            department_name=dep.department_name,
                            total_bed=war.total_bed,
                            floor_id=war.floor_id,
                            floor_name=fl.floor_name,
                            ward_type=war.ward_type,
                            bed_cost=war.bed_cost,
                            ward_for_whom=war.ward_for_whom,
                            wing=war.wing
                        }).FirstOrDefault();
        }

        public bool CheckDuplicateForWardName(string wardname, string wing, int? floor_id)
        {
 	        var chrWardNameExists = _entities.wards.FirstOrDefault(r=>r.ward_name==wardname );
            if (chrWardNameExists==null)
            {
                var data = _entities.wards.FirstOrDefault(w => w.floor_id == floor_id && w.wing == wing);
                if (data==null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool UpdateWard(ward ward)
        {
            try
            {
                var data = _entities.wards.FirstOrDefault(w => w.ward_id == ward.ward_id);
                data.ward_name = ward.ward_name;
                data.bed_cost = ward.bed_cost;
                data.department_id = ward.department_id;
                data.total_bed = ward.total_bed;
                data.ward_for_whom = ward.ward_for_whom;
                data.ward_type = ward.ward_type;
                data.ward_no = ward.ward_no;
                data.floor_id = ward.floor_id;
                data.wing = ward.wing;
                data.rest_bed = ward.total_bed-data.rest_bed;
                _entities.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool InsertWard(ward ward)
        {
 	        try 
	    {	        
		         ward wr= new ward {
                    ward_name=ward.ward_name,
                    ward_no=ward.ward_no,
                    department_id=ward.department_id,
                    total_bed=ward.total_bed,
                    ward_type = ward.ward_type,
                    ward_for_whom = ward.ward_for_whom,
                    floor_id = ward.floor_id,
                    bed_cost = ward.bed_cost,
                    wing = ward.wing,
                    ward_status = "waiting",
                    assign_bed = 0,
                    rest_bed = ward.total_bed
                 };
                _entities.wards.Add(wr);
                _entities.SaveChanges();
                return true;
	    }
	    catch (Exception)
	    {
		
		    return false;
	    }
        }

        public bool DeleteWard(int wardId)
        {
            try
            {
                var data = _entities.wards.FirstOrDefault(q => q.ward_id == wardId);
                _entities.wards.Attach(data);
                _entities.wards.Remove(data);
                _entities.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool CheckDuplicateForWardNameUpdae(ward ward)
        {
            try
            {
                var data = _entities.wards.Where(w => w.ward_name == ward.ward_name || w.ward_id==ward.ward_id).ToList();
                if (data.Count<=1)
                {
                    if (data[0].wing==ward.wing)
                    {
                        return true;
                    }
                    else
                    {
                        var data2 = _entities.wards.FirstOrDefault(w => w.floor_id == ward.floor_id && w.wing == ward.wing);
                        if (data2 == null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}