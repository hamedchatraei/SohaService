using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SohaService.Core.DTOs.Company;
using SohaService.DataLayer.Entities.Company;

namespace SohaService.Core.Services.Interfaces
{
    public interface ICompanyService
    {
        int AddCompany(Company company);
        void DeleteCompany(int companyId);
        void EditCompany(Company company);
        List<Company> GetAllCompanies();
        List<InformationCompanyViewModel> ShowAllCompanies();
        CompanyViewModel GetCompanies(int pageId = 1, string filterName = "", string filterPhone = "");
        CompanyViewModel GetDeletedCompanies(int pageId = 1, string filterName = "", string filterPhone = "");
        Company GetDataFoeEditCompany(int companyId);
        Company GetCompanyById(int companyId);
        void UpdateCompany(Company company);
        List<SelectListItem> GetCompanyListItem();
    }
}
