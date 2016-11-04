using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.Repository;

namespace HMSDevelopmentApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BankController : ApiController
    {
        private IBankRepository bankRepository;

        public BankController()
        {
            this.bankRepository=new BankRepository();
        }
        [HttpGet, ActionName("GetAllBank")]

        public HttpResponseMessage GetAllBank(int hospital_id)
        {

            var data = bankRepository.GetAllBank(hospital_id);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }

        [HttpGet, ActionName("GetBankById")]

        public HttpResponseMessage GetBankById(int bankId)
        {
            var data = bankRepository.GetBankById(bankId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }
        [HttpPost, ActionName("Post")]
        public HttpResponseMessage Post([FromBody]Models.bank oBank)
        {
            try
            {
                if (string.IsNullOrEmpty(oBank.bank_name))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Bank name can not be empty" });
                }
                else
                {
                    bool chkDuplicate = bankRepository.CheckDuplicateForBankName(oBank);
                    if (chkDuplicate == true)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Bank Name Already Exists" }, formatter);

                    }
                    else
                    {
                        bool insertBank = bankRepository.InsertBank(oBank);
                        if (insertBank == true)
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Bank Information  is saved successfully." }, formatter);
                        }
                        else
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Bank Information  is not saved successfully." }, formatter);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                var formatter = RequestFormat.JsonFormaterString();
                return Request.CreateResponse(HttpStatusCode.OK,
                 new Confirmation { output = "error", msg = ex.ToString() }, formatter);
            }
        }
        [HttpPut, ActionName("Put")]
        public HttpResponseMessage Put([FromBody]Models.bank oBank)
        {
            try
            {
                if (string.IsNullOrEmpty(oBank.bank_name))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Bank name can not be empty" });
                }
                else
                {
                    bool updateBank = bankRepository.UpdateBank(oBank);
                    if (updateBank == true)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new Confirmation { output = "success", msg = "Bank Information  is updated successfully." }, formatter);
                    }
                    else
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Bank Information  is not updated successfully." }, formatter);
                    }
                }

            }
            catch (Exception ex)
            {

                var formatter = RequestFormat.JsonFormaterString();
                return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = ex.ToString() }, formatter);
            }
        }

        [HttpDelete, ActionName("Delete")]
        public HttpResponseMessage Delete([FromBody]Models.bank obaBank)
        {

            try
            {
                bool deletebank = bankRepository.Deletebank(obaBank.bank_id);
                if (deletebank == true)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "bank Information  is deleted successfully." }, formatter);
                }
                else
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "error", msg = "Bank Information  is not deleted succesfully." }, formatter);
                }
            }
            catch (Exception ex)
            {

                var formatter = RequestFormat.JsonFormaterString();
                return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = ex.ToString() }, formatter);
            }
        }
    }
}
