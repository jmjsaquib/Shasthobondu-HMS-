using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSDevelopmentApi.Models.StronglyType;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IMetaInfoRepository
    {
        bool InsertMetainfo(HospitalInfoModel oMetainfo);

        bool UpdateMetainfo(meta_info oMetainfo);

        bool DelateInfo(int p);

        object GetAllMetaInfo();

        object GetMetainfoById(int hospitalId);

        bool CheckDuplicateForHospitalName(string p);
    }
}
