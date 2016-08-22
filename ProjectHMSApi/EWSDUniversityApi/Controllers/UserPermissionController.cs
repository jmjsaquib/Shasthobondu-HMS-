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
using HMSDevelopmentApi.Models.StronglyType;

namespace HMSDevelopmentApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserPermissionController : ApiController
    {
        private IUserPermissionRepository userPermissionRepository;

        public UserPermissionController()
        {
            this.userPermissionRepository = new UserPermissionRepository();
        }

        [HttpGet, ActionName("GetMenuPermissionForRole")]
        public HttpResponseMessage GetMenuPermissionForRole(string role_id)
        {
            var permissionList = userPermissionRepository.GetAllPermissionForRole(int.Parse(role_id));
            dynamic moduleList = userPermissionRepository.GetAllModuleForRole();

            if (permissionList.Count !=0)
            {
                List<UserMenuPermissionModel> tmpModel = new List<UserMenuPermissionModel>();
                foreach (module item in moduleList)
                {
                    UserMenuPermissionModel model = new UserMenuPermissionModel();
                    model.module_id = item.module_id;
                    model.module_name = item.module_name;
                    model.module_parent_id = item.module_parent_id;
                    model.module_url = item.module_url;
                    model.module_alias = item.module_alias;
                    model.module_icon = item.module_icon;
                    foreach (role_permission roleItem in permissionList)
                    {
                        if (roleItem.module_id==item.module_id)
                        {
                            model.module_status = true;
                        }
                    }
                    tmpModel.Add(model);

                }
                var format_type = RequestFormat.JsonFormaterString();
                return Request.CreateResponse(HttpStatusCode.OK, tmpModel, format_type);
            }
            else
            {
                var format_type = RequestFormat.JsonFormaterString();
                return Request.CreateResponse(HttpStatusCode.OK, "There is no permission from this role", format_type);
            }


        }
    }
}
