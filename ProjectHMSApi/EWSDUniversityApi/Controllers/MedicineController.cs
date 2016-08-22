using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.Repository;
using HMSDevelopmentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace HMSDevelopmentApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MedicineController : ApiController
    {
        private IMedicineRepository medicineRepository;

        public MedicineController()
        {
            this.medicineRepository=new MedicineRepository();
        }
          [HttpGet, ActionName("GetAllMedicine")]
        public HttpResponseMessage GetAllMedicine()
        {

            var data = medicineRepository.GetAllMedicine();
            var format_type = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
        }
          [HttpGet, ActionName("GetAllMedicineById")]

          public HttpResponseMessage GetAllMedicineById(int medicineId)
          {
              var data = medicineRepository.GetAllMedicineById(medicineId);
              var format = RequestFormat.JsonFormaterString();
              return Request.CreateResponse(HttpStatusCode.OK, data, format);

          }

          [HttpPost, ActionName("Post")]
          public HttpResponseMessage Post([FromBody]Models.medicine med)
          {
              try
              {
                  if (string.IsNullOrEmpty(med.medicine_name))
                  {
                      var format_type = RequestFormat.JsonFormaterString();
                      return Request.CreateResponse(HttpStatusCode.OK,
                     new Confirmation { output = "error", msg = "Medicine name can not be empty" });
                  }
                  else
                  {
                      bool chkDuplicate = medicineRepository.CheckDuplicateForMedicineName(med.medicine_name);
                      if (chkDuplicate == false)
                      {
                          var formatter = RequestFormat.JsonFormaterString();
                          return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Medicine Name Already Exists" }, formatter);

                      }
                      else
                      {
                          bool insertMedicine = medicineRepository.InsertMedicine(med);
                          if (insertMedicine == true)
                          {
                              var formatter = RequestFormat.JsonFormaterString();
                              return Request.CreateResponse(HttpStatusCode.OK,
                                  new Confirmation { output = "success", msg = "Medicine Information  is saved successfully." }, formatter);
                          }
                          else
                          {
                              var formatter = RequestFormat.JsonFormaterString();
                              return Request.CreateResponse(HttpStatusCode.OK,
                                  new Confirmation { output = "success", msg = "Medicine Information  is not saved successfully." }, formatter);
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
          public HttpResponseMessage Put([FromBody]Models.medicine med)
          {
              try
              {
                  if (string.IsNullOrEmpty(med.medicine_name))
                  {
                      var format_type = RequestFormat.JsonFormaterString();
                      return Request.CreateResponse(HttpStatusCode.OK,
                     new Confirmation { output = "error", msg = "Medicine name can not be empty" });
                  }
                  else
                  {
                      bool updateMedicine = medicineRepository.UpdateMedicine(med);
                      if (updateMedicine == true)
                      {
                          var formatter = RequestFormat.JsonFormaterString();
                          return Request.CreateResponse(HttpStatusCode.OK,
                              new Confirmation { output = "success", msg = "Medicine Information  is updated successfully." }, formatter);
                      }
                      else
                      {
                          var formatter = RequestFormat.JsonFormaterString();
                          return Request.CreateResponse(HttpStatusCode.OK,
                          new Confirmation { output = "success", msg = "Medicine Information  is not updated successfully." }, formatter);
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
          public HttpResponseMessage Delete([FromBody]Models.medicine med)
          {

              try
              {
                  bool deletemedicine = medicineRepository.DeleteMedicine(med.medicine_id);
                  if (deletemedicine == true)
                  {
                      var formatter = RequestFormat.JsonFormaterString();
                      return Request.CreateResponse(HttpStatusCode.OK,
                          new Confirmation { output = "success", msg = "Medicine Information  is deleted successfully." }, formatter);
                  }
                  else
                  {
                      var formatter = RequestFormat.JsonFormaterString();
                      return Request.CreateResponse(HttpStatusCode.OK,
                          new Confirmation { output = "error", msg = "Medicine Information  is not deleted succesfully." }, formatter);
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
