using HMSDevelopmentApi.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.Repository
{
    public class RoomTypeRepository:IRoomTypeRepository
    {
        private Entities _entities;
        public RoomTypeRepository()
        {

            this._entities = new Entities();
        }
        public object GetRoomTypeById(int roomTypeId)
        {
            return _entities.room_type.FirstOrDefault(r=>r.room_type_id==roomTypeId);
        }

        public object GetAllRoomType(int hospital_id)
        {
            return _entities.room_type.Where(r=>r.hospital_id==hospital_id).ToList();
        }

        public bool CheckDuplicateForRoomTypeName(int p1, string p2)
        {
            var checkRoomTypeIsExists = _entities.room_type.FirstOrDefault(b => b.room_type_id == p1 && b.room_type_name == p2);
            return checkRoomTypeIsExists == null ? false : true;
        }

        public bool InsertRoomType(room_type insert)
        {
            try
            {
                room_type rt = new room_type
                {
                   room_type_name=insert.room_type_name,
                   description=insert.description,
                   rent=insert.rent,
                   hospital_id = insert.hospital_id
                };
                _entities.room_type.Add(insert);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateRoomType(room_type update)
        {
            try
            {
                room_type room = _entities.room_type.Find(update.room_type_id);
                room.room_type_id = update.room_type_id;
                room.room_type_name = update.room_type_name;
                room.rent = update.rent;
                room.description = update.description;
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteRoomType(int p)
        {
            try
            {
                var data = _entities.room_type.FirstOrDefault(r=>r.room_type_id==p);
                _entities.room_type.Attach(data);
                _entities.room_type.Remove(data);
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