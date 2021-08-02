using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SohaService.Core.DTOs.Company;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Context;
using SohaService.DataLayer.Entities.Company;

namespace SohaService.Core.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private SohaServiceContext _context;

        public CompanyService(SohaServiceContext context)
        {
            _context = context;
        }

        public int AddCompany(Company company)
        {
            _context.Companies.AddAsync(company);
            _context.SaveChangesAsync();
            return company.CompanyId;
        }

        public void DeleteCompany(int companyId)
        {
            Company company = GetCompanyById(companyId);
            company.IsDelete = true;
            UpdateCompany(company);
        }

        public void EditCompany(Company company)
        {
            Company editCompany = GetCompanyById(company.CompanyId);
            editCompany.CompanyName = company.CompanyName;
            editCompany.CompanyPhone = company.CompanyPhone;
            editCompany.CompanyAddress = company.CompanyAddress;

            UpdateCompany(editCompany);
        }

        public CompanyViewModel GetCompanies(int pageId = 1, string filterName = "", string filterPhone = "")
        {
            IQueryable<Company> result = _context.Companies;

            if (!string.IsNullOrEmpty(filterName))
            {
                result = result.Where(a => a.CompanyName.Contains(filterName));
            }

            if (!string.IsNullOrEmpty(filterPhone))
            {
                result = result.Where(a => a.CompanyPhone.Contains(filterPhone));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            CompanyViewModel list = new CompanyViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.Companies = result.OrderBy(u => u.CompanyName).Skip(skip).Take(take).ToList();

            return list;
        }

        public Company GetCompanyById(int companyId)
        {
            return _context.Companies.Find(companyId);
        }

        public Company GetDataFoeEditCompany(int companyId)
        {
            return _context.Companies.Where(c => c.CompanyId == companyId).Select(c => new Company()
            {
                CompanyId = companyId,
                CompanyName = c.CompanyName,
                CompanyPhone = c.CompanyPhone,
                CompanyAddress = c.CompanyAddress
            }).Single();
        }

        public CompanyViewModel GetDeletedCompanies(int pageId = 1, string filterName = "", string filterPhone = "")
        {
            IQueryable<Company> result = _context.Companies.IgnoreQueryFilters().Where(a => a.IsDelete);

            if (!string.IsNullOrEmpty(filterName))
            {
                result = result.Where(a => a.CompanyName.Contains(filterName));
            }

            if (!string.IsNullOrEmpty(filterPhone))
            {
                result = result.Where(a => a.CompanyPhone.Contains(filterPhone));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            CompanyViewModel list = new CompanyViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.Companies =result.OrderBy(u => u.CompanyName).Skip(skip).Take(take).ToList();

            return list;
        }

        public void UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChangesAsync();
        }
    }
}
