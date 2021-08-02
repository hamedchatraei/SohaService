using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.DataLayer.Entities.Orders;

namespace SohaService.Core.DTOs.Order
{
    public class OrderViewModel
    {
        public List<DataLayer.Entities.Orders.Order> Orders { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class SendToCompanyViewModel
    {
        public List<SendToCompany> SendToCompanies { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
