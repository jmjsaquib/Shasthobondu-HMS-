using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class BankRepository:IBankRepository
    {
        private Entities _entities;

        public BankRepository()
        {
            this._entities=new Entities();
        }


        public object GetAllBank()
        {
            try
            {
                return _entities.banks.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public object GetBankById(int bankId)
        {
            try
            {
                return _entities.banks.FirstOrDefault(b => b.bank_id == bankId);
            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        public bool CheckDuplicateForBankName(bank oBank)
        {
            try
            {
                if (oBank.bank_id ==0)
                {
                    var data =
                        _entities.banks.Where(b => b.bank_name == oBank.bank_name && b.branch_name == oBank.branch_name);
                    if (data == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                     var data = _entities.banks.FirstOrDefault(b => b.bank_id == oBank.bank_id);
                    if (data != null)
                    {
                        var check =
                            _entities.banks.Where(
                                a => a.bank_name == data.bank_name && a.branch_name == data.branch_name);
                        if (check == null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
               
            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        public bool InsertBank(bank oBank)
        {
            try
            {
                bank obBank = new bank
                {
                    bank_name = oBank.bank_name,
                    bank_account_no = oBank.bank_account_no,
                    branch_name = oBank.branch_name,
                    branch_address = oBank.branch_address
                };
                _entities.banks.Add(obBank);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateBank(bank oBank)
        {
            try
            {
                var data = _entities.banks.FirstOrDefault(b => b.bank_id == oBank.bank_id);
                data.bank_id = oBank.bank_id;
                data.bank_name = oBank.bank_name;
                data.bank_account_no = oBank.bank_account_no;
                data.branch_name = oBank.branch_name;
                data.branch_address = oBank.branch_address;

                _entities.SaveChanges();
                return true;


            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Deletebank(int p)
        {
            try
            {
                var data = _entities.banks.FirstOrDefault(b => b.bank_id == p);
                _entities.banks.Attach(data);
                _entities.banks.Remove(data);
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