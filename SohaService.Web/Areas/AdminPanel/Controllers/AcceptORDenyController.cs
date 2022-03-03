using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SohaService.Core.DTOs.Order;
using SohaService.Core.DTOs.Repair;
using SohaService.Core.Security;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.Orders;
using SohaService.DataLayer.Entities.Repair;

namespace SohaService.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [PermissionChecker(1)]
    public class AcceptORDenyController : Controller
    {
        private IOrderService _orderService;
        private ICustomerService _customerService;
        private IUnitService _unitService;
        private IRepairService _repairService;
        private ICompanyService _companyService;

        public AcceptORDenyController(IOrderService orderService, ICustomerService customerService, IUnitService unitService, IRepairService repairService, ICompanyService companyService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _unitService = unitService;
            _repairService = repairService;
            _companyService = companyService;
        }

        #region OrdersForAdmin

        [Route("OrdersForAdmin")]
        public IActionResult OrdersForAdmin(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int customerId = 0, int unitId = 0,
            string filterDamageDescription = "")
        {
            if (estimatedTime == "today")
            {
                estimatedTime = DateTime.Now.ToString();

            }

            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                toDate = "";
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                estimatedTime = "";
            }

            OrderViewModel order =
                _orderService.GetDoneOrders(pageId, estimatedTime, fromDate, toDate, customerId, unitId, filterDamageDescription);

            List<SelectListItem> customers = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب مشتری",Value = ""}
            };
            customers.AddRange(_customerService.GetCustomerListItem());
            ViewData["customers"] = new SelectList(customers, "Value", "Text", 0);

            List<SelectListItem> units = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب قطعه",Value = ""}
            };
            units.AddRange(_unitService.GetUnitListItem());
            ViewData["units"] = new SelectList(units, "Value", "Text", 0);

            return View(order);
        }

        #endregion

        #region RepairsForAdmin

        [Route("RepairsForAdmin")]
        public IActionResult RepairsForAdmin(int pageId = 1, string estimatedTime = "", string fromDate = "",
            string toDate = "", int filterCustomerId = 0,
            int filterUnitId = 0, int filterCompanyId = 0, string filterDamageDesc = "")
        {
            if (estimatedTime == "today")
            {
                estimatedTime = DateTime.Now.ToString();

            }

            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                toDate = "";
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                estimatedTime = "";
            }

            RepairViewModel repair = _repairService.GetDoneRepairs(pageId, estimatedTime, fromDate, toDate,
                filterCustomerId, filterUnitId, filterCompanyId, filterDamageDesc);

            List<SelectListItem> customers = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب مشتری",Value = ""}
            };
            customers.AddRange(_customerService.GetCustomerListItem());
            ViewData["customers"] = new SelectList(customers, "Value", "Text", 0);

            List<SelectListItem> units = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب قطعه",Value = ""}
            };
            units.AddRange(_unitService.GetUnitListItem());
            ViewData["units"] = new SelectList(units, "Value", "Text", 0);

            List<SelectListItem> company = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب شرکت",Value = ""}
            };
            company.AddRange(_companyService.GetCompanyListItem());
            ViewData["company"] = new SelectList(company, "Value", "Text", 0);

            return View(repair);
        }

        #endregion

        #region AcceptOrDenyOrder

        [Route("AcceptOrder")]
        public IActionResult AcceptOrder(int id)
        {
            Order order = _orderService.GetOrderById(id);

            order.ConfirmationStatusId = 3;

            _orderService.EditDoneOrder(order);

            return Redirect("/OrdersForAdmin");
        }

        [Route("DenyOrder")]
        public IActionResult DenyOrder(int id)
        {
            Order order = _orderService.GetOrderById(id);

            order.ConfirmationStatusId = 4;

            _orderService.EditDoneOrder(order);

            return Redirect("/OrdersForAdmin");
        }

        #endregion

        #region AcceptOrDenyRepair

        [Route("AcceptRepair")]
        public IActionResult AcceptRepair(int id)
        {
            Repair repair = _repairService.GetRepairById(id);

            repair.ConfirmationStatusId = 3;

            _repairService.EditDoneRepair(repair);

            return Redirect("/RepairsForAdmin");
        }

        [Route("DenyRepair")]
        public IActionResult DenyRepair(int id)
        {
            Repair repair = _repairService.GetRepairById(id);

            repair.ConfirmationStatusId = 4;

            _repairService.EditDoneRepair(repair);

            return Redirect("/RepairsForAdmin");
        }

        #endregion
    }
}
