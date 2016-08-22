using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.Repository;
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
    public class RoleTypeController : ApiController
    {
          private IRoleTypeRepository roleTypeRepository;

          public RoleTypeController()
          {

              this.roleTypeRepository = new RoleTypeRepository();
        }

        [HttpGet, ActionName("GetAllRoleType")]

          public HttpResponseMessage GetAllRoleType()
        {

            var data = roleTypeRepository.GetAllRoleType();
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetRoleTypeById")]

        public HttpResponseMessage GetRoleTypeById(int roleTypeId)
        {
            var data = roleTypeRepository.GetAllRoleTypeById(roleTypeId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }
        [HttpPost, ActionName("Post")]
        public HttpResponseMessage Post([FromBody]Models.role_type oRoleType) {
            try 
	        {	        
		    if(string.IsNullOrEmpty(oRoleType.role_name)){
                var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Role name can not be empty" });
            }
            else if(string.IsNullOrEmpty(oRoleType.role_description)){
                var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Role Description can not be empty" });
            }else{
            
                bool chkRoleTypeNameDuplicate=roleTypeRepository.CheckDuplicateForRoleTypeName(oRoleType.role_type_id,oRoleType.role_name);
                if(chkRoleTypeNameDuplicate==true){
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Role Name Already Exists" }, formatter);
                }else{
                    Models.role_type insert=new Models.role_type{
                        role_name=oRoleType.role_name,
                        role_description =oRoleType.role_description
                    };
                    bool roleInsert=roleTypeRepository.InsertRoleType(insert);
                    if(roleInsert==true){
                        var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                            new Confirmation { output = "success", msg = "Role Information  is saved successfully." }, formatter);
                    }else{
                        var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                            new Confirmation { output = "success", msg = "Role Information  is not saved successfully." }, formatter);
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
        public HttpResponseMessage Put([FromBody]Models.role_type oRoleType) {
            try
            {
                 if(string.IsNullOrEmpty(oRoleType.role_name)){
                var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Role name can not be empty" });
            }
            else if(string.IsNullOrEmpty(oRoleType.role_description)){
                var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Role Description can not be empty" });
            }
                    Models.role_type update=new Models.role_type{
                        role_type_id=oRoleType.role_type_id,
                        role_name=oRoleType.role_name,
                        role_description=oRoleType.role_description,
                    };
                    bool roleUpdate=roleTypeRepository.UpdateRoleType(update);
                    if(roleUpdate==true){
                        var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                            new Confirmation { output = "success", msg = "Role Information  is updated successfully." }, formatter);
                    }else{
                        var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                            new Confirmation { output = "success", msg = "Role Information  is not updated successfully." }, formatter);
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
        public HttpResponseMessage Delete([FromBody]Models.role_type oRoleType) {
            try
            {
                bool deleteRole = roleTypeRepository.DeleteRoleType(oRoleType.role_type_id);
                if (deleteRole == true)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Role Information  is deleted successfully." }, formatter);
                }
                else {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Role Information  is not deleted successfully." }, formatter);
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
