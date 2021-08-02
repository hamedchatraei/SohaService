using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SohaService.Core.DTOs.Expert;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Context;
using SohaService.DataLayer.Entities.Expert;

namespace SohaService.Core.Services.Services
{
    public class ExpertService : IExpertService
    {
        private SohaServiceContext _context;

        public ExpertService(SohaServiceContext context)
        {
            _context = context;
        }

        public int AddExpert(Expert expert)
        {
            _context.Experts.AddAsync(expert);
            _context.SaveChangesAsync();
            return expert.ExpertId;
        }

        public void DeleteExpert(int expertId)
        {
            Expert expert = GetExpertById(expertId);
            expert.IsDelete = true;
            UpdateExpert(expert);
        }

        public void EditExpert(Expert expert)
        {
            Expert editExpert = GetExpertById(expert.ExpertId);
            editExpert.ExpertName = expert.ExpertName;
            editExpert.ExpertFamily = expert.ExpertFamily;
            editExpert.ExpertMobile = expert.ExpertMobile;
            UpdateExpert(editExpert);
        }

        public Expert GetDataForEditExpert(int expertId)
        {
            return _context.Experts.Where(e => e.ExpertId == expertId).Select(e => new Expert()
            {
                ExpertName = e.ExpertName,
                ExpertFamily = e.ExpertFamily,
                ExpertMobile = e.ExpertMobile
            }).Single();
        }

        public ExpertViewModel GetDeletedExperts(int pageId = 1, string filterFamily = "", string filterMobile = "")
        {
            IQueryable<Expert> result = _context.Experts.IgnoreQueryFilters().Where(e => e.IsDelete);

            if (!string.IsNullOrEmpty(filterMobile))
            {
                result = result.Where(a => a.ExpertMobile.Contains(filterMobile));
            }

            if (!string.IsNullOrEmpty(filterFamily))
            {
                result = result.Where(a => a.ExpertFamily.Contains(filterFamily));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            ExpertViewModel list = new ExpertViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.Experts = result.OrderBy(u => u.ExpertFamily).Skip(skip).Take(take).ToList();

            return list;
        }

        public Expert GetExpertById(int expertId)
        {
            return _context.Experts.Find(expertId);
        }

        public ExpertViewModel GetExperts(int pageId = 1, string filterFamily = "", string filterMobile = "")
        {
            IQueryable<Expert> result = _context.Experts;

            if (!string.IsNullOrEmpty(filterMobile))
            {
                result = result.Where(a => a.ExpertMobile.Contains(filterMobile));
            }

            if (!string.IsNullOrEmpty(filterFamily))
            {
                result = result.Where(a => a.ExpertFamily.Contains(filterFamily));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            ExpertViewModel list = new ExpertViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.Experts = result.OrderBy(u => u.ExpertFamily).Skip(skip).Take(take).ToList();

            return list;
        }

        public void UpdateExpert(Expert expert)
        {
            _context.Experts.Update(expert);
            _context.SaveChangesAsync();
        }
    }
}
