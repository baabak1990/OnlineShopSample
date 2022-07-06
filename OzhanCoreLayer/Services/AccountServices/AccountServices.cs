using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OzhanCoreLayer.Utilities.FIxer;
using OzhanCoreLayer.Utilities.Security;
using OzhanCoreLayer.Utilities.UniqNameGenerator;
using OzhanCoreLayer.ViewModels.AccountVM;
using OzhanCoreLayer.ViewModels.AccountVM.AccountActivationAndResetPassword;
using OzhanCoreLayer.ViewModels.AccountVM.ForgetPassword;
using OzhanCoreLayer.ViewModels.AccountVM.LoginVm;
using OzhanCoreLayer.ViewModels.AccountVM.RegisterVm;
using OzhanCoreLayer.ViewModels.AccountVM.ResetPassword;
using OzhanDataLayer.Context;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.Services.AccountServices
{
    public class AccountServices : IAccountServices
    {
        #region Constructor

        private readonly OzhanContext _context;
        private readonly ISecurityService _security;

        public AccountServices(OzhanContext context, ISecurityService security)
        {
            _context = context;
            _security = security;
        }

        #endregion
        public Task<registerUserForCreateViewModel> Find(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<registerUserForCreateViewModel> Add(registerUserForCreateViewModel vm)
        {
            var user = new User();
            try
            {
                var mail = vm.Email.Fixed();
                var uName = vm.UserName.Fixed();
                var HasedPass = _security.HashPassword(vm.Password);
                if (!IsEmailExist(vm.Email) && !IsUserNameExist(vm.UserName))
                {

                    user.Email = mail;
                    user.UserName = uName;
                    user.CreateDate = DateTime.Now;
                    user.ImageName = "Default";
                    user.ActiveCode = NameGenerator.UniqName();
                    user.Password = HasedPass;
                    user.IsActive = false;
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

            }
            return user.registerModelToVm();
        }

        public async Task<bool> AddAsync(registerUserForCreateViewModel vm)
        {

            try
            {
                var mail = vm.Email.Fixed();
                var uName = vm.UserName.Fixed();
                var HasedPass = _security.HashPassword(vm.Password);
                if (!IsEmailExist(vm.Email) && !IsUserNameExist(vm.UserName))
                {
                    var user = new User()
                    {
                        UserName = uName,
                        CreateDate = DateTime.Now,
                        ImageName = "Profile.jpg",
                        ActiveCode = NameGenerator.UniqName(),
                        Password = HasedPass,
                        Email = mail,
                        IsActive = false,
                        UserDetai_Id = null,
                        ModifyDate = null,
                        IsDeleted = false,
                        Family = "",
                        Name = ""
                    };
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();

                }
            }

            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsUserExist(LoginVm vm)
        {
            var mail = vm.Email.Fixed();
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == mail);
            if (user != null)
            {
                return _security.VerifyHashedPassword(user.Password, vm.Password);
            }

            return false;
        }

        public async Task<LoginVm> GetUserByEmail(string email)
        {
            var mail = email.Fixed();
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == mail);
            return user.convetModelToLogin();
        }

        public async Task<ForgotPasswordViewModel> GetUserByEmailForResetPassword(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            return user.convertToPassVm();
        }

        public async Task<ResetPasswordVm> GetUserByActivecodeForResetPassword(string code)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.ActiveCode == code);
            return user.ConvertToPasswordVm();
        }

        public async Task<bool> IsAccountActive(string code)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.ActiveCode == code);
            if (user == null || user.IsActive)
            {
                return false;
            }

            user.IsActive = true;
            user.ActiveCode = Guid.NewGuid().ToString().Replace("-", "");
            _context.Update(user);
            await _context.SaveChangesAsync();
            var userVm = user.convertToActive();
            return true;
        }

        public async Task<AccountActivationAndResetPasswordvm> GetUserForActivationModel(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
            return user.convertToActive();
        }

        public async Task<bool> IsUserExistedByEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public Task<User> ResetUserPassword()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsUSerExistByActiveCode(string code)
        {
            return await _context.Users.AnyAsync(u => u.ActiveCode == code);
        }

        public void UpdateUSerAfterResetPassword(ResetPasswordVm vm)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == vm.ActiveCode);
            if (user != null)
            {
                user.Password = vm.Password;
                _context.Update(user);
            }

            _context.SaveChanges();
        }

        public Task<registerUserForCreateViewModel> Edit(registerUserForCreateViewModel vm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<registerUserForEditViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsEmailExist(string email)
        {
            var mail = email.Fixed();
            return _context.Users.Any(u => u.Email == mail);
        }

        public bool IsUserNameExist(string Username)
        {
            var name = Username.Fixed();
            return _context.Users.Any(u => u.UserName == name);
        }


    }
}
