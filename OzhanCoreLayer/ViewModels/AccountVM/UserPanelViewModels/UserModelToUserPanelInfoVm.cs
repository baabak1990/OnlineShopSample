using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.ViewModels.AccountVM.UserPanelViewModels
{
    public static class UserModelToUserPanelInfoVm
    {
        public static UserPanelInformationForShow modelToUserPanelInfo(this User user)
        {
            return new UserPanelInformationForShow()
            {
                CreateDate = user.CreateDate,
                Email = user.Email,
                Family = user.Family,
                Name = user.Name,
                UserName = user.UserName,
                AvatarName = user.ImageName
                
            };
        }
    }
}
