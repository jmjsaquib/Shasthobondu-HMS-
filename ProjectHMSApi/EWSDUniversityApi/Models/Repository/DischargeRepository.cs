using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class DischargeRepository:IDischargeRepository
    {
        private Entities _entities;

        public DischargeRepository()
        {
            this._entities = new Entities();
        }
    }
}