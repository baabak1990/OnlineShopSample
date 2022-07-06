using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using OzhanCoreLayer.Services.AccountServices;
using OzhanCoreLayer.Utilities.EmailSender;
using OzhanCoreLayer.Utilities.Security;
using OzhanCoreLayer.Utilities.ViewToString;
using OzhanCoreLayer.ViewModels.AccountVM;
using OzhanCoreLayer.ViewModels.AccountVM.ForgetPassword;
using OzhanCoreLayer.ViewModels.AccountVM.LoginVm;
using OzhanCoreLayer.ViewModels.AccountVM.RegisterVm;
using OzhanCoreLayer.ViewModels.AccountVM.ResetPassword;

namespace OzhanITFinalVersion.Areas.Accounts.Controllers
{

    public class AccountController : BaseController
    {
        private readonly IAccountServices _services;
        private readonly ICaptchaValidator _captcha;
        private readonly IViewRenderService _render;
        private readonly ISecurityService _security;

        public AccountController(IAccountServices services, ICaptchaValidator captcha, IViewRenderService render, ISecurityService security)
        {
            _services = services;
            _captcha = captcha;
            _render = render;
            _security = security;
        }
        #region Register
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(registerUserForCreateViewModel vm)
        {
            #region Capcha

            //if (!await _captcha.IsCaptchaPassedAsync(vm.Capcha))
            //{
            //    ModelState.AddModelError("Email", "کد کپچا تایید نشد");
            //}

            #endregion
            #region Validations

            if (_services.IsEmailExist(vm.Email))
            {
                ModelState.AddModelError("Email", "این ایمیل قبلا ثبت شده است ");
                return View(vm);
            }
            if (_services.IsUserNameExist(vm.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری معتبر نمی باشد ");
                return View(vm);
            }
            if (vm.UserName.ToLower().Contains("admin"))
            {
                ModelState.AddModelError("Username", "نام کاربری معتبر نمی باشد ");
                return View(vm);
            }

            #endregion
            //for activation view 
            await _services.AddAsync(vm);
            var user = await _services.GetUserForActivationModel(vm.UserName);
            var body = _render.RenderToStringAsync("_ActivarionCode", user);
            SendEmail.Send(vm.Email, "فعالسازی خساب کاربری", body);
            return View("SuccsesFullRegister");
        }

        #endregion
        #region Login

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginVm vm)
        {

            #region Capcha

            //if (!await _captcha.IsCaptchaPassedAsync(vm.Capcha))
            //{
            //    ModelState.AddModelError("Email", "کد کپچا تایید نشد");
            //}

            #endregion
            #region Validations

            if (!await _services.IsUserExist(vm))
            {
                ModelState.AddModelError("Email", "کاربری با این مشخصات یافت نشد");
                return View(vm);
            }

            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("Email", "لطفا تما فیلدها را پر کنید");
            //    return View(vm);
            //}

            #endregion

            if (!ModelState.IsValid)
            {
                var user = await _services.GetUserByEmail(vm.Email);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, vm.Email),
                    new Claim(ClaimTypes.Name,user.UserName)

                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = vm.RememberMe
                };

                await HttpContext.SignInAsync(principal, properties);
                return RedirectToAction("Index", "UserPanel", new { area = "Accounts" });
            }

            return View(vm);
        }
        #endregion
        #region LogOut
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index", "Home");
        }


        #endregion
        #region Active Account

        [Route("ActiveAccount/{code}")]
        public async Task<IActionResult> ActiveAccount(string code)
        {
            if (!await _services.IsAccountActive(code))
            {
                return NotFound();
            }

            return View();
        }

        #endregion
        #region ForgotPassword

        [HttpGet("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel vm)
        {
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("Email", "لطفا ایمیل خود را وارد نمایید!");
            //    return View(vm);
            //}

            if (!await _services.IsUserExistedByEmail(vm.Email))
            {
                ModelState.AddModelError("Email", "کاربری با این ایمیل یافت نشد");
                return View(vm);
            }

            var user = await _services.GetUserByEmailForResetPassword(vm.Email);
            var body = _render.RenderToStringAsync("_SendEmailForResetPassword", user);
            SendEmail.Send(vm.Email, "بازیابی کلمه عبور", body);
            ViewBag.IsSuccses = true;
            return View();
        }
        #endregion
        #region ResetPassword

        [HttpGet("ResetPassword/{code}")]
        public IActionResult ResetPassword(string code)
        {
            //Be Causes 
            return View(new ResetPasswordVm()
            {
                ActiveCode = code
            });
        }

        [HttpPost("ResetPassword/{code}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVm vm)
        {
            //if (!await _captcha.IsCaptchaPassedAsync(vm.Capcha))
            //{
            //    ModelState.AddModelError("Password","کد کپچا تایید نشد !");
            //    return View(vm);
            //}

            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("Password","لطفا تمام فیلدها را پر کنید < کلمه عبور و تکرار آن باید مشابه هم باشند !");
            //    return View(vm);
            //}
            var Isuser = await _services.IsUSerExistByActiveCode(vm.ActiveCode);
            var newpass = _security.HashPassword(vm.Password);
            if (Isuser == false)
            {
                return NotFound();
            }

            var user = await _services.GetUserByActivecodeForResetPassword(vm.ActiveCode);
            user.Password = newpass;
            _services.UpdateUSerAfterResetPassword(user);
            return RedirectToAction("Login", "Account", new { area = "Accounts" });
        }
        #endregion
    }
}
