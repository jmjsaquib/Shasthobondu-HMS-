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
    public class BloodDonationController : ApiController
    {
        private IBloodDonationRepository boDonationRepository;

        public BloodDonationController()
        {
            this.boDonationRepository=new BloodDonationRepository();
        }
        [HttpGet, ActionName("GetAllBloodDonation")]

        public HttpResponseMessage GetAllBloodDonation()
        {

            var data = boDonationRepository.GetAllBloodDonation();
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }

        [HttpGet, ActionName("GetBloodDonationById")]

        public HttpResponseMessage GetBloodDonationById(int donorId)
        {
            var data = boDonationRepository.GetBloodDonationById(donorId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }
        [HttpPost, ActionName("Post")]
        public HttpResponseMessage Post([FromBody]Models.blood_donation obDonation)
        {
            try
            {

                var insert = boDonationRepository.InsertBloodDonor(obDonation);
                if (insert !=null)
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Blood Donation Information  is saved successfully.",returnvalue = insert}, formatter);
                        }
                        else
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "error", msg = "Blood Donation Information  is not saved successfully." }, formatter);
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
