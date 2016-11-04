using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IFloorRepository
    {
        object GetAllFloor(int hospital_id);

        object GetFloorById(int floorId);


        bool InsertFloor(floor oFlors);

        bool UpdateFloor(floor oflor);

        bool DeleteFloor(int p);

        bool CheckDuplicateForFloorName(floor oFlors);
    }
}
