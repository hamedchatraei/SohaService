using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SohaService.Core.DTOs.Customer
{
    public class CustomerViewModel
    {
        public List<DataLayer.Entities.Customer.Customer> Customers { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
