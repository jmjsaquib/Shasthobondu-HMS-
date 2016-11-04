using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using HMSDevelopmentApi.Models.StronglyType;

namespace HMSDevelopmentApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MetaInfoController : ApiController
    {
        private IMetaInfoRepository metainforepository;

        public MetaInfoController()
        {
            this.metainforepository = new MetaInfoRepository();
        }

        [HttpGet, ActionName("GetAllMetaInfo")]

        public HttpResponseMessage GetAllMetaInfo()
        {

            var data = metainforepository.GetAllMetaInfo();
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }

        [HttpGet, ActionName("GetMetainfoById")]

        public HttpResponseMessage GetMetainfoById(int hospitalId)
        {
            var data = metainforepository.GetMetainfoById(hospitalId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }

        [HttpPost, ActionName("Post")]
        public HttpResponseMessage Post()
        {
            try
            {
                System.Web.HttpRequest form_contents = System.Web.HttpContext.Current.Request;
                var hospital_name = form_contents.Form["hospital_name"].ToString();
                var address = form_contents.Form["address"].ToString();
                var division_id = int.Parse(form_contents.Form["division_id"].ToString());
                var district_id = int.Parse(form_contents.Form["district_id"].ToString());
                var phone = form_contents.Form["phone"].ToString();
                var fax = form_contents.Form["fax"].ToString();
                var email = form_contents.Form["email"].ToString();
                var web = form_contents.Form["web"].ToString();
                var employee_name = form_contents.Form["employee_name"].ToString();
                var employee_email = form_contents.Form["employee_email"].ToString();
                var employee_user_name = form_contents.Form["employee_user_name"].ToString();
                var employee_password = form_contents.Form["employee_password"].ToString();
                var httpPostedFile = form_contents.Files["UploadedImage"];
                string ActualFileName = "";

                if (string.IsNullOrEmpty(hospital_name))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Hospital name can not be empty" });
                }
                else if (httpPostedFile == null)
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Hospital Logo can not be empty" });
                }
                else
                {
                    bool chkDuplicate = metainforepository.CheckDuplicateForHospitalName(hospital_name);
                    if (chkDuplicate == true)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Hospital Name Already Exists" }, formatter);

                    }
                    else
                    {
                        string docfileName = "";
                        ActualFileName = form_contents.Files["UploadedImage"].FileName;
                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/Uploads/Logo/"), ActualFileName);
                        bool checkFileSave = false;
                        try
                        {
                            docfileName = "/Images/Uploads/Logo/" + ActualFileName;
                            httpPostedFile.SaveAs(fileSavePath);
                            checkFileSave = true;
                        }
                        catch
                        {
                            checkFileSave = false;
                        }
                        if (checkFileSave == true)
                        {
                            HospitalInfoModel oMetainfo = new HospitalInfoModel
                            {
                                hospital_name = hospital_name,
                                address = address,
                                division_id = division_id,
                                district_id = district_id,
                                email = email,
                                fax = fax,
                                logo_path = docfileName,
                                phone = phone,
                                web = web,
                                employee_name = employee_name,
                                employee_email = employee_email,
                                employee_user_name = employee_user_name,
                                employee_password = employee_password

                            };
                            bool insert = metainforepository.InsertMetainfo(oMetainfo);
                            if (insert == true)
                            {
                                var formatter = RequestFormat.JsonFormaterString();
                                return Request.CreateResponse(HttpStatusCode.OK,
                                    new Confirmation { output = "success", msg = "Hospital Information  is saved successfully." }, formatter);
                            }
                            else
                            {
                                var formatter = RequestFormat.JsonFormaterString();
                                return Request.CreateResponse(HttpStatusCode.OK,
                                    new Confirmation { output = "success", msg = "Hospital Information  is not saved successfully." }, formatter);
                            }
                        }
                        else
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Hospital Information  is not saved successfully." }, formatter);
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
        public HttpResponseMessage Put()
        {
            try
            {
                System.Web.HttpRequest form_contents = System.Web.HttpContext.Current.Request;
                var hospital_name = form_contents.Form["hospital_name"].ToString();
                var address = form_contents.Form["address"].ToString();
                var division_id = int.Parse(form_contents.Form["division_id"].ToString());
                var district_id = int.Parse(form_contents.Form["district_id"].ToString());
                var meta_info_id = int.Parse(form_contents.Form["meta_info_id"].ToString());
                var hospital_id = int.Parse(form_contents.Form["hospital_id"].ToString());
                var phone = form_contents.Form["phone"].ToString();
                var fax = form_contents.Form["fax"].ToString();
                var email = form_contents.Form["email"].ToString();
                var web = form_contents.Form["web"].ToString();
                var httpPostedFile = form_contents.Files["UploadedImage"];
                string ActualFileName = "";

                if (string.IsNullOrEmpty(hospital_name))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Hospital name can not be empty" });
                }
                else if (httpPostedFile == null)
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Hospital Logo can not be empty" });
                }
                else
                {
                    string docfileName = "";
                    ActualFileName = form_contents.Files["UploadedImage"].FileName;
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/Uploads/Logo/"), ActualFileName);
                    bool checkFileSave = false;
                    try
                    {
                        docfileName = "/Images/Uploads/Logo/" + ActualFileName;
                        httpPostedFile.SaveAs(fileSavePath);
                        checkFileSave = true;
                    }
                    catch
                    {
                        checkFileSave = false;
                    }
                    if (checkFileSave == true)
                    {
                        Models.meta_info oMetainfo = new meta_info
                        {
                            meta_info_id = meta_info_id,
                            hospital_id = hospital_id,
                            hospital_name = hospital_name,
                            address = address,
                            division_id = division_id,
                            district_id = district_id,
                            email = email,
                            fax = fax,
                            logo_path = docfileName,
                            phone = phone,
                            web = web
                        };
                        bool update = metainforepository.UpdateMetainfo(oMetainfo);
                        if (update == true)
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation
                                {
                                    output = "success",
                                    msg = "Hospital Information  is Updated successfully."
                                }, formatter);
                        }
                        else
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation
                                {
                                    output = "error",
                                    msg = "Hospital Information  is not Updated successfully."
                                }, formatter);
                        }

                    }
                    else
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new Confirmation
                            {
                                output = "error",
                                msg = "Hospital Information  is not Updated successfully."
                            }, formatter);
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
        public HttpResponseMessage Delete([FromBody]Models.meta_info ometinfo)
        {

            try
            {
                bool delete = metainforepository.DelateInfo(ometinfo.meta_info_id);
                if (delete == true)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Hospital Information  is deleted successfully." }, formatter);
                }
                else
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "error", msg = "Hospital Information  is not deleted succesfully." }, formatter);
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
