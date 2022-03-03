using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using SohaService.Core.Convertor;
using SohaService.Core.DTOs.Order;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.Orders;
using SohaService.DataLayer.Entities.Pay;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Newtonsoft.Json;
using RestSharp;
using SohaService.Core.DTOs.User;
using SohaService.Core.Security;
using SohaService.Core.Senders;
using SohaService.DataLayer.Entities.ApiKey;
using SohaService.DataLayer.Entities.Customer;
using SohaService.DataLayer.Entities.Today;
using SohaService.DataLayer.Entities.Unit;
using SohaService.DataLayer.Entities.User;

namespace SohaService.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private ICustomerService _customerService;
        private IUnitService _unitService;
        private IExpertService _expertService;
        private ICompanyService _companyService;
        private IPayService _payService;
        private IToDayService _toDayService;
        private IUserService _userService;
        private ISmsService _smsService;
        private IWebHostEnvironment _hostingEnvironment;

        public OrderController(IOrderService orderService, ICustomerService customerService, IUnitService unitService, IExpertService expertService, ICompanyService companyService, IPayService payService, IToDayService toDayService, IUserService userService, ISmsService smsService, IWebHostEnvironment hostingEnvironment)
        {
            _orderService = orderService;
            _customerService = customerService;
            _unitService = unitService;
            _expertService = expertService;
            _companyService = companyService;
            _payService = payService;
            _toDayService = toDayService;
            _userService = userService;
            _smsService = smsService;
            _hostingEnvironment = hostingEnvironment;
        }

        #region Order

        #region Orders

        [PermissionChecker(1002)]
        [Route("Orders")]
        public IActionResult Orders(int pageId = 1, string estimatedTime = "", int customerId = 0, int unitId = 0,
            string filterCustomerMobile = "")
        {

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                //DateTime dateTime = Convert.ToDateTime(estimatedTime).ToMiladi();

                //estimatedTime = estimatedTime.ToString();
            }
            else
            {
                estimatedTime = DateTime.Now.ToString();
            }


            OrderViewModel order = _orderService.GetReadyOrders(pageId, estimatedTime, customerId, unitId, filterCustomerMobile);

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

            ViewData["esTime"] = estimatedTime;


            return View(order);
        }

        #endregion

        #region ReportReadyOrders

        [PermissionChecker(1002)]
        [HttpPost]
        public IActionResult PrintReadyOrders(string date)
        {
            //var uuid= date.GetHashCode().ToString("x");

            _toDayService.EditToDay(date);

            //HtmlToPdfConverter converter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);

            //WebKitConverterSettings settings = new WebKitConverterSettings();
            //settings.WebKitPath = Path.Combine(_hostingEnvironment.ContentRootPath, "QtBinariesWindows");
            //converter.ConverterSettings = settings;

            //PdfDocument document = converter.Convert($"https://localhost:44349/Order/PrintOrders");

            //MemoryStream ms = new MemoryStream();
            //document.Save(ms);
            //return File(ms.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, $@"Order{date+uuid}.pdf");

            return Redirect("/Order/PrintOrders");
        }
        

        public IActionResult PrintOrders(string date)
        {
            //    ToDay toDay =  _toDayService.GetToDay();

            //    string date = toDay.ToDayTitle;

            var orders = _orderService.GetReadyOrderByDate(date);

            return View(orders);
        }

        #endregion

        #region PrintDoneOrders

        public IActionResult PrintDoneOrders(int pageId = 1, string estimatedTime = "", string fromDate = "",
            string toDate = "", int customerId = 0, int unitId = 0,
            string filterCustomerMobile = "", int filterExpertId = 0)
        {
            OrderViewModel order =
                _orderService.GetDoneOrdersForPrint(pageId, estimatedTime, fromDate, toDate, customerId, unitId, filterCustomerMobile, filterExpertId);

            return View(order);
        }

        #endregion

        #region DoneOrders

        [PermissionChecker(1002)]
        [Route("DoneOrders")]
        public IActionResult DoneOrders(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int customerId = 0, int unitId = 0,
            string filterCustomerMobile = "", int filterExpertId = 0)
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
                _orderService.GetDoneOrders(pageId, estimatedTime, fromDate, toDate, customerId, unitId, filterCustomerMobile,filterExpertId);

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

            List<SelectListItem> experts = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کارشناس",Value = ""}
            };
            experts.AddRange(_expertService.GetExpertListItem());
            ViewData["experts"] = new SelectList(experts, "Value", "Text", 0);

            return View(order);
        }

        #endregion

        #region DeniedOrders

        [Route("DeniedOrders")]
        public IActionResult DeniedOrders(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int customerId = 0, int unitId = 0,
            string filterCustomerMobile = "")
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
                _orderService.GetDeniedOrders(pageId, estimatedTime, fromDate, toDate, customerId, unitId, filterCustomerMobile);

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

        #region DeletedOrders

        [PermissionChecker(1002)]
        [Route("DeletedOrders")]
        public IActionResult DeletedOrders(int pageId = 1, string estimatedTime = "", int customerId = 0,
            int unitId = 0, string filterCustomerMobile = "")
        {
            OrderViewModel order =
                _orderService.GetDeletedOrders(pageId, estimatedTime, customerId, unitId, filterCustomerMobile);

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

        #region InformationOrder

        [PermissionChecker(1002)]
        [Route("InformationOrder/{id}")]
        public IActionResult InformationOrder(int id)
        {
            InformationOrderViewModel order = _orderService.ShowInformationOrderById(id);

            return View(order);
        }

        #endregion

        #region AddOrder
        [PermissionChecker(1003)]
        [Route("AddOrder/{id}")]
        public IActionResult AddOrder(int id)
        {
            List<SelectListItem> customers = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب مشتری",Value = ""}
            };
            customers.AddRange(_customerService.GetCustomerListItem());
            ViewData["customers"] = new SelectList(customers, "Value", "Text", id);

            List<SelectListItem> units = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب قطعه",Value = ""}
            };
            units.AddRange(_unitService.GetUnitListItem());
            ViewData["units"] = new SelectList(units, "Value", "Text", 0);

            ViewData["customerId"] = id;

            return View();
        }

        [HttpPost]
        [Route("AddOrder/{id}")]
        public IActionResult AddOrder(Order order)
        {
            if (!ModelState.IsValid)
                return View(order);

            User myUser = _userService.GetUserByUserName(User.Identity.Name);

            order.ExpertId = 3;
            order.OrderLevelId = 1;
            order.OrderChangeLevelDate = DateTime.Now;
            order.OrderSetDate=DateTime.Now;
            order.WitchOne = "Order";
            order.ConfirmationStatusId = 1;
            order.RemainingAmount = order.EstimatedAmount;
            order.TotalCost = order.EstimatedAmount;
            order.registrant = myUser.UserAliasName;

            _orderService.AddOrder(order);

            Customer customer = _customerService.GetCustomerById(order.CustomerId);
            Unit unit = _unitService.GetUnitById(order.UnitId);

            customer.CustomerAddress = order.OrderAddress;
            _customerService.EditCustomer(customer);

            DataLayer.Entities.User.User user = _userService.GetUserByUserName(User.Identity.Name);

            //SendSMS.SendForOrder(customer.CustomerMobile, customer.CustomerName, unit.UnitName,order.EstimatedToSendExpertTime.ToShamsi(), user.UserAliasName);

            ApiKey apiKey = _smsService.ShowApiKey();
            string userApiKey = apiKey.ApiKeyCode;
            string secretCode = apiKey.SecurityCode;

            SendSMS sms = new SendSMS();
            sms.SendForOrder(customer.CustomerMobile, unit.UnitName,user.UserAliasName,userApiKey,secretCode);


            int orderId = order.OrderId;

            return Redirect($"/InformationOrder/{orderId}");
        }

        [Route("CustomerAddress")]
        public string CustomerAddress(int id)
        {
           Customer customer= _customerService.GetCustomerById(id);

           return customer.CustomerAddress;
        }

        #endregion

        #region EditOrder

        [PermissionChecker(1004)]
        [Route("EditOrder/{id}")]
        public IActionResult EditOrder(int id)
        {
            Order order = _orderService.GetDataForEditOrder(id);

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

        [HttpPost]
        [Route("EditOrder/{id}")]
        public IActionResult EditOrder(Order order)
        {
            if (!ModelState.IsValid)
                return View(order);

            Customer customer = _customerService.GetCustomerById(order.CustomerId);
            customer.CustomerAddress = order.OrderAddress;
            _customerService.EditCustomer(customer);

            order.ExpertId = 3;
            order.OrderLevelId = 1;

            _orderService.EditOrder(order);


            int orderId = order.OrderId;
            return Redirect($"/InformationOrder/{orderId}");
        }

        #endregion

        #region EditDoneOrder

        [PermissionChecker(1006)]
        [Route("EditDoneOrder/{id}")]
        public IActionResult EditDoneOrder(int id)
        {
            Order order = _orderService.GetDataForEditOrder(id);


            List<SelectListItem> experts = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کارشناس",Value = ""}
            };
            experts.AddRange(_expertService.GetExpertListItem());
            ViewData["experts"] = new SelectList(experts, "Value", "Text", 0);

            return View(order);
        }

        [HttpPost]
        [Route("EditDoneOrder/{id}")]
        public IActionResult EditDoneOrder(Order order)
        {
            if (!ModelState.IsValid)
                return View(order);

            Pay pay = _payService.GetFirstPayByOrderId(order.OrderId);
            pay.OrderId = order.OrderId;
            pay.Amount = order.ReceivedAmount;
            pay.PayDate = order.OrderChangeLevelDate;

            _payService.EditPay(pay);


            int fAmount = order.FinalAmount;
            int discount = order.Discount;
            int totalCost = fAmount - discount;
            int resAmount = _payService.GetSumAmountPay(order.OrderId);
            int remAmount = totalCost - resAmount;

            order.TotalCost = totalCost;
            order.RemainingAmount = remAmount;
            order.ConfirmationStatusId = 2;
            order.OrderLevelId = 4;

            _orderService.EditDoneOrder(order);

            int orderId = order.OrderId;
            return Redirect($"/InformationOrder/{orderId}");
        }

        #endregion

        #region SetOrderDone

        [PermissionChecker(1005)]
        [Route("SetOrderDone/{id}")]
        public IActionResult SetOrderDone(int id)
        {
            Order order = _orderService.GetDataForEditOrder(id);

            List<SelectListItem> experts = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کارشناس",Value = ""}
            };
            experts.AddRange(_expertService.GetExpertListItem());
            ViewData["experts"] = new SelectList(experts, "Value", "Text", 0);

            return View(order);
        }

        [HttpPost]
        [Route("SetOrderDone/{id}")]
        public IActionResult SetOrderDone(Order order)
        {
            if (!ModelState.IsValid)
                return View(order);


            Pay pay = new Pay();
            pay.OrderId = order.OrderId;
            pay.Amount = order.ReceivedAmount;
            pay.PayDate = order.OrderChangeLevelDate;

            _payService.AddPay(pay);


            int fAmount = order.FinalAmount;
            int discount = order.Discount;
            int totalCost = fAmount - discount;
            int resAmount = _payService.GetSumAmountPay(order.OrderId);
            int remAmount = totalCost - resAmount;

            order.TotalCost = totalCost;
            order.RemainingAmount = remAmount;
            order.ConfirmationStatusId = 2;
            order.OrderLevelId = 4;

            _orderService.EditDoneOrder(order);

            int orderId = order.OrderId;

            return Redirect($"/InformationOrder/{orderId}");
        }

        #endregion

        #region DeleteOrder

        [PermissionChecker(1007)]
        [Route("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            Order order = _orderService.GetOrderById(id);

            return View(order);
        }

        [HttpPost]
        [Route("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(Order order)
        {
            _orderService.DeleteOrder(order.OrderId);

            return Redirect("/Orders");
        }

        #endregion

        public string GetNextWeek(DateTime date,bool next)
        {
            DateTime nextWeekDay;

            if (next)
            {
                nextWeekDay = date.AddDays(7);
            }
            else
            {
                nextWeekDay = date.AddDays(-7);
            }

            return nextWeekDay.ToShamsi();
        }

        #endregion

        #region SendToCompany

        #region SendToCompanies

        [PermissionChecker(1008)]
        [Route("SendToCompanies")]
        public IActionResult SendToCompanies(int pageId = 1, string setTime = "", string fromDate = "", string toDate = "", int customerId = 0, int companyId = 0, int unitId = 0)
        {
            if (setTime == "today")
            {
                setTime = DateTime.Now.ToString();

            }

            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                toDate = "";
                setTime = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
                setTime = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                setTime = "";
            }


            SendToCompanyViewModel send = _orderService.GetSendToCompany(pageId, setTime, fromDate, toDate, customerId, companyId, unitId);

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

            return View(send);
        }

        #endregion

        #region BackFromCompanies

        [PermissionChecker(1008)]
        [Route("BackFromCompanies")]
        public IActionResult BackFromCompanies(int pageId = 1, string returnTime = "", string fromDate = "",
            string toDate = "", int customerId = 0, int companyId = 0, int unitId = 0, int unitStatusId = 0)
        {
            if (returnTime == "today")
            {
                returnTime = DateTime.Now.ToString();

            }

            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                toDate = "";
                returnTime = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
                returnTime = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                returnTime = "";
            }

            SendToCompanyViewModel send = _orderService.GetBackFromCompany(pageId, returnTime, fromDate, toDate,
                customerId, companyId, unitId, unitStatusId);

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

            List<SelectListItem> unitStatus = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب وضعیت قطعه",Value = ""}
            };
            unitStatus.AddRange(_unitService.GetUnitStatusListItem());
            ViewData["unitStatus"] = new SelectList(unitStatus, "Value", "Text", 0);

            return View(send);
        }

        #endregion

        #region InformationSendToCompany

        [PermissionChecker(1008)]
        [Route("InformationSendToCompany/{id}")]
        public IActionResult InformationSendToCompany(int id)
        {
            InformationSendToCompanyViewModel send = _orderService.ShowInformationSendToCompanyById(id);

            return View(send);
        }

        #endregion

        #region AddSendToCompany

        [PermissionChecker(1009)]
        [Route("AddSendToCompany/{id}")]
        public IActionResult AddSendToCompany(int id)
        {
            List<SelectListItem> company = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب شرکت",Value = ""}
            };
            company.AddRange(_companyService.GetCompanyListItem());
            ViewData["company"] = new SelectList(company, "Value", "Text", 0);

            ViewData["OrderId"] = id;

            return View();
        }

        [HttpPost]
        [Route("AddSendToCompany/{id}")]
        public IActionResult AddSendToCompany(SendToCompany send)
        {
            if (!ModelState.IsValid)
                return View(send);

            int orderId = send.OrderId;

            Order order = _orderService.GetOrderById(orderId);

            send.IsSend = true;
            send.IsReturn = false;
            send.UnitId = order.UnitId;
            send.UnitStatusId = 1;
            send.ReturnDate = DateTime.Now;
            send.AssemblingDate = DateTime.Now;

            _orderService.AddSendToCompany(send);



            order.OrderLevelId = 2;

            _orderService.EditOrder(order);

            int sendId = send.SendToCompanyId;

            return Redirect($"/InformationSendToCompany/{sendId}");
        }

        #endregion

        #region EditSendToCompany

        [PermissionChecker(1010)]
        [Route("EditSendToCompany/{id}")]
        public IActionResult EditSendToCompany(int id)
        {
            List<SelectListItem> company = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب شرکت",Value = ""}
            };
            company.AddRange(_companyService.GetCompanyListItem());
            ViewData["company"] = new SelectList(company, "Value", "Text", 0);

            SendToCompany send = _orderService.GetDataForEditSendToCompany(id);

            return View(send);
        }

        [HttpPost]
        [Route("EditSendToCompany/{id}")]
        public IActionResult EditSendToCompany(SendToCompany send)
        {
            if (!ModelState.IsValid)
                return View(send);

            _orderService.EditSendToCompany(send);

            int sendId = send.SendToCompanyId;

            return Redirect($"/InformationSendToCompany/{sendId}");
        }

        #endregion

        #region EditBackFromCompany

        [PermissionChecker(1012)]
        [Route("EditBackFromCompany/{id}")]
        public IActionResult EditBackFromCompany(int id)
        {
            SendToCompany send = _orderService.GetDataForEditSendToCompany(id);

            List<SelectListItem> unitStatus = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب وضعیت قطعه",Value = ""}
            };
            unitStatus.AddRange(_unitService.GetUnitStatusListItem());
            ViewData["unitStatus"] = new SelectList(unitStatus, "Value", "Text", 0);

            List<SelectListItem> company = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب شرکت",Value = ""}
            };
            company.AddRange(_companyService.GetCompanyListItem());
            ViewData["company"] = new SelectList(company, "Value", "Text", 0);

            return View(send);
        }

        [HttpPost]
        [Route("EditBackFromCompany/{id}")]
        public IActionResult EditBackFromCompany(SendToCompany send)
        {
            if (!ModelState.IsValid)
                return View(send);

            send.IsReturn = true;

            _orderService.EditBackFromCompany(send);

            int orderId = send.OrderId;

            Order order = _orderService.GetOrderById(orderId);

            order.OrderLevelId = 3;
            order.EstimatedToSendExpertTime = send.AssemblingDate;

            _orderService.EditOrder(order);

            int sendId = send.SendToCompanyId;

            return Redirect($"/InformationSendToCompany/{sendId}");
        }

        #endregion

        #region SetBackFromCompany

        [PermissionChecker(1011)]
        [Route("SetBackFromCompany/{id}")]
        public IActionResult SetBackFromCompany(int id)
        {
            SendToCompany send = _orderService.GetDataForEditSendToCompany(id);

            List<SelectListItem> unitStatus = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب وضعیت قطعه",Value = ""}
            };
            unitStatus.AddRange(_unitService.GetUnitStatusListItem());
            ViewData["unitStatus"] = new SelectList(unitStatus, "Value", "Text", 0);

            return View(send);
        }

        [HttpPost]
        [Route("SetBackFromCompany/{id}")]
        public IActionResult SetBackFromCompany(SendToCompany send)
        {
            if (!ModelState.IsValid)
                return View(send);

            send.IsSend = false;
            send.IsReturn = true;

            _orderService.EditBackFromCompany(send);

            int orderId = send.OrderId;

            Order order = _orderService.GetOrderById(orderId);

            order.OrderLevelId = 3;
            order.EstimatedToSendExpertTime = send.AssemblingDate;

            _orderService.EditOrder(order);

            int sendId = send.SendToCompanyId;

            return Redirect($"/InformationSendToCompany/{sendId}");
        }

        #endregion

        #region DeleteSendToCompany

        [PermissionChecker(1013)]
        [Route("DeleteSendToCompany/{id}")]
        public IActionResult DeleteSendToCompany(int id)
        {
            SendToCompany send = _orderService.GetSendToCompanyById(id);

            return View(send);
        }

        [HttpPost]
        [Route("DeleteSendToCompany/{id}")]
        public IActionResult DeleteSendToCompany(SendToCompany send)
        {
            _orderService.DeleteSendToCompany(send.SendToCompanyId);

            return Redirect("/SendToCompanies");
        }

        #endregion

        #region DeleteBackFromCompany

        [PermissionChecker(1014)]
        [Route("DeleteBackFromCompany/{id}")]
        public IActionResult DeleteBackFromCompany(int id)
        {
            SendToCompany send = _orderService.GetSendToCompanyById(id);

            return View(send);
        }

        [HttpPost]
        [Route("DeleteBackFromCompany/{id}")]
        public IActionResult DeleteBackFromCompany(SendToCompany send)
        {
            _orderService.DeleteSendToCompany(send.SendToCompanyId);

            return Redirect("/BackFromCompanies");
        }

        #endregion

        #endregion
    }
}
