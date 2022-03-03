using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SohaService.Core.DTOs.Company
{
    public class CompanyViewModel
    {
        public List<DataLayer.Entities.Company.Company> Companies { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class InformationCompanyViewModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyAddress { get; set; }
    }
}
