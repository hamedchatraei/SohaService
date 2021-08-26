using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SohaService.Core.Convertor;
using SohaService.Core.DTOs.Order;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.Orders;
using SohaService.Core.Convertor;
using SohaService.DataLayer.Entities.Pay;

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

        public OrderController(IOrderService orderService, ICustomerService customerService, IUnitService unitService, IExpertService expertService, ICompanyService companyService, IPayService payService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _unitService = unitService;
            _expertService = expertService;
            _companyService = companyService;
            _payService = payService;
        }

        #region Order

        #region Orders

        [Route("Orders")]
        public IActionResult Orders(int pageId = 1, string estimatedTime = "", int customerId = 0, int unitId = 0,
            string filterDamageDescription = "")
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


            OrderViewModel order = _orderService.GetReadyOrders(pageId, estimatedTime, customerId, unitId, filterDamageDescription);

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

        #region DoneOrders

        [Route("DoneOrders")]
        public IActionResult DoneOrders(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int customerId = 0, int unitId = 0,
            string filterDamageDescription = "")
        {
            if (estimatedTime == "today")
            {
                estimatedTime = DateTime.Now.ToString("d");

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
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                DateTime tDate = Convert.ToDateTime(toDate).ToMiladi();

                fromDate = "";
                toDate = tDate.ToString("d");
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                DateTime fDate = Convert.ToDateTime(fromDate).ToMiladi();
                DateTime tDate = Convert.ToDateTime(toDate).ToMiladi();

                fromDate = fDate.ToString("d");
                toDate = tDate.ToString("d");
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

        #region DeletedOrders

        [Route("DeletedOrders")]
        public IActionResult DeletedOrders(int pageId = 1, string estimatedTime = "", int customerId = 0,
            int unitId = 0, string filterDamageDescription = "")
        {
            OrderViewModel order =
                _orderService.GetDeletedOrders(pageId, estimatedTime, customerId, unitId, filterDamageDescription);

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

        [Route("InformationOrder/{id}")]
        public IActionResult InformationOrder(int id)
        {
            InformationOrderViewModel order = _orderService.ShowInformationOrderById(id);

            return View(order);
        }

        #endregion

        #region AddOrder

        [Route("AddOrder")]
        public IActionResult AddOrder()
        {
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

            return View();
        }

        [HttpPost]
        [Route("AddOrder")]
        public IActionResult AddOrder(Order order)
        {
            if (!ModelState.IsValid)
                return View(order);

            order.ExpertId = 3;
            order.OrderLevelId = 1;

            _orderService.AddOrder(order);

            int orderId = order.OrderId;

            return Redirect($"/InformationOrder/{orderId}");
        }

        #endregion

        #region EditOrder

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

            order.ExpertId = 3;
            order.OrderLevelId = 1;

            _orderService.EditOrder(order);

            int orderId = order.OrderId;
            return Redirect($"/InformationOrder/{orderId}");
        }

        #endregion

        #region EditDoneOrder

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

            _orderService.EditDoneOrder(order);

            int orderId = order.OrderId;
            return Redirect($"/InformationOrder/{orderId}");
        }

        #endregion

        #region SetOrderDone

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

            int esAmount = order.EstimatedAmount;
            int resAmount = _payService.GetSumAmountPay(order.OrderId);
            int remAmount = esAmount - resAmount;

            order.RemainingAmount = remAmount;

            _orderService.EditDoneOrder(order);

            int orderId = order.OrderId;

            return Redirect($"/InformationOrder/{orderId}");
        }

        #endregion

        #region DeleteOrder

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

        #endregion

        #region SendToCompany

        #region SendToCompanies

        [Route("SendToCompanies")]
        public IActionResult SendToCompanies(int pageId = 1, string setTime = "", string fromDate = "", string toDate = "", int customerId = 0, int companyId = 0, int unitId = 0)
        {
            if (setTime == "today")
            {
                setTime = DateTime.Now.ToString("d");

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
                setTime = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                DateTime tDate = Convert.ToDateTime(toDate).ToMiladi();

                fromDate = "";
                toDate = tDate.ToString("d");
                setTime = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                DateTime fDate = Convert.ToDateTime(fromDate).ToMiladi();
                DateTime tDate = Convert.ToDateTime(toDate).ToMiladi();

                fromDate = fDate.ToString("d");
                toDate = tDate.ToString("d");
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

        [Route("BackFromCompanies")]
        public IActionResult BackFromCompanies(int pageId = 1, string returnTime = "", string fromDate = "",
            string toDate = "", int customerId = 0, int companyId = 0, int unitId = 0, int unitStatusId = 0)
        {
            if (returnTime == "today")
            {
                returnTime = DateTime.Now.ToString("d");

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
                returnTime = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                DateTime tDate = Convert.ToDateTime(toDate).ToMiladi();

                fromDate = "";
                toDate = tDate.ToString("d");
                returnTime = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                DateTime fDate = Convert.ToDateTime(fromDate).ToMiladi();
                DateTime tDate = Convert.ToDateTime(toDate).ToMiladi();

                fromDate = fDate.ToString("d");
                toDate = tDate.ToString("d");
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

        [Route("InformationSendToCompany/{id}")]
        public IActionResult InformationSendToCompany(int id)
        {
            InformationSendToCompanyViewModel send = _orderService.ShowInformationSendToCompanyById(id);

            return View(send);
        }

        #endregion

        #region AddSendToCompany

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
            send.ReturnDate=DateTime.Now;
            send.AssemblingDate = DateTime.Now;

            _orderService.AddSendToCompany(send);



            order.OrderLevelId = 2;

            _orderService.EditOrder(order);

            int sendId = send.SendToCompanyId;

            return Redirect($"/InformationSendToCompany/{sendId}");
        }

        #endregion

        #region EditSendToCompany

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

            return View(send);
        }

        [HttpPost]
        [Route("EditBackFromCompany/{id}")]
        public IActionResult EditBackFromCompany(SendToCompany send)
        {
            if (!ModelState.IsValid)
                return View(send);

            _orderService.EditBackFromCompany(send);

            int sendId = send.SendToCompanyId;

            return Redirect($"/InformationSendToCompany/{sendId}");
        }

        #endregion

        #region SetBackFromCompany

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
