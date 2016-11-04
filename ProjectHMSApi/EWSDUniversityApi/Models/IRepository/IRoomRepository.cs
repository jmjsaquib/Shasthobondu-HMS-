using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IRoomRepository
    {
        object GetRoomById(int roomId);

        object GetAllRoom(int hospital_id);

        bool CheckDuplicateForRoomName(string p);

        bool InsertRoom(room oroom);

        bool UpdateRoom(room oroom);

        bool DeleteRoom(int p);
    }
}
