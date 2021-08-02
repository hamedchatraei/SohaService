using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SohaService.Core.DTOs.User;
using SohaService.Core.Security;
using SohaService.Core.Services.Interfaces;

namespace SohaService.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [PermissionChecker(1)]
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IPermissionService _permissionService;

        public HomeController(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        public IActionResult Index(int pageId = 1, string filterUserName = "", string filterEmail = "")
        {
            UserForAdminViewModel user = _userService.GetUsers(pageId, filterEmail, filterUserName);
            return View(user);
        }

        #region Create User

        [Route("CreateUser")]
        public IActionResult CreateUser()
        {
            ViewData["Roles"] = _permissionService.GetRoles();
            return View();
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(List<int> selectedRoles, CreateUserViewModel user)
        {
            if (!ModelState.IsValid)
                return View();

            int userId = _userService.AddUserFromAdmin(user);

            //Add Roles
            _permissionService.AddRolesToUser(selectedRoles, userId);

            return Redirect("/AdminPanel");
        }

        #endregion

        #region Edit User

        [Route("EditUser/{id}")]
        public IActionResult EditUser(int id)
        {
            EditUserViewModel editUser = _userService.GetUserForShowInEditMode(id);
            ViewData["Roles"] = _permissionService.GetRoles();
            return View(editUser);
        }

        [HttpPost]
        [Route("EditUser/{id}")]
        public IActionResult EditUser(List<int> selectedRoles, EditUserViewModel editUser)
        {
            if (!ModelState.IsValid)
                return View(editUser);

            _userService.EditUserFromAdmin(editUser);

            _permissionService.EditRolesUser(editUser.UserId, selectedRoles);

            return Redirect("/AdminPanel");
        }

        #endregion

        #region List Deleted User

        [Route("ListDeleteUser")]
        public IActionResult ListDeleteUser(int pageId = 1, string filterUserName = "", string filterEmail = "")
        {
            UserForAdminViewModel user = _userService.GetDeleteUsers(pageId, filterEmail, filterUserName);
            return View(user);
        }

        #endregion

        #region Delete User

        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            ViewData["UserId"] = id;
            InformationUserViewModel information = _userService.GetUserInformation(id);
            return View(information);
        }

        [HttpPost]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(string id)
        {
            int userId = Convert.ToInt32(id);

            _userService.DeleteUser(userId);

            return Redirect("/AdminPanel");
        }

        #endregion
    }
}
