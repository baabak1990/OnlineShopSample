using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OzhanCoreLayer.Services.UserPanelServices;
using OzhanCoreLayer.ViewModels.AccountVM.UserPanelViewModels.EditUserPanelViewModel;
using OzhanCoreLayer.ViewModels.AccountVM.UserPanelViewModels.UserPanelChangePassword;

namespace OzhanITFinalVersion.Areas.Accounts.Controllers
{
    [Authorize]
    public class UserPanelController : BaseController
    {
        #region Constructor

        private readonly IUserPanelServices _Services;

        public UserPanelController(IUserPanelServices services)
        {
            _Services = services;
        }

        #endregion
        [Route("UserPanelIndex")]
      
        public IActionResult Index()
        {
            return View(_Services.showUserInfo(User.Identity.Name));
        }

        #region EditUserPanel

        [HttpGet("Edit-User")]
        public IActionResult EditUserPanel()
        {
            return View(_Services.showUserInfoForEdit(User.Identity.Name));
        }

        [HttpPost("Edit-User")]
        [ValidateAntiForgeryToken]
        public IActionResult EditUserPanel(EditUserPanelViewModel vm)
        {
            _Services.UpdateUser(User.Identity.Name, vm);
            return RedirectToAction("Index", "UserPanel", new { area = "Accounts" });
        }
        #endregion

        #region ChangePassword

        [HttpGet]
        [Route("ChanegUserPanelPassword")]
        [ValidateAntiForgeryToken]
        public IActionResult ChanegUserPanelPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ChanegUserPanelPassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChanegUserPanelPassword(ChangeUserPanelPasswordVm vm)
        {
            var username = User.Identity.Name;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("OldPassword", "لطفا تمامی فیلدها را پر کنید");
                return View(vm);
            }

            if (!await _Services.IsOldPasswordIsCorrct(username, vm.OldPassword))
            {
                ModelState.AddModelError("OldPassword", "کلمه عبور فعلی صحیح نمیباشد !");
                return View(vm);
            }
            //TODO : Fix the view Again
            _Services.ChangePassword(username, vm.Password);
            ViewBag.IsSuccess = true;
            return View("Index");
        }
        #endregion
    }
}
