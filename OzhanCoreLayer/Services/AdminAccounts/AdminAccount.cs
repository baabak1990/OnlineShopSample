using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OzhanCoreLayer.Utilities.FIxer;
using OzhanCoreLayer.Utilities.Security;
using OzhanCoreLayer.Utilities.UniqNameGenerator;
using OzhanCoreLayer.ViewModels.AdminVm;
using OzhanCoreLayer.ViewModels.AdminVm.Convertors;
using OzhanDataLayer.Context;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.Services.AdminAccounts
{
    public class AdminAccount : IAdminAccountService
    {
        #region Constructor

        private readonly OzhanContext _context;
        private readonly ISecurityService _Security;

        public AdminAccount(OzhanContext context, ISecurityService security)
        {
            _context = context;
            _Security = security;
        }

        #endregion

        public async Task<AdminCreateOrEditViewModel> Find(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminCreateOrEditViewModel> Add(AdminCreateOrEditViewModel vm)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminCreateOrEditViewModel> Edit(AdminCreateOrEditViewModel vm)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AdminIndexViewModel>> GetAll()
        {
            return await _context.Users.ConvertModelToAdminIndexVm().ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminIndexViewModel> GetAllByFilters(string EmailFilter = "", string FilterByUserName = "",
            int page = 1)
        {
            var Userlist = await _context.Users.ConvertModelToAdminIndexVm().ToListAsync();
            if (!string.IsNullOrEmpty(FilterByUserName))
            {
                Userlist = await _context.Users
                    .Where(u => u.UserName.Contains(FilterByUserName)).ConvertModelToAdminIndexVm().ToListAsync();
            }

            if (!string.IsNullOrEmpty(EmailFilter))
            {
                Userlist = await _context.Users
                    .Where(u => u.Email.Contains(EmailFilter)).ConvertModelToAdminIndexVm().ToListAsync();
            }

            //paging
            int take = 30;
            int skip = (page - 1) * take;
            AdminIndexViewModel list = new AdminIndexViewModel();
            list.CurrentPage = page;
            list.PageCount = Userlist.Count() / take;
            list.ListOfUsers = _context.Users.OrderBy(u => u.CreateDate).Skip(skip).Take(take).ToList();
            return list;

        }

        public async Task<long> AddUserFromAdmin(AdminCreateOrEditViewModel model)
        {
            User user = new User();
            user.UserName = model.Username.Fixed();
            user.Email = model.Email.Fixed();
            user.ActiveCode = NameGenerator.UniqName();
            user.Password = _Security.HashPassword(model.Password);
            user.CreateDate = DateTime.Now;
            user.IsActive = true;
            //Add image
            if (model.UserAvatar != null)
            {
                var imagePath = "";
                if (user.ImageName != "Profile.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory() + "wwwroot/UserPanel/Pic" +
                                             user.ImageName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }

                }

                user.ImageName = "Pic" + NameGenerator.UniqName() + Path.GetExtension(model.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/UserPanel/assets/Pic/" +
                                         user.ImageName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.UserAvatar.CopyTo(stream);
                }
            }

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> IsUserExistByEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> IsUserExistByUserName(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username);
        }

        public async Task<EdidUserFromAdmin> GetUserForShow(long userId)
        {
            return await _context.Users.Where(u => u.Id == userId).Select(u => new EdidUserFromAdmin()
            {
                Id = u.Id,
                Email = u.Email,
                CreateDate = u.CreateDate,
                Password = u.Password,
                ModifyDate = u.ModifyDate,
                UserImage = u.ImageName,
                Username = u.UserName,
                IsActive = u.IsActive,
                SelectedRoles = u.UserRoles.Select(r => r.RoleP_Id).ToList()
            }).SingleAsync();
        }


        public User GetUserByUserNameForAdmin(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username);
        }

        public User GetUserByIdForAdmin(long userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public void EditUserFromAdmin(EdidUserFromAdmin model)
        {
            var user = GetUserByIdForAdmin(model.Id);
            try
            {
                if (user != null)
                {
                    user.Email = model.Email.Fixed();
                    if (!string.IsNullOrEmpty(model.Password))
                    {
                        user.Password = _Security.HashPassword(model.Password);
                    }
                    user.ModifyDate = DateTime.Now;
                    if (model.UserAvatar != null)
                    {
                        var imagePath = "";
                        if (user.ImageName != "Profile.jpg")
                        {
                            imagePath = Path.Combine(Directory.GetCurrentDirectory() + "wwwroot/UserPanel/Pic" +
                                                     user.ImageName);
                            if (File.Exists(imagePath))
                            {
                                File.Delete(imagePath);
                            }

                        }

                        user.ImageName = "Pic" + NameGenerator.UniqName() +
                                         Path.GetExtension(model.UserAvatar.FileName);
                        imagePath = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/UserPanel/assets/Pic/" +
                                                 user.ImageName);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            model.UserAvatar.CopyTo(stream);
                        }
                    }

                    _context.Users.Update(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }
        }

    }
}


