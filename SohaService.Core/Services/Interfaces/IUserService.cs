using System;
using System.Collections.Generic;
using System.Text;
using SohaService.Core.DTOs.User;
using SohaService.DataLayer.Entities.User;

namespace SohaService.Core.Services.Interfaces
{
    public interface IUserService
    {
        int AddUser(User user);
        User LoginUser(LoginViewModel login);

        void UpdateUser(User user);
        InformationUserViewModel GetUserInformation(string userName);
        InformationUserViewModel GetUserInformation(int userId);
        User GetUserByUserName(string userName);
        SideBarUserPanelViewModel GetSideBarUserPanelData(string userName);
        EditProfileViewModel GetDataForEditProfileUser(string userName);
        void EditProfile(string userName, EditProfileViewModel profile);
        bool CompareOldPassword(string oldPassword, string userName);
        void ChangeUserPassword(string userName, string newPassword);
        UserForAdminViewModel GetUsers(int pageId, string filterEmail, string filterUserName);
        int AddUserFromAdmin(CreateUserViewModel user);
        EditUserViewModel GetUserForShowInEditMode(int userId);
        void EditUserFromAdmin(EditUserViewModel editUser);
        User GetUserById(int userId);
        UserForAdminViewModel GetDeleteUsers(int pageId = 1, string filterEmail = "", string filterUserName = "");
        void DeleteUser(int userId);
        List<int> GetUserRoles(int userId);
        int GetUserIdByUserName(string userName);
    }
}
