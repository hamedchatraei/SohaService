using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SohaService.Core.Convertor;
using SohaService.Core.DTOs.Customer;
using SohaService.Core.DTOs.Order;
using SohaService.Core.DTOs.Pay;
using SohaService.Core.DTOs.Repair;
using SohaService.Core.Security;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.Customer;
using SohaService.DataLayer.Entities.Orders;
using SohaService.DataLayer.Entities.Pay;
using SohaService.DataLayer.Entities.Repair;

namespace SohaService.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        private IOrderService _orderService;
        private IPayService _payService;
        private IRepairService _repairService;

        public CustomerController(ICustomerService customerService, IOrderService orderService, IPayService payService, IRepairService repairService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _payService = payService;
            _repairService = repairService;
        }

        #region Customers

        [PermissionChecker(1020)]
        [Route("Customers")]
        public IActionResult Customers(int pageId = 1, string filterFamily = "", string filterMobile = "")
        {
            CustomerViewModel customer = _customerService.GetCustomer(pageId, filterFamily, filterMobile);

            return View(customer);
        }

        #endregion

        #region DeletedCustomers

        [PermissionChecker(1020)]
        [Route("DeletedCustomers")]
        public IActionResult DeletedCustomers(int pageId = 1, string filterFamily = "", string filterMobile = "")
        {
            CustomerViewModel customer = _customerService.GetDeletedCustomer(pageId, filterFamily, filterMobile);

            return View(customer);
        }

        #endregion

        #region InformationCustomer

        [PermissionChecker(1020)]
        [Route("InformationCustomer/{id}")]
        public IActionResult InformationCustomer(int id)
        {
            Customer customer = _customerService.GetCustomerById(id);

            return View(customer);
        }

        #endregion

        #region CustomersOrder

        [PermissionChecker(1020)]
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
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                
            }

            OrderViewModel order = _orderService.GetCustomersOrder(id, pageId, fromDate, toDate);

            ViewData["customerId"] = id;

            return View(order);
        }

        #endregion

        #region CustomersRepair

        [PermissionChecker(1020)]
        [Route("CustomersRepair/{id}")]
        public IActionResult CustomersRepair(int id, int pageId = 1, string fromDate = "", string toDate = "")
        {
            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {

            }

            RepairViewModel repair = _repairService.GetCustomersRepair(id, pageId, fromDate, toDate);

            ViewData["customerId"] = id;

            return View(repair);
        }

        #endregion

        #region CustomersPay

        [PermissionChecker(1020)]
        [Route("CustomersPay/{id}")]
        public IActionResult CustomersPay(int id, int pageId = 1, string fromDate = "", string toDate = "")
        {
            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {

            }

            PayViewModel pay = _payService.GetPayByCustomerId(id, pageId, fromDate, toDate);

            ViewData["customerId"] = id;

            return View(pay);
        }

        #endregion

        #region AddCustomer

        [PermissionChecker(1021)]
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

            return Redirect($"AddOrder/{customerId}");
        }

        [PermissionChecker(1021)]
        [Route("AddCustomerForRepair")]
        public IActionResult AddCustomerForRepair()
        {
            return View();
        }

        [HttpPost]
        [Route("AddCustomerForRepair")]
        public IActionResult AddCustomerForRepair(Customer customer)
        {
            if (!ModelState.IsValid)
                return View(customer);

            _customerService.AddCustomer(customer);

            int customerId = customer.CustomerId;

            return Redirect($"AddRepair/{customerId}");
        }

        #endregion

        #region AddCustomersOrderPay

        [PermissionChecker(1024)]
        [Route("AddCustomersOrderPay/{id}")]
        public IActionResult AddCustomersOrderPay(int id)
        {
            ViewData["orderId"] = id;

            return View();
        }

        [HttpPost]
        [Route("AddCustomersOrderPay/{id}")]
        public IActionResult AddCustomersOrderPay(Pay pay)
        {
            if (!ModelState.IsValid)
                return View(pay);

            _payService.AddPay(pay);

            Order order = _orderService.GetOrderById((int)pay.OrderId);

            int esAmount = order.FinalAmount;
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

        #region AddCustomersRepairPay

        [PermissionChecker(1024)]
        [Route("AddCustomersRepairPay/{id}")]
        public IActionResult AddCustomersRepairPay(int id)
        {
            ViewData["repairId"] = id;

            return View();
        }

        [HttpPost]
        [Route("AddCustomersRepairPay/{id}")]
        public IActionResult AddCustomersRepairPay(Pay pay)
        {
            if (!ModelState.IsValid)
                return View(pay);

            _payService.AddPay(pay);

            Repair repair = _repairService.GetRepairById((int)pay.RepairId);

            int esAmount = repair.FinalAmount;
            int discount = repair.Discount;
            int totalCost = esAmount - discount;
            int resAmount = _payService.GetSumAmountRepairPay(repair.RepairId);
            int remAmount = totalCost - resAmount;

            repair.TotalCost = totalCost;
            repair.RemainingAmount = remAmount;

            _repairService.EditDoneRepair(repair);

            int customerId = repair.CustomerId;

            return Redirect($"/CustomersPay/{customerId}");
        }

        #endregion

        #region EditCustomersOrderPay

        [PermissionChecker(1025)]
        [Route("EditCustomersOrderPay/{id}")]
        public IActionResult EditCustomersOrderPay(int id)
        {
            Pay pay = _payService.GetDataForEditPay(id);

            @ViewData["orderId"] = pay.OrderId;

            return View(pay);
        }

        [HttpPost]
        [Route("EditCustomersOrderPay/{id}")]
        public IActionResult EditCustomersOrderPay(Pay pay)
        {
            if (!ModelState.IsValid)
                return View(pay);

            _payService.EditPay(pay);

            Order order = _orderService.GetOrderById((int)pay.OrderId);

            int esAmount = order.FinalAmount;
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

        #region EditCustomersRepairPay

        [PermissionChecker(1025)]
        [Route("EditCustomersRepairPay/{id}")]
        public IActionResult EditCustomersRepairPay(int id)
        {
            Pay pay = _payService.GetDataForEditPay(id);

            @ViewData["repairId"] = pay.RepairId;

            return View(pay);
        }

        [HttpPost]
        [Route("EditCustomersRepairPay/{id}")]
        public IActionResult EditCustomersRepairPay(Pay pay)
        {
            if (!ModelState.IsValid)
                return View(pay);

            _payService.EditPay(pay);

            Repair repair = _repairService.GetRepairById((int) pay.RepairId);

            int esAmount = repair.FinalAmount;
            int discount = repair.Discount;
            int totalCost = esAmount - discount;
            int resAmount = _payService.GetSumAmountRepairPay(repair.RepairId);
            int remAmount = totalCost - resAmount;

            repair.TotalCost = totalCost;
            repair.RemainingAmount = remAmount;

            _repairService.EditDoneRepair(repair);

            int customerId = repair.CustomerId;

            return Redirect($"/CustomersPay/{customerId}");
        }

        #endregion

        #region DeleteCustomersOrderPay

        [PermissionChecker(1026)]
        [Route("DeleteCustomersOrderPay")]
        public IActionResult DeleteCustomersOrderPay(int id)
        {
            Pay pay = _payService.GetPayById(id);
            Order order = _orderService.GetOrderById((int)pay.OrderId);
            int customerId = order.CustomerId;

            order.RemainingAmount += pay.Amount;
            
            _orderService.EditOrder(order);

            _payService.DeletePay(id);

            return Redirect($"/CustomersPay/{customerId}");
        }

        #endregion

        #region DeleteCustomersRepairPay

        [PermissionChecker(1026)]
        [Route("DeleteCustomersRepairPay")]
        public IActionResult DeleteCustomersRepairPay(int id)
        {
            Pay pay = _payService.GetPayById(id);
            Repair repair = _repairService.GetRepairById((int) pay.RepairId);
            int customerId = repair.CustomerId;

            repair.RemainingAmount += pay.Amount;
            
            _repairService.EditRepair(repair);

            _payService.DeletePay(id);

            return Redirect($"/CustomersPay/{customerId}");
        }

        #endregion

        #region EditCustomer

        [PermissionChecker(1022)]
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

        [PermissionChecker(1023)]
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
