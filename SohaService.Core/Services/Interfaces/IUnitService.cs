using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SohaService.Core.DTOs.Unit;
using SohaService.DataLayer.Entities.Unit;

namespace SohaService.Core.Services.Interfaces
{
    public interface IUnitService
    {
        #region Unit

        int AddUnit(Unit unit);
        void DeleteUnit(int unitId);
        void EditUnit(Unit unit);
        UnitViewModel GetUnit(int pageId = 1, string filterName = "");
        UnitViewModel GetDeletedUnit(int pageId = 1, string filterName = "");
        Unit GetDataForEditUnit(int unitId);
        Unit GetUnitById(int unitId);
        void UpdateUnit(Unit unit);
        List<SelectListItem> GetUnitListItem();

        #endregion

        #region UnitStatus

        int AddUnitStatus(UnitStatus unit);
        void DeleteUnitStatus(int unitId);
        void EditUnitStatus(UnitStatus unit);
        UnitStatusViewModel GetUnitStatus(int pageId = 1, string filterTitle = "");
        UnitStatusViewModel GetDeletedStatus(int pageId = 1, string filterTitle = "");
        UnitStatus GetDataForEditUnitStatus(int unitId);
        UnitStatus GetUnitStatusById(int unitId);
        void UpdateUnitStatus(UnitStatus unit);
        List<SelectListItem> GetUnitStatusListItem();


        #endregion
    }
}
