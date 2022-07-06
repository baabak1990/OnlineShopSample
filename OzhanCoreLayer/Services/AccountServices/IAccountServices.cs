using System.Threading.Tasks;
using OzhanCoreLayer.Services.GeneralServices;
using OzhanCoreLayer.ViewModels.AccountVM.AccountActivationAndResetPassword;
using OzhanCoreLayer.ViewModels.AccountVM.ForgetPassword;
using OzhanCoreLayer.ViewModels.AccountVM.LoginVm;
using OzhanCoreLayer.ViewModels.AccountVM.RegisterVm;
using OzhanCoreLayer.ViewModels.AccountVM.ResetPassword;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.Services.AccountServices
{
    public interface IAccountServices : IGeneralServices<long, registerUserForEditViewModel, registerUserForCreateViewModel>
    {
        bool IsEmailExist(string email);
        bool IsUserNameExist(string Username);
        Task<bool> AddAsync(registerUserForCreateViewModel vm);
        Task<bool> IsUserExist(LoginVm vm);
        Task<LoginVm> GetUserByEmail(string email);
        Task<ForgotPasswordViewModel> GetUserByEmailForResetPassword(string email);
        Task<ResetPasswordVm> GetUserByActivecodeForResetPassword(string code);
        Task<bool> IsAccountActive(string code);
        Task<AccountActivationAndResetPasswordvm> GetUserForActivationModel(string username);
        Task<bool> IsUserExistedByEmail(string email);
        Task<User> ResetUserPassword();
        Task<bool> IsUSerExistByActiveCode(string code);
        void UpdateUSerAfterResetPassword(ResetPasswordVm vm);
    }
}