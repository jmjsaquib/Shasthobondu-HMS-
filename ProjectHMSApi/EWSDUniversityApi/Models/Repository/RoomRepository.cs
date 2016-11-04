using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.Repository
{
    public class RoomRepository:IRoomRepository
    {
        private Entities _entities;

        public RoomRepository()
        {
            this._entities = new Entities();
        }
        public object GetRoomById(int roomId)
        {
            return _entities.rooms.FirstOrDefault(r=>r.room_id==roomId);
        }

        public object GetAllRoom(int hospital_id)
        {
            return (from rm in _entities.rooms
                    join rmT in _entities.room_type on rm.room_type_id equals rmT.room_type_id
                    join fl in _entities.floors on rm.floor_id equals fl.floor_id
                    join dep in _entities.departments on rm.department_id equals dep.department_id
                    where rm.hospital_id==hospital_id
                    select new {
                        room_id=rm.room_id,
                        room_no=rm.room_no,
                        room_type_id=rm.room_type_id,
                        room_description=rm.room_description,
                        floor_name=fl.floor_name,
                        room_type_name=rmT.room_type_name,
                        status = rm.status ?? "N/A",
                        floor_id=rm.floor_id,
                        no_of_bed=rm.no_of_bed,
                        department_id=dep.department_id,
                        department_name=dep.department_name
                    }).ToList().OrderByDescending(r=>r.room_id);
        }

        public bool CheckDuplicateForRoomName(string p)
        {
            var chroomNameExists = _entities.rooms.FirstOrDefault(r=>r.room_no==p);
            return chroomNameExists == null ? false : true;
        }

        public bool InsertRoom(room oroom)
        {
            try
            {
                room rm = new room
                {
                    room_no = oroom.room_no,
                    room_description = oroom.room_description,
                    room_type_id = oroom.room_type_id,
                    floor_id = oroom.floor_id,
                    no_of_bed=oroom.no_of_bed,
                    status="Waiting",
                    department_id = oroom.department_id,
                    room_assign_bed = 0,
                    room_rest_bed = oroom.no_of_bed,
                    hospital_id = oroom.hospital_id
                };

                _entities.rooms.Add(rm);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateRoom(room oroom)
        {
            try
            {
                var data = _entities.rooms.FirstOrDefault(r=>r.room_id==oroom.room_id);
                data.room_id = oroom.room_id;
                data.room_no = oroom.room_no;
                data.room_type_id = oroom.room_type_id;
                data.room_description = oroom.room_description;
                data.floor_id = oroom.floor_id;
                data.department_id = oroom.department_id;
                data.no_of_bed = oroom.no_of_bed;
                data.room_rest_bed = oroom.no_of_bed - data.room_rest_bed;
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteRoom(int p)
        {
            try
            {
                var data = _entities.rooms.FirstOrDefault(r=>r.room_id==p);
                _entities.rooms.Attach(data);
                _entities.rooms.Remove(data);
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