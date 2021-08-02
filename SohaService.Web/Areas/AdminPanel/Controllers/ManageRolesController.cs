using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SohaService.Core.Security;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.User;

namespace SohaService.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [PermissionChecker(1)]
    public class ManageRolesController : Controller
    {
        private IPermissionService _permissionService;

        public ManageRolesController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public IActionResult Index()
        {
            List<Role> Rolelist = _permissionService.GetRoles();
            return View(Rolelist);
        }

        #region CreateRole

        [Route("CreateRole")]
        public IActionResult CreateRole()
        {
            ViewData["Permissions"] = _permissionService.GetAllPermission();
            return View();
        }

        [HttpPost]
        [Route("CreateRole")]
        public IActionResult CreateRole(Role role, List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
                return View();

            role.IsDelete = false;

            int roleId = _permissionService.AddRole(role);

            _permissionService.AddPermissionsToRole(role.RoleId, SelectedPermission);

            return Redirect("/AdminPanel/ManageRoles");
        }

        #endregion

        #region EditRole

        [Route("EditRole/{id}")]
        public IActionResult EditRole(int id)
        {
            Role role = _permissionService.GetRoleById(id);
            ViewData["Permissions"] = _permissionService.GetAllPermission();
            ViewData["SelectedPermissions"] = _permissionService.PermissionsRole(id);

            return View(role);
        }

        [HttpPost]
        [Route("EditRole/{id}")]
        public IActionResult EditRole(Role role, List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
                return View();

            _permissionService.UpdateRole(role);

            _permissionService.UpdatePermissionsRole(role.RoleId, SelectedPermission);

            return Redirect("/AdminPanel/ManageRoles");
        }

        #endregion

        #region DeleteRole

        [Route("DeleteRole/{id}")]
        public IActionResult DeleteRole(int id)
        {
            Role role = _permissionService.GetRoleById(id);
            return View(role);
        }

        [HttpPost]
        [Route("DeleteRole/{id}")]
        public IActionResult DeleteRole(Role role)
        {
            _permissionService.DeleteRole(role);

            return Redirect("/AdminPanel/ManageRoles");
        }

        #endregion
    }
}
