using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzhanCoreLayer.Services.AdminAccounts;
using OzhanCoreLayer.Services.PermissionServices;
using OzhanCoreLayer.Utilities.Security.PermissionsAttribute;
using OzhanCoreLayer.ViewModels.AdminVm;

namespace OzhanITFinalVersion.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseAdminController
    {
        #region Constructor

        private readonly IAdminAccountService _services;
        private readonly IPermissionServices _permissionServices;
        public AdminHomeController(IAdminAccountService services, IPermissionServices permissionServices)
        {
            _services = services;
            _permissionServices = permissionServices;
        }

        #endregion

        [Route("Admin-Home")]
        public IActionResult Index()
        {
            return View();
        }

        #region Users Manaegment

        [Route("Users-Management")]
        public async Task<IActionResult> ShowUsers(string EmailFilter = "", string FilterByUserName = "",
            int page = 1)
        {

            return View(await _services.GetAllByFilters(FilterByUserName, EmailFilter, page));
        }
        [PermissionChecker(3)]
        [HttpGet("Add_user")]
        public async Task<IActionResult> AddUser()
        {
            ViewData["roles"] = await _permissionServices.GetAll();
            return View();
        }

        [HttpPost("Add_user")]
        public async Task<IActionResult> AddUser(AdminCreateOrEditViewModel vm, List<byte> SelectedRole)
        {
            ViewData["roles"] = await _permissionServices.GetAll();

            if (await _services.IsUserExistByEmail(vm.Email))
            {
                ModelState.AddModelError("Email", "نمی توانید این ایمیل را ثبت کنید");
                return View(vm);
            }
            if (await _services.IsUserExistByUserName(vm.Username))
            {
                ModelState.AddModelError("UserName", "نمی توانید این نام کاربری را ثبت کنید");
                return View(vm);
            }

            var userid = await _services.AddUserFromAdmin(vm);
            _permissionServices.AddRoleToUser(userid, SelectedRole);
            return RedirectToAction("ShowUsers");
        }

        [HttpGet("EditUser-Admin/{Id}")]
        public async Task<IActionResult> EditUserFromAdmin(long Id)
        {
            ViewData["roles"] = await _permissionServices.GetAll();
            return View(await _services.GetUserForShow(Id));
        }

        [HttpPost("EditUser-Admin/{Id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserFromAdmin(EdidUserFromAdmin vm, List<byte> SelectedRole)
        {

            ViewData["roles"] = await _permissionServices.GetAll();
            _services.EditUserFromAdmin(vm);
            //Todo: edit Roles
            await _permissionServices.EditRoleToUser(vm.Id, SelectedRole);
            return View(await _services.GetUserForShow(vm.Id));
        }
        #endregion
    }
}
