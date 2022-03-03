﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SohaService.Core.Convertor;
using SohaService.Core.DTOs.Order;
using SohaService.Core.DTOs.Pay;
using SohaService.Core.Security;
using SohaService.Core.Services.Interfaces;

namespace SohaService.Web.Controllers
{
    [PermissionChecker(1015)]
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
                filterDoneDate = DateTime.Now.ToString();

            }

            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                toDate = "";
                filterDoneDate = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
                filterDoneDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                filterDoneDate = "";
            }

            DebtorsViewModel order = _orderService.GetDebtors(pageId, filterCustomerId, filterAmount,
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

        #region PrintAccount

        [Route("PrintAccount")]
        public IActionResult PrintAccount(string fromDate = "", string toDate = "", int filterCustomerId = 0)
        {
            DebtorsViewModel order = _orderService.GetDebtorsForPrint(fromDate,toDate,filterCustomerId);

            return View(order);
        }

        #endregion

        #region ShowAllPays

        [Route("ShowAllPays")]
        public IActionResult ShowAllPays(int pageId = 1, int filterCustomerId = 0, string filterPayDate = "", string fromDate = "", string toDate = "")
        {
            if (filterPayDate == "today")
            {
                filterPayDate = DateTime.Now.ToString();

            }

            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                toDate = "";
                filterPayDate = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
                filterPayDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
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

        #region PrintPays

        [Route("PrintPays")]
        public IActionResult PrintPays(string fromDate = "", string toDate = "", int filterCustomerId = 0)
        {
            PayViewModel pay = _payService.GetPaysForPrint(fromDate, toDate, filterCustomerId);

            return View(pay);
        }

        #endregion

    }
}
