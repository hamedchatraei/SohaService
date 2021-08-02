using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.Core.DTOs.Customer;
using SohaService.DataLayer.Entities.Customer;

namespace SohaService.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        int AddCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        void EditCustomer(Customer customer);
        CustomerViewModel GetCustomer(int pageId = 1, string filterFamily = "", string filterMobile = "");
        CustomerViewModel GetDeletedCustomer(int pageId = 1, string filterFamily = "", string filterMobile = "");
        Customer GetDataForEditCustomer(int customerId);
        Customer GetCustomerById(int customerId);
        void UpdateCustomer(Customer customer);
    }
}
