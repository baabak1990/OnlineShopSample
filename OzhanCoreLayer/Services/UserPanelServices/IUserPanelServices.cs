using System.Threading.Tasks;
using OzhanCoreLayer.ViewModels.AccountVM.UserPanelViewModels;
using OzhanCoreLayer.ViewModels.AccountVM.UserPanelViewModels.EditUserPanelViewModel;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.Services.UserPanelServices
{
    public interface IUserPanelServices
    {
        User GetUserByUserName(string username);
        UserPanelInformationForShow showUserInfo(string username);
        EditUserPanelViewModel showUserInfoForEdit(string username);
        void UpdateUser(string UserName, EditUserPanelViewModel model);
        Task<bool> IsOldPasswordIsCorrct(string userName, string oldpassword);
        void ChangePassword(string username, string password);
    }
}