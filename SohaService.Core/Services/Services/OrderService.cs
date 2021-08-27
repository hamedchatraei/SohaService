using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SohaService.Core.DTOs.Customer;
using SohaService.Core.DTOs.Order;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Context;
using SohaService.DataLayer.Entities.Orders;

namespace SohaService.Core.Services.Services
{
    public class OrderService : IOrderService
    {
        private SohaServiceContext _context;
        private IConfiguration _configuration;

        public OrderService(SohaServiceContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        #region Orders

        public int AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order.OrderId;
        }

        public void DeleteOrder(int orderId)
        {
            Order order = GetOrderById(orderId);
            order.IsDelete = true;
            UpdateOrder(order);
        }

        public void EditOrder(Order order)
        {
            Order editOrder = GetOrderById(order.OrderId);
            editOrder.CustomerId = order.CustomerId;
            editOrder.UnitId = order.UnitId;
            editOrder.DamageDescription = order.DamageDescription;
            editOrder.EstimatedAmount = order.EstimatedAmount;
            editOrder.EstimatedToSendExpertTime = order.EstimatedToSendExpertTime;
            UpdateOrder(editOrder);
        }

        public void EditDoneOrder(Order order)
        {
            Order editDoneOrder = GetOrderById(order.OrderId);
            editDoneOrder.ExpertId = order.ExpertId;
            editDoneOrder.DoneDescription = order.DoneDescription;
            editDoneOrder.ReceivedAmount = order.ReceivedAmount;
            editDoneOrder.OrderLevelId = 4;
            editDoneOrder.OrderChangeLevelDate = order.OrderChangeLevelDate;
            editDoneOrder.RemainingAmount = order.RemainingAmount;
            editDoneOrder.Discount = order.Discount;
            editDoneOrder.DiscountTitle = order.DiscountTitle;
            editDoneOrder.TotalCost = order.TotalCost;
            UpdateOrder(editDoneOrder);
        }

        public void ChangeLevelOrder(Order order)
        {
            Order changeOrder = GetOrderById(order.OrderId);
            changeOrder.OrderLevelId = order.OrderLevelId;
            UpdateOrder(changeOrder);
        }

