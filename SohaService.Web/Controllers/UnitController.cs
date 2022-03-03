using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SohaService.Core.DTOs.Unit;
using SohaService.Core.Security;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.Unit;

namespace SohaService.Web.Controllers
{
    public class UnitController : Controller
    {
        private IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        #region Unit

        #region Units

        [PermissionChecker(1031)]
        [Route("Units")]
        public IActionResult Units(int pageId = 1, string filterName = "")
        {
            UnitViewModel unit = _unitService.GetUnit(pageId, filterName);

            return View(unit);
        }

        #endregion

        #region DeletedUnits

        [PermissionChecker(1031)]
        [Route("DeletedUnits")]
        public IActionResult DeletedUnits(int pageId = 1, string filterName = "")
        {
            UnitViewModel unit = _unitService.GetDeletedUnit(pageId, filterName);

            return View(unit);
        }

        #endregion

        #region InformationUnit

        [PermissionChecker(1031)]
        [Route("InformationUnit/{id}")]
        public IActionResult InformationUnit(int id)
        {
            Unit unit = _unitService.GetUnitById(id);

            return View(unit);
        }

        #endregion

        #region AddUnit

        [PermissionChecker(1032)]
        [Route("AddUnit")]
        public IActionResult AddUnit()
        {
            return View();
        }

        [HttpPost]
        [Route("AddUnit")]
        public IActionResult AddUnit(Unit unit)
        {
            if (!ModelState.IsValid)
                return View(unit);

            _unitService.AddUnit(unit);

            int unitId = unit.UnitId;

            return Redirect($"/InformationUnit/{unitId}");
        }

        #endregion

        #region EditUnit

        [PermissionChecker(1033)]
        [Route("EditUnit/{id}")]
        public IActionResult EditUnit(int id)
        {
            Unit unit = _unitService.GetDataForEditUnit(id);

            return View(unit);
        }

        [HttpPost]
        [Route("EditUnit/{id}")]
        public IActionResult EditUnit(Unit unit)
        {
            if (!ModelState.IsValid)
                return View(unit);

            _unitService.EditUnit(unit);

            int unitId = unit.UnitId;

            return Redirect($"/InformationUnit/{unitId}");
        }

        #endregion

        #region DeleteUnit

        [PermissionChecker(1034)]
        [Route("DeleteUnit/{id}")]
        public IActionResult DeleteUnit(int id)
        {
            Unit unit = _unitService.GetUnitById(id);

            return View(unit);
        }

        [HttpPost]
        [Route("DeleteUnit/{id}")]
        public IActionResult DeleteUnit(Unit unit)
        {
            _unitService.DeleteUnit(unit.UnitId);

            return Redirect("/Units");
        }

        #endregion

        #endregion

        #region UnitStatus

        #region UnitStatuses

        [PermissionChecker(1031)]
        [Route("UnitStatuses")]
        public IActionResult UnitStatuses(int pageId = 1, string filterTitle = "")
        {
            UnitStatusViewModel unitStatus = _unitService.GetUnitStatus(pageId, filterTitle);

            return View(unitStatus);
        }

        #endregion

        #region DeletedUnitStatuses

        [Route("DeletedUnitStatuses")]
        public IActionResult DeletedUnitStatuses(int pageId = 1, string filterTitle = "")
        {
            UnitStatusViewModel unitStatus = _unitService.GetDeletedStatus(pageId, filterTitle);

            return View(unitStatus);
        }

        #endregion

        #region InformationUnitStatus

        [PermissionChecker(1031)]
        [Route("InformationUnitStatus/{id}")]
        public IActionResult InformationUnitStatus(int id)
        {
            if (id!=1)
            {
                UnitStatus unitStatus = _unitService.GetUnitStatusById(id);

                return View(unitStatus);
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion

        #region AddUnitStatus

        [PermissionChecker(1035)]
        [Route("AddUnitStatus")]
        public IActionResult AddUnitStatus()
        {
            return View();
        }

        [HttpPost]
        [Route("AddUnitStatus")]
        public IActionResult AddUnitStatus(UnitStatus unitStatus)
        {
            if (!ModelState.IsValid)
                return View(unitStatus);

            _unitService.AddUnitStatus(unitStatus);

            int unitId = unitStatus.UnitStatusId;

            return Redirect($"/InformationUnitStatus/{unitId}");
        }

        #endregion

        #region EditUnitStatus

        [PermissionChecker(1036)]
        [Route("EditUnitStatus/{id}")]
        public IActionResult EditUnitStatus(int id)
        {
            UnitStatus unitStatus = _unitService.GetDataForEditUnitStatus(id);

            return View(unitStatus);
        }

        [HttpPost]
        [Route("EditUnitStatus/{id}")]
        public IActionResult EditUnitStatus(UnitStatus unitStatus)
        {
            if (!ModelState.IsValid)
                return View(unitStatus);

            _unitService.EditUnitStatus(unitStatus);

            int unitId = unitStatus.UnitStatusId;

            return Redirect($"/InformationUnitStatus/{unitId}");
        }

        #endregion

        #region DeleteUnitStatus

        [PermissionChecker(1037)]
        [Route("DeleteUnitStatus/{id}")]
        public IActionResult DeleteUnitStatus(int id)
        {
            UnitStatus unitStatus = _unitService.GetUnitStatusById(id);

            return View(unitStatus);
        }

        [HttpPost]
        [Route("DeleteUnitStatus/{id}")]
        public IActionResult DeleteUnitStatus(UnitStatus unitStatus)
        {
            _unitService.DeleteUnitStatus(unitStatus.UnitStatusId);

            return Redirect("/UnitStatuses");
        }

        #endregion

        #endregion
    }
}
