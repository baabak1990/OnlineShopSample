using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using OzhanCoreLayer.Services.PermissionServices;

namespace OzhanCoreLayer.Utilities.Security.PermissionsAttribute
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IPermissionServices _permissionServices;
        private readonly int _PermissionId = 0;
        public PermissionCheckerAttribute(int permissionId)
        {
            _PermissionId = permissionId;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Az in targih be permission vorodi method dast resi darim
            _permissionServices = (IPermissionServices)context.HttpContext.RequestServices.GetService(typeof(IPermissionServices));
            //inja aval check mikonim ke karbar Athunticate shode ya na
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = context.HttpContext.User.Identity.Name;
                if (!_permissionServices.UserRoles(user, _PermissionId))
                {
                    context.Result = new RedirectResult("Index");
                }
            }
            else
            {
                //TODO : Url is wrong 
                //check the url
                context.Result = new RedirectResult("Index");
            }
        }
    }
}
