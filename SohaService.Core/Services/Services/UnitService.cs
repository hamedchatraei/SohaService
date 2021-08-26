using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SohaService.Core.DTOs.Unit;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Context;
using SohaService.DataLayer.Entities.Unit;

namespace SohaService.Core.Services.Services
{
    public class UnitService : IUnitService
    {
        private SohaServiceContext _context;

        public UnitService(SohaServiceContext context)
        {
            _context = context;
        }


        #region Unit

        public int AddUnit(Unit unit)
        {
            _context.Units.Add(unit);
            _context.SaveChanges();
            return unit.UnitId;
        }

        public void DeleteUnit(int unitId)
        {
            Unit unit = GetUnitById(unitId);
            unit.IsDelete = true;
            UpdateUnit(unit);
        }

        public void EditUnit(Unit unit)
        {
            Unit editUnit = GetUnitById(unit.UnitId);
            editUnit.UnitName = unit.UnitName;
            UpdateUnit(editUnit);
        }

        public Unit GetDataForEditUnit(int unitId)
        {
            return _context.Units.Where(u => u.UnitId == unitId).Select(u => new Unit()
            {
                UnitId = unitId,
                UnitName = u.UnitName
            }).Single();
        }

        public UnitViewModel GetDeletedUnit(int pageId = 1, string filterName = "")
        {
            IQueryable<Unit> result = _context.Units.Where(u=>u.IsDelete);

            if (!string.IsNullOrEmpty(filterName))
            {
                result = result.Where(a => a.UnitName.Contains(filterName));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            UnitViewModel list = new UnitViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.Units = result.OrderBy(u => u.UnitName).Skip(skip).Take(take).ToList();

            return list;
        }

        public UnitViewModel GetUnit(int pageId = 1, string filterName = "")
        {
            IQueryable<Unit> result = _context.Units.Where(u=>u.IsDelete==false);

            if (!string.IsNullOrEmpty(filterName))
            {
                result = result.Where(a => a.UnitName.Contains(filterName));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            UnitViewModel list = new UnitViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.Units = result.OrderBy(u => u.UnitName).Skip(skip).Take(take).ToList();

            return list;
        }

        public Unit GetUnitById(int unitId)
        {
            return _context.Units.Find(unitId);
        }

        public void UpdateUnit(Unit unit)
        {
            _context.Units.Update(unit);
            _context.SaveChanges();
        }

        public List<SelectListItem> GetUnitListItem()
        {
            return _context.Units.Where(u=>u.IsDelete==false).Select(s => new SelectListItem()
            {
                Text = s.UnitName,
                Value = s.UnitId.ToString()

            }).ToList();
        }

        #endregion

        #region UnitStatus

        public int AddUnitStatus(UnitStatus unit)
        {
            _context.UnitStatus.Add(unit);
            _context.SaveChanges();
            return unit.UnitStatusId;
        }

        public void DeleteUnitStatus(int unitId)
        {
            UnitStatus unitStatus = GetUnitStatusById(unitId);
            unitStatus.IsDelete = true;
            UpdateUnitStatus(unitStatus);
        }


        public void EditUnitStatus(UnitStatus unit)
        {
            UnitStatus editUnitStatus = GetUnitStatusById(unit.UnitStatusId);
            editUnitStatus.UnitStatusTitle = unit.UnitStatusTitle;
            UpdateUnitStatus(editUnitStatus);
        }

        public UnitStatus GetDataForEditUnitStatus(int unitId)
        {
            return _context.UnitStatus.Where(u => u.UnitStatusId == unitId).Select(u => new UnitStatus()
            {
                UnitStatusId = unitId,
                UnitStatusTitle = u.UnitStatusTitle
            }).Single();
        }

        public UnitStatusViewModel GetDeletedStatus(int pageId = 1, string filterTitle = "")
        {
            IQueryable<UnitStatus> result = _context.UnitStatus.IgnoreQueryFilters().Where(e => e.IsDelete);

            if (!string.IsNullOrEmpty(filterTitle))
            {
                result = result.Where(a => a.UnitStatusTitle.Contains(filterTitle));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            UnitStatusViewModel list = new UnitStatusViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.UnitStatus = result.OrderBy(u => u.UnitStatusTitle).Skip(skip).Take(take).ToList();

            return list;
        }

        public UnitStatusViewModel GetUnitStatus(int pageId = 1, string filterTitle = "")
        {
            IQueryable<UnitStatus> result = _context.UnitStatus.Where(u=>u.UnitStatusId!=1);

            if (!string.IsNullOrEmpty(filterTitle))
            {
                result = result.Where(a => a.UnitStatusTitle.Contains(filterTitle));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            UnitStatusViewModel list = new UnitStatusViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.UnitStatus = result.OrderBy(u => u.UnitStatusTitle).Skip(skip).Take(take).ToList();

            return list;
        }

        public UnitStatus GetUnitStatusById(int unitId)
        {
            return _context.UnitStatus.Find(unitId);
        }

        public void UpdateUnitStatus(UnitStatus unit)
        {
            _context.UnitStatus.Update(unit);
            _context.SaveChanges();
        }

        public List<SelectListItem> GetUnitStatusListItem()
        {
            return _context.UnitStatus.Where(u => u.IsDelete == false && u.UnitStatusId != 1).Select(s => new SelectListItem()
            {
                Text = s.UnitStatusTitle,
                Value = s.UnitStatusId.ToString()

            }).ToList();
        }

        #endregion

    }
}
