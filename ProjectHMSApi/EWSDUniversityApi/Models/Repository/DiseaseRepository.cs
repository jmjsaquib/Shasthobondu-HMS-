using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class DiseaseRepository:IDiseaseRepository
    {
        private Entities _entities;

        public DiseaseRepository()
        {
            this._entities=new Entities();
        }


        public object GetAllDisease()
        {
            return (from dis in _entities.diseases
                join dep in _entities.departments on dis.department_id equals dep.department_id
                select new
                {
                    disease_id=dis.disease_id,
                    disease_name = dis.disease_name,
                    disease_description=dis.disease_description,
                    department_id=dep.department_id,
                    department_name=dep.department_name
                }).ToList();
        }

        public object GetAllDiseaseById(int diseaseId)
        {
            return (from dis in _entities.diseases
                    where dis.disease_id==diseaseId
                    join dep in _entities.departments on dis.department_id equals dep.department_id
                    select new
                    {
                        disease_id = dis.disease_id,
                        disease_name = dis.disease_name,
                        disease_description = dis.disease_description,
                        department_id = dep.department_id,
                        department_name = dep.department_name
                    }).FirstOrDefault();
        }

        public bool CheckDuplicateFoDiseaseName(disease disease)
        {
            try
            {
                var data =
                    _entities.diseases.Where(
                        d => d.disease_name == disease.disease_name && d.department_id == disease.department_id);
                if (data ==null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool InsertDiease(disease disease)
        {
            try
            {
                disease dis = new disease
                {
                    disease_name = disease.disease_name,
                    disease_description = disease.disease_description,
                    department_id = disease.department_id
                };
                _entities.diseases.Add(dis);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        public bool UpdateDiease(disease disease)
        {
            try
            {
                var data = _entities.diseases.FirstOrDefault(d => d.disease_id == disease.disease_id);
                data.department_id = disease.department_id;
                data.disease_description = disease.disease_description;
                data.disease_name = disease.disease_name;
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool DeleteDiease(disease disease)
        {
            try
            {
                var data = _entities.diseases.FirstOrDefault(d => d.disease_id == disease.disease_id);
                _entities.diseases.Attach(data);
                _entities.diseases.Remove(data);
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}