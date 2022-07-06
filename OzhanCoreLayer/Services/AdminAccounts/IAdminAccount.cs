using System.Collections.Generic;
using System.Threading.Tasks;
using OzhanCoreLayer.Services.GeneralServices;
using OzhanCoreLayer.ViewModels.AdminVm;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.Services.AdminAccounts
{
    public interface IAdminAccountService : IGeneralServices<long, AdminIndexViewModel, AdminCreateOrEditViewModel>
    {
        Task<AdminIndexViewModel> GetAllByFilters(string EmailFilter = "", string FilterByUserName = "",
            int page = 1);

        Task<long> AddUserFromAdmin(AdminCreateOrEditViewModel model);
        Task<bool> IsUserExistByEmail(string email);
        Task<bool> IsUserExistByUserName(string username);
        Task<EdidUserFromAdmin> GetUserForShow(long userId);
        void EditUserFromAdmin(EdidUserFromAdmin model);
        User GetUserByUserNameForAdmin(string username);
        User GetUserByIdForAdmin(long userId);
    }
}