using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class TestTypeRepository:ITestTypeRepository
    {
        private Entities _entities;

        public TestTypeRepository()
        {
            this._entities=new Entities();
        }

        public object GetAllTestType()
        {
            return _entities.test_type.ToList().OrderBy(p=>p.test_type_name);
        }


        public object GetAllTestTypeById(int testTypeId)
        {
            return _entities.test_type.FirstOrDefault(t => t.test_type_id == testTypeId);
        }

        public bool CheckDuplicateForTestTypeName(string p)
        {
            var data = _entities.test_type.FirstOrDefault(t => t.test_type_name == p);
            if (data!=null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool InsertTestType(test_type test)
        {
            try
            {
                test_type tst = new test_type
                {
                    test_type_name = test.test_type_name,
                    test_cost = test.test_cost
                };
                _entities.test_type.Add(tst);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateTestType(test_type test)
        {
            try
            {
                var data = _entities.test_type.FirstOrDefault(t => t.test_type_id == test.test_type_id);
                data.test_type_name = test.test_type_name;
                data.test_cost = test.test_cost;
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTestType(int p)
        {
            try
            {
                var data = _entities.test_type.FirstOrDefault(t => t.test_type_id == p);
                _entities.test_type.Attach(data);
                _entities.test_type.Remove(data);
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