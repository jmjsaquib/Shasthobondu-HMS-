using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IFloorRepository
    {
        object GetAllFloor();

        object GetFloorById(int floorId);

        bool CheckDuplicateForFloorName(string p);

        bool InsertFloor(floor oFlors);

        bool UpdateFloor(floor oflor);

        bool DeleteFloor(int p);
    }
}
