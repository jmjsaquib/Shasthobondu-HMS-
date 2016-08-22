using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.Repository
{
    public class FloorRepository:IFloorRepository
    {
        private Entities _entities;

        public FloorRepository()
        {
            this._entities = new Entities();
        }
        public object GetAllFloor()
        {
            return _entities.floors.ToList();
        }

        public object GetFloorById(int floorId)
        {
            return _entities.floors.FirstOrDefault(r=>r.floor_id==floorId);
        }

        public bool CheckDuplicateForFloorName(string p)
        {
            var chkFloorNameExists = _entities.floors.FirstOrDefault(b => b.floor_name == p);
            return chkFloorNameExists == null ? false : true;
        }

        public bool InsertFloor(floor oFlors)
        {
            try
            {
                floor flr = new floor { 
                    floor_name=oFlors.floor_name,
                    room_count=oFlors.room_count
                };
                _entities.floors.Add(flr);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateFloor(floor oflor)
        {
            try
            {
                var data = _entities.floors.FirstOrDefault(f=>f.floor_id==oflor.floor_id);
                data.floor_id = oflor.floor_id;
                data.floor_name = oflor.floor_name;
                data.room_count = oflor.room_count;
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool DeleteFloor(int p)
        {
            try
            {
                var data = _entities.floors.FirstOrDefault(r=>r.floor_id==p);
                _entities.floors.Attach(data);
                _entities.floors.Remove(data);
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