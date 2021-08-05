using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SohaService.Core.DTOs.Order;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.Orders;

namespace SohaService.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #region Order

        #region Orders

        [Route("Orders")]
        public IActionResult Orders(int pageId = 1, string estimatedTime = "", int customerId = 0, int unitId = 0,
            string filterDamageDescription = "")
        {
            OrderViewModel order =
                _orderService.GetOrders(pageId, estimatedTime, customerId, unitId, filterDamageDescription);

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

            return View(order);
        }

        #endregion

        #region InformationOrder

        [Route("InformationOrder/{id}")]
        public IActionResult InformationOrder(int id)
        {
            Order send = _orderService.GetOrderById(id);

            return View(send);
        }

        #endregion

        #region AddOrder

        [Route("AddOrder")]
        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        [Route("AddOrder")]
        public IActionResult AddOrder(Order order)
        {
            if (!ModelState.IsValid)
                return View(order);

            _orderService.AddOrder(order);

            int orderId = order.UnitId;

            return Redirect($"/InformationOrder/{orderId}");
        }

        #endregion

        #region EditOrder

        [Route("EditOrder/{id}")]
        public IActionResult EditOrder(int id)
        {
            Order order = _orderService.GetDataForEditOrder(id);

            return View(order);
        }

        [HttpPost]
        [Route("EditOrder/{id}")]
        public IActionResult EditOrder(Order order)
        {
            if (!ModelState.IsValid)
                return View(order);

            _orderService.EditOrder(order);

            int orderId = order.UnitId;

            return Redirect($"/InformationOrder/{orderId}");
        }

        #endregion

        #region SetOrderDone

        [Route("SetOrderDone/{id}")]
        public IActionResult SetOrderDone(int id)
        {
            Order order = _orderService.GetDataForEditOrder(id);

            return View(order);
        }

        [HttpPost]
        [Route("SetOrderDone/{id}")]
        public IActionResult SetOrderDone(Order order)
        {
            if (!ModelState.IsValid)
                return View(order);

            order.OrderLevelId = 4;

            _orderService.EditOrder(order);

            int orderId = order.UnitId;

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
        public IActionResult SendToCompanies(int pageId = 1, string setTime = "", int expertId = 0, int CompanyId = 0)
        {
            SendToCompanyViewModel send = _orderService.GetSendToCompany(pageId, setTime, expertId, CompanyId);

            return View(send);
        }

        #endregion

        #region DeletedSendToCompanies

        [Route("DeletedSendToCompanies")]
        public IActionResult DeletedSendToCompanies(int pageId = 1, string setTime = "", int expertId = 0,
            int CompanyId = 0)
        {
            SendToCompanyViewModel send = _orderService.GetDeletedSendToCompany(pageId, setTime, expertId, CompanyId);

            return View(send);
        }

        #endregion

        #region InformationSendToCompany

        [Route("InformationSendToCompany/{id}")]
        public IActionResult InformationSendToCompany(int id)
        {
            SendToCompany send = _orderService.GetSendToCompanyById(id);

            return View(send);
        }

        #endregion

        #region AddSendToCompany

        [Route("AddSendToCompany")]
        public IActionResult AddSendToCompany()
        {
            return View();
        }

        [HttpPost]
        [Route("AddSendToCompany")]
        public IActionResult AddSendToCompany(SendToCompany send)
        {
            if (!ModelState.IsValid)
                return View(send);

            _orderService.AddSendToCompany(send);

            int orderId = send.OrderId;

            Order order= _orderService.GetOrderById(orderId);

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

        #region SetBackFromCompany

        [Route("SetBackFromCompany/{id}")]
        public IActionResult SetBackFromCompany(int id)
        {
            SendToCompany send = _orderService.GetDataForEditSendToCompany(id);

            return View(send);
        }

        [HttpPost]
        [Route("SetBackFromCompany/{id}")]
        public IActionResult SetBackFromCompany(SendToCompany send)
        {
            if (!ModelState.IsValid)
                return View(send);

            _orderService.EditSendToCompany(send);

            int orderId = send.OrderId;

            Order order = _orderService.GetOrderById(orderId);

            order.OrderLevelId = 3;

            _orderService.UpdateOrder(order);

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

        #endregion
    }
}