        public List<InformationOrderViewModel> ShowDebtors()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationOrderViewModel>("ShowDebtors", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public List<InformationOrderViewModel> ShowCustomersOrder(int customerId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationOrderViewModel>("ShowCustomersOrder", new { customerId = customerId }, commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public InformationOrderViewModel ShowInformationOrderById(int orderId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationOrderViewModel>("ShowInformationdOrderById", new { orderId = orderId }, commandType: CommandType.StoredProcedure).Single();

                return Show;
            }
        }

        public Order GetDataForEditOrder(int orderId)
        {
            return _context.Orders.Where(o => o.OrderId == orderId).Select(o => new Order()
            {
                OrderId = orderId,
                CustomerId = o.CustomerId,
                ExpertId = o.ExpertId,
                UnitId = o.UnitId,
                DoneDescription = o.DoneDescription,
                DamageDescription = o.DamageDescription,
                EstimatedAmount = o.EstimatedAmount,
                ReceivedAmount = o.ReceivedAmount,
                EstimatedToSendExpertTime = o.EstimatedToSendExpertTime,
                OrderChangeLevelDate = o.OrderChangeLevelDate,
                Discount = o.Discount,
                DiscountTitle = o.DiscountTitle,
                TotalCost = o.TotalCost
            }).Single();
        }
        
        public OrderViewModel GetDeletedOrders(int pageId = 1, string estimatedTime = "", int customerId = 0, int unitId = 0, string filterDamageDescription = "")
        {
            IEnumerable<InformationOrderViewModel> information = ShowDeletedInformationOrder();

            if (!string.IsNullOrEmpty(filterDamageDescription))
            {
                information = information.Where(a => a.DamageDescription.Contains(filterDamageDescription));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                information = information.Where(r => r.OrderSetDate == Convert.ToDateTime(estimatedTime));
            }

            if (customerId != 0)
            {
                information = information.Where(a => a.CustomerId == customerId);
            }

            if (unitId != 0)
            {
                information = information.Where(a => a.UnitId == unitId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            OrderViewModel list = new OrderViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);
            list.InformationOrder = information.OrderBy(u => u.OrderSetDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public OrderViewModel GetDebtors(int pageId = 1, int filterCustomerId = 0, string filterAmount = "", string filterDoneDate = "",
            string fromDate = "", string toDate = "")
        {
            IEnumerable<InformationOrderViewModel> information = ShowDebtors();
            
            if (!string.IsNullOrEmpty(filterDoneDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.ToString("d") == filterDoneDate);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate >= Convert.ToDateTime(fromDate));
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate <= Convert.ToDateTime(toDate));
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate >= Convert.ToDateTime(fromDate) && r.OrderChangeLevelDate <= Convert.ToDateTime(toDate));
            }

            if (filterCustomerId != 0)
            {
                information = information.Where(a => a.CustomerId == filterCustomerId);
            }

            if (!string.IsNullOrEmpty(filterAmount))
            {
                information = information.Where(a => a.RemainingAmount.ToString().Contains(filterAmount));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            OrderViewModel list = new OrderViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);
            list.InformationOrder = information.OrderBy(u => u.OrderSetDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public OrderViewModel GetCustomersOrder(int customerId, int pageId = 1, string fromDate = "", string toDate = "")
        {
            IEnumerable<InformationOrderViewModel> result = ShowCustomersOrder(customerId);

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                result = result.Where(r => r.OrderChangeLevelDate >= Convert.ToDateTime(fromDate));
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                result = result.Where(r => r.OrderChangeLevelDate <= Convert.ToDateTime(toDate));
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                result = result.Where(r => r.OrderChangeLevelDate >= Convert.ToDateTime(fromDate) && r.OrderChangeLevelDate <= Convert.ToDateTime(toDate));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            OrderViewModel list = new OrderViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.InformationOrder = result.OrderBy(u => u.OrderChangeLevelDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public List<InformationOrderViewModel> ShowInformationOrder()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationOrderViewModel>("ShowInformationOrder", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public List<InformationOrderViewModel> ShowInformationDoneOrders()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationOrderViewModel>("ShowInformationDoneOrders", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public List<InformationOrderViewModel> ShowDeletedInformationOrder()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationOrderViewModel>("ShowInformationDeletedOrder", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders.Find(orderId);
        }

        public OrderViewModel GetReadyOrders(int pageId = 1,string estimatedTime = "", int customerId = 0, int unitId = 0, string filterDamageDescription = "")
        {
            var date = Convert.ToDateTime(estimatedTime).Date;

            IQueryable<Order> result = _context.Orders;

            IEnumerable<InformationOrderViewModel> information = ShowInformationOrder();


            if (!string.IsNullOrEmpty(filterDamageDescription))
            {
                information = information.Where(a => a.DamageDescription.Contains(filterDamageDescription));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                information = information.Where(r => r.EstimatedToSendExpertTime.Date == date );
            }

            if (customerId != 0)
            {
                information = information.Where(a => a.CustomerId == customerId);
            }

            if (unitId != 0)
            {
                information = information.Where(a => a.UnitId == unitId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            OrderViewModel list = new OrderViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);
            list.InformationOrder = information.OrderBy(u => u.OrderSetDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public OrderViewModel GetDoneOrders(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int customerId = 0, int unitId = 0, string filterDamageDescription = "")
        {
            IQueryable<Order> result = _context.Orders;

            IEnumerable<InformationOrderViewModel> information = ShowInformationDoneOrders();

            if (!string.IsNullOrEmpty(filterDamageDescription))
            {
                information = information.Where(a => a.DamageDescription.Contains(filterDamageDescription));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                information = information.Where(r => r.OrderChangeLevelDate.ToString("d") == estimatedTime);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate >= Convert.ToDateTime(fromDate));
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate <= Convert.ToDateTime(toDate));
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate >= Convert.ToDateTime(fromDate) && r.OrderChangeLevelDate <= Convert.ToDateTime(toDate));
            }

            if (customerId != 0)
            {
                information = information.Where(a => a.CustomerId == customerId);
            }

            if (unitId != 0)
            {
                information = information.Where(a => a.UnitId == unitId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            OrderViewModel list = new OrderViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);
            list.InformationOrder = information.OrderByDescending(u => u.OrderChangeLevelDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        #endregion

        #region SendToCompany

        public int AddSendToCompany(SendToCompany sendTo)
        {
            _context.SendToCompanies.Add(sendTo);
            _context.SaveChanges();
            return sendTo.SendToCompanyId;
        }

        public void DeleteSendToCompany(int sendId)
        {
            SendToCompany sendTo = GetSendToCompanyById(sendId);
            sendTo.IsDelete = true;
            UpdateSendToCompany(sendTo);
            int orderId = sendTo.OrderId;
            Order order = GetOrderById(orderId);
            order.IsDelete = true;
            UpdateOrder(order);
        }

        public void EditSendToCompany(SendToCompany sendTo)
        {
            SendToCompany editSendToCompany = GetSendToCompanyById(sendTo.SendToCompanyId);
            editSendToCompany.CompanyId = sendTo.CompanyId;
            editSendToCompany.SetDate = sendTo.SetDate;
            UpdateSendToCompany(editSendToCompany);
        }

        public void EditBackFromCompany(SendToCompany bakCompany)
        {
            SendToCompany editBackFromCompany = GetSendToCompanyById(bakCompany.SendToCompanyId);
            editBackFromCompany.UnitStatusId = bakCompany.UnitStatusId;
            editBackFromCompany.ReturnDate = bakCompany.ReturnDate;
            editBackFromCompany.AssemblingDate = bakCompany.AssemblingDate;
            editBackFromCompany.IsSend = bakCompany.IsSend;
            editBackFromCompany.IsReturn = bakCompany.IsReturn;
            UpdateSendToCompany(editBackFromCompany);
        }

        public InformationSendToCompanyViewModel ShowInformationSendToCompanyById(int sendToCompanyId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationSendToCompanyViewModel>("ShowInformationSendToCompanyById", new { sendToCompanyId = sendToCompanyId }, commandType: CommandType.StoredProcedure).Single();

                return Show;
            }
        }

        public SendToCompany GetDataForEditSendToCompany(int sendId)
        {
            return _context.SendToCompanies.Where(s => s.SendToCompanyId == sendId).Select(s => new SendToCompany()
            {
                SendToCompanyId = sendId,
                CompanyId = s.CompanyId,
                OrderId = s.OrderId,
                SetDate = s.SetDate,
                ReturnDate = s.ReturnDate,
                AssemblingDate = s.AssemblingDate,
                UnitStatusId = s.UnitStatusId,
                IsSend = s.IsSend,
                IsReturn = s.IsReturn
            }).Single();
        }

        public SendToCompanyViewModel GetSendToCompany(int pageId = 1, string setTime = "", string fromDate = "", string toDate = "", int customerId = 0, int companyId = 0, int unitId = 0)
        {
            IQueryable<SendToCompany> result = _context.SendToCompanies;

            IEnumerable<InformationSendToCompanyViewModel> information = ShowInformationSendToCompany();

            if (!string.IsNullOrEmpty(setTime))
            {
                information = information.Where(r => r.SetDate.ToString("d") == setTime);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.SetDate >= Convert.ToDateTime(fromDate));
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.SetDate <= Convert.ToDateTime(toDate));
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.SetDate >= Convert.ToDateTime(fromDate) && r.SetDate <= Convert.ToDateTime(toDate));
            }

            if (!string.IsNullOrEmpty(setTime))
            {
                information = information.Where(r => r.SetDate == Convert.ToDateTime(setTime));
            }

            if (companyId != 0)
            {
                information = information.Where(a => a.CompanyId == companyId);
            }

            if (customerId != 0)
            {
                information = information.Where(a => a.CustomerId == customerId);
            }

            if (unitId != 0)
            {
                information = information.Where(a => a.UnitId == unitId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            SendToCompanyViewModel list = new SendToCompanyViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.InformationSendToCompany = information.OrderBy(u => u.SetDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public SendToCompanyViewModel GetBackFromCompany(int pageId = 1, string returnTime = "", string fromDate = "", string toDate = "", int customerId = 0, int companyId = 0, int unitId = 0, int unitStatusId = 0)
        {
            IQueryable<SendToCompany> result = _context.SendToCompanies;

            IEnumerable<InformationSendToCompanyViewModel> information = ShowInformationBackFromCompany();

            if (!string.IsNullOrEmpty(returnTime))
            {
                information = information.Where(r => r.SetDate.ToString("d") == returnTime);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.SetDate >= Convert.ToDateTime(fromDate));
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.SetDate <= Convert.ToDateTime(toDate));
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.SetDate >= Convert.ToDateTime(fromDate) && r.SetDate <= Convert.ToDateTime(toDate));
            }

            if (!string.IsNullOrEmpty(returnTime))
            {
                information = information.Where(r => r.SetDate == Convert.ToDateTime(returnTime));
            }

            if (companyId != 0)
            {
                information = information.Where(a => a.CompanyId == companyId);
            }

            if (customerId != 0)
            {
                information = information.Where(a => a.CustomerId == customerId);
            }

            if (unitId != 0)
            {
                information = information.Where(a => a.UnitId == unitId);
            }

            if (unitStatusId != 0)
            {
                information = information.Where(a => a.UnitStatusId == unitStatusId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            SendToCompanyViewModel list = new SendToCompanyViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.InformationSendToCompany = information.OrderBy(u => u.ReturnDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public List<InformationSendToCompanyViewModel> ShowInformationSendToCompany()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationSendToCompanyViewModel>("ShowInformationSendToCompany", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public List<InformationSendToCompanyViewModel> ShowInformationBackFromCompany()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationSendToCompanyViewModel>("ShowInformationBackFromCompany", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public List<InformationSendToCompanyViewModel> ShowInformationDeletedSendToCompany()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationSendToCompanyViewModel>("ShowInformationDeletedSendToCompany", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public SendToCompany GetSendToCompanyById(int sendId)
        {
            return _context.SendToCompanies.Find(sendId);
        }

        public SendToCompany GetSendToCompanyByOrderId(int orderId)
        {
            return _context.SendToCompanies.FirstOrDefault(s => s.OrderId == orderId);
        }

        public void UpdateSendToCompany(SendToCompany sendTo)
        {
            _context.SendToCompanies.Update(sendTo);
            _context.SaveChanges();
        }

        #endregion

    }
}
