using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OzhanCoreLayer.Utilities.Security;
using OzhanCoreLayer.Utilities.UniqNameGenerator;
using OzhanCoreLayer.ViewModels.AccountVM.UserPanelViewModels;
using OzhanCoreLayer.ViewModels.AccountVM.UserPanelViewModels.EditUserPanelViewModel;
using OzhanDataLayer.Context;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.Services.UserPanelServices
{
    public class UserPanelServices : IUserPanelServices
    {
        #region Constructor
        private readonly OzhanContext _context;
        private readonly ISecurityService _security;

        public UserPanelServices(OzhanContext context, ISecurityService security)
        {
            _context = context;
            _security = security;
        }


        #endregion
        public User GetUserByUserName(string username)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == username);
            return user;
        }

        public UserPanelInformationForShow showUserInfo(string username)
        {
            var user = GetUserByUserName(username);
            UserPanelInformationForShow info = new UserPanelInformationForShow();
            info.Email = user.Email;
            info.UserName = user.UserName;
            info.CreateDate = user.CreateDate;
            info.Name = user.Name;
            info.Family = user.Family;
            info.ModifyDate = user.ModifyDate;
            info.Wallet = 0;
            info.AvatarName = user.ImageName;
            return info;
        }

        public EditUserPanelViewModel showUserInfoForEdit(string username)
        {
            var user = GetUserByUserName(username);
            EditUserPanelViewModel edit = new EditUserPanelViewModel();
            edit.Email = user.Email;
            edit.Name = user.Name;
            edit.Family = user.Family;
            edit.ImageName = user.ImageName;
            edit.UserName = user.UserName;
            return edit;

        }

        public void UpdateUser(string UserName, EditUserPanelViewModel model)
        {
            //Saving or changing Image
            try
            {
                if (model.AvatarName != null)
                {
                    var imagePath = "";
                    if (model.ImageName != "Profile.jpg")
                    {
                        imagePath = Path.Combine(Directory.GetCurrentDirectory() + "wwwroot/UserPanel/Pic" +
                                                 model.ImageName);
                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }

                    }

                    model.ImageName = "Pic" + NameGenerator.UniqName() + Path.GetExtension(model.AvatarName.FileName);
                    imagePath = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/UserPanel/assets/Pic/" +
                                            model.ImageName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        model.AvatarName.CopyTo(stream);
                    }
                }

                var user = GetUserByUserName(UserName);
                user.Name = model.Name;
                user.Family = model.Family;
                user.Email = model.Email;
                user.ModifyDate = DateTime.Now;
                user.ImageName = model.ImageName;
                _context.Update(user);
                _context.SaveChanges();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> IsOldPasswordIsCorrct(string userName, string oldpassword)
        {
            try
            {
                var oldhashedPassword = _security.HashPassword(oldpassword);
                var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);
                if (user == null)
                {
                    return false;
                }

                return _security.VerifyHashedPassword(user.Password, oldpassword);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void ChangePassword(string username, string password)
        {
            var user = GetUserByUserName(username);
            user.Password = _security.HashPassword(password);
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
