using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SohaService.Core.Convertor;
using SohaService.Core.DTOs.Order;
using SohaService.Core.DTOs.Pay;
using SohaService.Core.Services.Interfaces;

namespace SohaService.Web.Controllers
{
    public class AccountController : Controller
    {
        private IOrderService _orderService;
        private ICustomerService _customerService;
        private IPayService _payService;

        public AccountController(IOrderService orderService, ICustomerService customerService, IPayService payService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _payService = payService;
        }

        #region Accounts

        [Route("Accounts")]
        public IActionResult Accounts(int pageId = 1, int filterCustomerId = 0, string filterAmount = "", string filterDoneDate = "", string fromDate = "", string toDate = "")
        {
            if (filterDoneDate == "today")
            {
                filterDoneDate = DateTime.Now.ToString("d");

            }

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
                filterDoneDate = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                DateTime tDate = Convert.ToDateTime(toDate).ToMiladi();

                fromDate = "";
                toDate = tDate.ToString("d");
                filterDoneDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                DateTime fDate = Convert.ToDateTime(fromDate).ToMiladi();
                DateTime tDate = Convert.ToDateTime(toDate).ToMiladi();

                fromDate = fDate.ToString("d");
                toDate = tDate.ToString("d");
                filterDoneDate = "";
            }

            OrderViewModel order = _orderService.GetDebtors(pageId, filterCustomerId, filterAmount,
                filterDoneDate, fromDate, toDate);

            List<SelectListItem> customers = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب مشتری",Value = ""}
            };
            customers.AddRange(_customerService.GetCustomerListItem());
            ViewData["customers"] = new SelectList(customers, "Value", "Text", 0);

            return View(order);
        }

        #endregion

        #region ShowAllPays

        [Route("ShowAllPays")]
        public IActionResult ShowAllPays(int pageId = 1, int filterCustomerId = 0, string filterPayDate = "", string fromDate = "", string toDate = "")
        {
            if (filterPayDate == "today")
            {
                filterPayDate = DateTime.Now.ToString("d");

            }

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
                filterPayDate = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                DateTime tDate = Convert.ToDateTime(toDate).ToMiladi();

                fromDate = "";
                toDate = tDate.ToString("d");
                filterPayDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                DateTime fDate = Convert.ToDateTime(fromDate).ToMiladi();
                DateTime tDate = Convert.ToDateTime(toDate).ToMiladi();

                fromDate = fDate.ToString("d");
                toDate = tDate.ToString("d");
                filterPayDate = "";
            }

            PayViewModel pay = _payService.GetPays(pageId, filterCustomerId, filterPayDate, fromDate, toDate);

            List<SelectListItem> customers = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب مشتری",Value = ""}
            };
            customers.AddRange(_customerService.GetCustomerListItem());
            ViewData["customers"] = new SelectList(customers, "Value", "Text", 0);

            return View(pay);
        }

        #endregion

    }
}
