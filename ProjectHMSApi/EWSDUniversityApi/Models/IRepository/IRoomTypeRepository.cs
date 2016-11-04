using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IRoomTypeRepository
    {
        object GetRoomTypeById(int roomTypeId);

        object GetAllRoomType(int hospital_id);

        bool CheckDuplicateForRoomTypeName(int p1, string p2);

        bool InsertRoomType(room_type insert);

        bool UpdateRoomType(room_type update);

        bool DeleteRoomType(int p);
    }
}
