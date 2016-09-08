using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IDiseaseRepository
    {
        object GetAllDisease();

        object GetAllDiseaseById(int diseaseId);

        bool CheckDuplicateFoDiseaseName(disease disease);

        bool InsertDiease(disease disease);

        bool UpdateDiease(disease disease);

        bool DeleteDiease(disease disease);
    }
}
