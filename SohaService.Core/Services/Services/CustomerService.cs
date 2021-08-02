using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SohaService.Core.DTOs.Customer;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Context;
using SohaService.DataLayer.Entities.Customer;

namespace SohaService.Core.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private SohaServiceContext _context;

        public CustomerService(SohaServiceContext context)
        {
            _context = context;
        }

        public int AddCustomer(Customer customer)
        {
            _context.Customers.AddAsync(customer);
            _context.SaveChangesAsync();
            return customer.CustomerId;
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customer = GetCustomerById(customerId);
            customer.IsDelete = true;
            UpdateCustomer(customer);
        }

        public void EditCustomer(Customer customer)
        {
            Customer editCustomer = GetCustomerById(customer.CustomerId);
            editCustomer.CustomerName = customer.CustomerName;
            editCustomer.CustomerFamily = customer.CustomerFamily;
            editCustomer.CustomerMobile = customer.CustomerMobile;
            editCustomer.CustomerAddress = customer.CustomerAddress;

            UpdateCustomer(editCustomer);
        }

        public CustomerViewModel GetCustomer(int pageId = 1, string filterFamily = "", string filterMobile = "")
        {
            IQueryable<Customer> result = _context.Customers;

            if (!string.IsNullOrEmpty(filterMobile))
            {
                result = result.Where(a => a.CustomerMobile.Contains(filterMobile));
            }

            if (!string.IsNullOrEmpty(filterFamily))
            {
                result = result.Where(a => a.CustomerFamily.Contains(filterFamily));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            CustomerViewModel list = new CustomerViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.Customers = result.OrderBy(u => u.CustomerFamily).Skip(skip).Take(take).ToList();

            return list;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.Find(customerId);
        }

        public Customer GetDataForEditCustomer(int customerId)
        {
            return _context.Customers.Where(c => c.CustomerId == customerId).Select(c => new Customer()
            {
                CustomerId = customerId,
                CustomerName = c.CustomerName,
                CustomerFamily = c.CustomerFamily,
                CustomerMobile = c.CustomerMobile,
                CustomerAddress = c.CustomerAddress
            }).Single();
        }

        public CustomerViewModel GetDeletedCustomer(int pageId = 1, string filterFamily = "", string filterMobile = "")
        {
            IQueryable<Customer> result = _context.Customers.IgnoreQueryFilters().Where(c => c.IsDelete);

            if (!string.IsNullOrEmpty(filterMobile))
            {
                result = result.Where(a => a.CustomerMobile.Contains(filterMobile));
            }

            if (!string.IsNullOrEmpty(filterFamily))
            {
                result = result.Where(a => a.CustomerFamily.Contains(filterFamily));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            CustomerViewModel list = new CustomerViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.Customers = result.OrderBy(u => u.CustomerFamily).Skip(skip).Take(take).ToList();

            return list;
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChangesAsync();
        }
    }
}
