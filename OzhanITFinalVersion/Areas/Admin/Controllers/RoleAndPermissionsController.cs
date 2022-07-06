using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzhanCoreLayer.Services.PermissionServices;
using OzhanCoreLayer.ViewModels.PermissionsViewModels;

namespace OzhanITFinalVersion.Areas.Admin.Controllers
{

    public class RoleAndPermissionsController : BaseAdminController
    {
        #region Constructor

        private readonly IPermissionServices _services;

        public RoleAndPermissionsController(IPermissionServices services)
        {
            _services = services;
        }

        #endregion

        #region Crud

        [Route("ShowAllRoles")]
        public async Task<IActionResult> Index()
        {

            return View(await _services.GetAll());
        }

        [Route("Addrole")]
        public async Task<IActionResult> AddRole()
        {
            ViewData["Permissions"] = await _services.GetAllPermissions();
            return View();
        }

        [HttpPost]
        [Route("Addrole")]
        public async Task<IActionResult> AddRole(RoleCreateVm vm, List<int> SelectedRole)
        {
            ViewData["Permissions"] = await _services.GetAllPermissions();


            var roleId = await _services.AddRole(vm);
            _services.AddPermissionToRole(roleId, SelectedRole);
            return RedirectToAction("Index", "RoleAndPermissions", new { area = "Admin" });
        }

        [HttpGet("Editrole/{Id}")]
        public async Task<IActionResult> EditRole(byte Id)
        {
            ViewData["SelectedRoles"] = await _services.GetSelectedRolesForEdit(Id);
            ViewData["Permissions"] = await _services.GetAllPermissions();
            return View(await _services.FindRole(Id));
        }


        [HttpPost("Editrole/{Id}")]
        public async Task<IActionResult> EditRole(RoleEditVM model, List<int> SelectedRole)
        {
            ViewData["Permissions"] = await _services.GetAllPermissions();
            ViewData["SelectedRoles"] = await _services.GetSelectedRolesForEdit(model.Id);
            await _services.EditRole(model);
            _services.EditPermissionRoles(model.Id, SelectedRole);
            return RedirectToAction("Index", "RoleAndPermissions", new { area = "Admin" });
        }
        #endregion
    }
}
