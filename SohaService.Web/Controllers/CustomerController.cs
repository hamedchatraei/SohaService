using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SohaService.Core.Convertor;
using SohaService.Core.DTOs.Customer;
using SohaService.Core.DTOs.Order;
using SohaService.Core.DTOs.Pay;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.Customer;
using SohaService.DataLayer.Entities.Orders;
using SohaService.DataLayer.Entities.Pay;

namespace SohaService.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        private IOrderService _orderService;
        private IPayService _payService;

        public CustomerController(ICustomerService customerService, IOrderService orderService, IPayService payService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _payService = payService;
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

        [Route("DeletedCustomers")]
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

        #region CustomersOrder

        [Route("CustomersOrder/{id}")]
        public IActionResult CustomersOrder(int id, int pageId = 1, string fromDate = "", string toDate = "")
        {
            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                DateTime fDate = Convert.ToDateTime(fromDate).ToMiladi();

                fromDate = fDate.ToString("d");
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                DateTime tDate = Convert.ToDateTime(toDate).ToMiladi();

                fromDate = "";
                toDate = tDate.ToString("d");
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                DateTime fDate = Convert.ToDateTime(fromDate).ToMiladi();
                DateTime tDate = Convert.ToDateTime(toDate).ToMiladi();

                fromDate = fDate.ToString("d");
                toDate = tDate.ToString("d");
            }

            OrderViewModel order = _orderService.GetCustomersOrder(id, pageId, fromDate, toDate);

            ViewData["customerId"] = id;

            return View(order);
        }

        #endregion

        #region CustomersPay

        [Route("CustomersPay/{id}")]
        public IActionResult CustomersPay(int id, int pageId = 1, string fromDate = "", string toDate = "")
        {
            PayViewModel pay = _payService.GetPayByCustomerId(id, pageId, fromDate, toDate);

            ViewData["customerId"] = id;

            return View(pay);
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

            return Redirect($"/InformationCustomer/{customerId}");
        }

        #endregion

        #region AddCustomersPay

        [Route("AddCustomersPay/{id}")]
        public IActionResult AddCustomersPay(int id)
        {
            ViewData["orderId"] = id;

            return View();
        }

        [HttpPost]
        [Route("AddCustomersPay/{id}")]
        public IActionResult AddCustomersPay(Pay pay)
        {
            if (!ModelState.IsValid)
                return View(pay);

            _payService.AddPay(pay);

            Order order = _orderService.GetOrderById(pay.OrderId);

            int esAmount = order.EstimatedAmount;
            int discount = order.Discount;
            int totalCost = esAmount - discount;
            int resAmount = _payService.GetSumAmountPay(order.OrderId);
            int remAmount = totalCost - resAmount;

            order.TotalCost = totalCost;
            order.RemainingAmount = remAmount;

            _orderService.EditDoneOrder(order);

            int customerId = order.CustomerId;

            return Redirect($"/CustomersPay/{customerId}");
        }

        #endregion

        #region EditCustomersPay

        [Route("EditCustomersPay/{id}")]
        public IActionResult EditCustomersPay(int id)
        {
            Pay pay = _payService.GetDataForEditPay(id);

            @ViewData["orderId"] = pay.OrderId;

            return View(pay);
        }

        [HttpPost]
        [Route("EditCustomersPay/{id}")]
        public IActionResult EditCustomersPay(Pay pay)
        {
            if (!ModelState.IsValid)
                return View(pay);

            _payService.EditPay(pay);

            Order order = _orderService.GetOrderById(pay.OrderId);

            int esAmount = order.EstimatedAmount;
            int discount = order.Discount;
            int totalCost = esAmount - discount;
            int resAmount = _payService.GetSumAmountPay(order.OrderId);
            int remAmount = totalCost - resAmount;

            order.TotalCost = totalCost;
            order.RemainingAmount = remAmount;

            _orderService.EditDoneOrder(order);

            int customerId = order.CustomerId;

            return Redirect($"/CustomersPay/{customerId}");
        }

        #endregion

        #region DeleteCustomersPay

        [Route("DeleteCustomersPay/{id}")]
        public IActionResult DeleteCustomersPay(int id)
        {
            Pay pay = _payService.GetPayById(id);
            Order order = _orderService.GetOrderById(pay.OrderId);
            int customerId = order.CustomerId;

            order.RemainingAmount += pay.Amount;
            
            _orderService.EditOrder(order);

            _payService.DeletePay(id);

            return Redirect($"/CustomersPay/{customerId}");
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

            return Redirect($"/InformationCustomer/{customerId}");
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
