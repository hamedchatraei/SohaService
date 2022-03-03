using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SohaService.Core.DTOs.Company;
using SohaService.Core.DTOs.Order;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.Company;
using SohaService.Core.Security;

namespace SohaService.Web.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        #region Companies

        [PermissionChecker(1016)]
        [Route("Companies")]
        public IActionResult Companies(int pageId = 1, string filterName = "", string filterPhone = "")
        {
            CompanyViewModel company = _companyService.GetCompanies(pageId, filterName, filterPhone);

            return View(company);
        }

        #endregion

        #region DeletedCompanies

        [PermissionChecker(1016)]
        [Route("DeletedCompanies")]
        public IActionResult DeletedCompanies(int pageId = 1, string filterName = "", string filterPhone = "")
        {
            CompanyViewModel company = _companyService.GetDeletedCompanies(pageId, filterName, filterPhone);

            return View(company);
        }

        #endregion

        #region InformationCompany

        [PermissionChecker(1016)]
        [Route("InformationCompany/{id}")]
        public IActionResult InformationCompany(int id)
        {
            Company company = _companyService.GetCompanyById(id);

            return View(company);
        }

        #endregion

        #region AddCompany

        [PermissionChecker(1017)]
        [Route("AddCompany")]
        public IActionResult AddCompany()
        {
            return View();
        }

        [HttpPost]
        [Route("AddCompany")]
        public IActionResult AddCompany(Company company)
        {
            if (!ModelState.IsValid)
                return View(company);

            _companyService.AddCompany(company);

            int companyId = company.CompanyId;

            return Redirect($"/InformationCompany/{companyId}");
        }

        #endregion

        #region EditCompany

        [PermissionChecker(1018)]
        [Route("EditCompany/{id}")]
        public IActionResult EditCompany(int id)
        {
            Company editCompany = _companyService.GetDataFoeEditCompany(id);

            return View(editCompany);
        }

        [HttpPost]
        [Route("EditCompany/{id}")]
        public IActionResult EditCompany(Company company)
        {
            if (!ModelState.IsValid)
                return View(company);

            _companyService.EditCompany(company);

            int companyId = company.CompanyId;

            return Redirect($"/InformationCompany/{companyId}");
        }

        #endregion

        #region DeleteCompany

        [PermissionChecker(1019)]
        [Route("DeleteCompany/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            Company company = _companyService.GetCompanyById(id);

            return View(company);
        }

        [HttpPost]
        [Route("DeleteCompany/{id}")]
        public IActionResult DeleteCompany(Company company)
        {
            _companyService.DeleteCompany(company.CompanyId);

            return Redirect("/Companies");
        }

        #endregion
        
    }
}
