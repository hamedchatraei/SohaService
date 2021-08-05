using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SohaService.Core.DTOs.Customer;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.Customer;

namespace SohaService.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #region Customers

        [Route("Customers")]
        public IActionResult Customers(int pageId = 1, string filterFamily = "", string filterMobile = "")
        {
            CustomerViewModel customer = _customerService.GetCustomer(pageId, filterFamily, filterMobile);

            return View(customer);
        }

        #endregion

        #region DeletedCustomers

        public IActionResult DeletedCustomers(int pageId = 1, string filterFamily = "", string filterMobile = "")
        {
            CustomerViewModel customer = _customerService.GetDeletedCustomer(pageId, filterFamily, filterMobile);

            return View(customer);
        }

        #endregion

        #region InformationCustomer

        [Route("InformationCustomer/{id}")]
        public IActionResult InformationCustomer(int id)
        {
            Customer customer = _customerService.GetCustomerById(id);

            return View(customer);
        }

        #endregion

        #region AddCustomer

        [Route("AddCustomer")]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [Route("AddCustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return View(customer);

            _customerService.AddCustomer(customer);

            int customerId = customer.CustomerId;

            return Redirect($"InformationCustomer/{customerId}");
        }

        #endregion

        #region EditCustomer

        [Route("EditCustomer/{id}")]
        public IActionResult EditCustomer(int id)
        {
            Customer editCustomer = _customerService.GetDataForEditCustomer(id);

            return View(editCustomer);
        }

        [HttpPost]
        [Route("EditCustomer/{id}")]
        public IActionResult EditCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return View(customer);

            _customerService.EditCustomer(customer);

            int customerId = customer.CustomerId;

            return Redirect($"InformationCustomer/{customerId}");
        }

        #endregion

        #region DeleteCustomer

        [Route("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            Customer customer = _customerService.GetCustomerById(id);

            return View(customer);
        }

        [HttpPost]
        [Route("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(Customer customer)
        {
            _customerService.DeleteCustomer(customer.CustomerId);

            return Redirect("/Customers");
        }

        #endregion
    }
}
