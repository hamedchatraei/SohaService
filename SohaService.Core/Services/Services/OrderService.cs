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
using SohaService.Core.DTOs.Pay;
using SohaService.Core.DTOs.Repair;
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
            editOrder.EstimatedServiceAmount = order.EstimatedServiceAmount;
            editOrder.EstimatedUnitAmount = order.EstimatedUnitAmount;
            editOrder.EstimatedAmount = order.EstimatedAmount;
            editOrder.EstimatedToSendExpertTime = order.EstimatedToSendExpertTime;
            editOrder.registrant = order.registrant;
            editOrder.OrderSetDate = order.OrderSetDate;
            editOrder.WitchOne = order.WitchOne;
            UpdateOrder(editOrder);
        }

        public void EditDoneOrder(Order order)
        {
            Order editDoneOrder = GetOrderById(order.OrderId);
            editDoneOrder.ExpertId = order.ExpertId;
            editDoneOrder.DoneDescription = order.DoneDescription;
            editDoneOrder.ReceivedAmount = order.ReceivedAmount;
            editDoneOrder.OrderLevelId = order.OrderLevelId;
            editDoneOrder.OrderChangeLevelDate = order.OrderChangeLevelDate;
            editDoneOrder.RemainingAmount = order.RemainingAmount;
            editDoneOrder.Discount = order.Discount;
            editDoneOrder.FinalAmount = order.FinalAmount;
            editDoneOrder.TotalCost = order.TotalCost;
            editDoneOrder.ConfirmationStatusId = order.ConfirmationStatusId;
            editDoneOrder.OrderAddress = order.OrderAddress;
            editDoneOrder.EstimatedServiceAmount = order.EstimatedServiceAmount;
            editDoneOrder.EstimatedUnitAmount = order.EstimatedUnitAmount;
            editDoneOrder.EstimatedAmount = order.EstimatedAmount;
            editDoneOrder.registrant = order.registrant;
            editDoneOrder.OrderSetDate = order.OrderSetDate;
            editDoneOrder.WitchOne = order.WitchOne;
            UpdateOrder(editDoneOrder);
        }

        public void ChangeLevelOrder(Order order)
        {
            Order changeOrder = GetOrderById(order.OrderId);
            changeOrder.OrderLevelId = order.OrderLevelId;
            UpdateOrder(changeOrder);
        }

        public List<InformationDebtorsViewModel> ShowDebtors()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationDebtorsViewModel>("ShowDebtors", commandType: CommandType.StoredProcedure).ToList();

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
                OrderLevelId = o.OrderLevelId,
                CustomerId = o.CustomerId,
                ExpertId = o.ExpertId,
                UnitId = o.UnitId,
                DoneDescription = o.DoneDescription,
                DamageDescription = o.DamageDescription,
                EstimatedAmount = o.EstimatedAmount,
                ReceivedAmount = o.ReceivedAmount,
                EstimatedServiceAmount = o.EstimatedServiceAmount,
                EstimatedUnitAmount = o.EstimatedUnitAmount,
                EstimatedToSendExpertTime = o.EstimatedToSendExpertTime,
                OrderChangeLevelDate = o.OrderChangeLevelDate,
                Discount = o.Discount,
                FinalAmount = o.FinalAmount,
                TotalCost = o.TotalCost,
                OrderAddress = o.OrderAddress,
                ConfirmationStatusId = o.ConfirmationStatusId,
                registrant = o.registrant,
                OrderSetDate = o.OrderSetDate,
                WitchOne = o.WitchOne
            }).Single();
        }
        
        public OrderViewModel GetDeletedOrders(int pageId = 1, string estimatedTime = "", int customerId = 0, int unitId = 0, string filterCustomerMobile = "")
        {
            IEnumerable<InformationOrderViewModel> information = ShowDeletedInformationOrder();

            if (!string.IsNullOrEmpty(filterCustomerMobile))
            {
                information = information.Where(a => a.CustomerMobile.Contains(filterCustomerMobile));
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

            list.StartPage = (pageId - 2 <= 0) ? 1 : pageId - 2;
            list.EndPage = (pageId + 3 > list.PageCount) ? list.PageCount : pageId + 3;

            list.InformationOrder = information.OrderBy(u => u.OrderSetDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public DebtorsViewModel GetDebtors(int pageId = 1, int filterCustomerId = 0, string filterAmount = "", string filterDoneDate = "",
            string fromDate = "", string toDate = "")
        {
            var date = DateTime.Now;
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(filterDoneDate))
            {
                date = Convert.ToDateTime(filterDoneDate).Date;
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IEnumerable<InformationDebtorsViewModel> information = ShowDebtors();

            if (!string.IsNullOrEmpty(filterDoneDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date == date);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date >= fDate && r.OrderChangeLevelDate.Date <= tDate);
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

            DebtorsViewModel list = new DebtorsViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);
            list.InformationDebtorsViewModels = information.OrderBy(u => u.OrderChangeLevelDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public DebtorsViewModel GetDebtorsForPrint(string fromDate = "", string toDate = "", int filterCustomerId = 0)
        {
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IEnumerable<InformationDebtorsViewModel> information = ShowDebtors();

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date >= fDate && r.OrderChangeLevelDate.Date <= tDate);
            }

            if (filterCustomerId != 0)
            {
                information = information.Where(a => a.CustomerId == filterCustomerId);
            }

            DebtorsViewModel list = new DebtorsViewModel();
            list.InformationDebtorsViewModels = information.OrderBy(u => u.OrderChangeLevelDate).ToList();

            return list;
        }

        public OrderViewModel GetCustomersOrder(int customerId, int pageId = 1, string fromDate = "", string toDate = "")
        {
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IEnumerable<InformationOrderViewModel> result = ShowCustomersOrder(customerId);

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                result = result.Where(r => r.OrderChangeLevelDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                result = result.Where(r => r.OrderChangeLevelDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                result = result.Where(r => r.OrderChangeLevelDate.Date >= fDate && r.OrderChangeLevelDate.Date <= tDate);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            OrderViewModel list = new OrderViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.InformationOrder = result.OrderBy(u => u.OrderChangeLevelDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public OrderViewModel GetReadyOrderByDate(string date)
        {
            var nowDate = Convert.ToDateTime(date).Date;

            IEnumerable<InformationOrderViewModel> information = ShowInformationOrder();

            OrderViewModel list = new OrderViewModel();
            list.InformationOrder = information.Where(o => o.EstimatedToSendExpertTime.Date == nowDate).OrderBy(o=>o.EstimatedToSendExpertTime).ThenBy(o=>o.CustomerAddress).ToList();

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

        public List<InformationOrderViewModel> ShowInformationDeniedOrders()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationOrderViewModel>("ShowInformationDeniedOrders", commandType: CommandType.StoredProcedure).ToList();

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

        public int GetCountOrderByDate(DateTime date)
        {
            return _context.Orders.Count(o => o.EstimatedToSendExpertTime == date && o.IsDelete==false && (o.OrderLevelId==1 || o.OrderLevelId==3));
        }

        public OrderViewModel GetReadyOrders(int pageId = 1,string estimatedTime = "", int customerId = 0, int unitId = 0, string filterCustomerMobile = "")
        {
            var date = Convert.ToDateTime(estimatedTime).Date;

            IQueryable<Order> result = _context.Orders;

            IEnumerable<InformationOrderViewModel> information = ShowInformationOrder();


            if (!string.IsNullOrEmpty(filterCustomerMobile))
            {
                information = information.Where(a => a.CustomerMobile.Contains(filterCustomerMobile));
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

            list.StartPage = (pageId - 2 <= 0) ? 1 : pageId - 2;
            list.EndPage = (pageId + 9 > list.PageCount) ? list.PageCount : pageId + 9;

            list.InformationOrder = information.OrderBy(u => u.OrderSetDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public OrderViewModel GetDoneOrders(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int customerId = 0, int unitId = 0, string filterCustomerMobile = "", int filterExpertId = 0)
        {
            var date = DateTime.Now;
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                date = Convert.ToDateTime(estimatedTime).Date;
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IQueryable<Order> result = _context.Orders;

            IEnumerable<InformationOrderViewModel> information = ShowInformationDoneOrders();

            if (!string.IsNullOrEmpty(filterCustomerMobile))
            {
                information = information.Where(a => a.CustomerMobile.Contains(filterCustomerMobile));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date == date);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date >= fDate && r.OrderChangeLevelDate.Date <= tDate);
            }

            if (customerId != 0)
            {
                information = information.Where(a => a.CustomerId == customerId);
            }

            if (unitId != 0)
            {
                information = information.Where(a => a.UnitId == unitId);
            }

            if (filterExpertId != 0)
            {
                information = information.Where(a => a.ExpertId == filterExpertId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            OrderViewModel list = new OrderViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);

            list.StartPage = (pageId - 2 <= 0) ? 1 : pageId - 2;
            list.EndPage = (pageId + 9 > list.PageCount) ? list.PageCount : pageId + 9;

            list.InformationOrder = information.OrderByDescending(u => u.OrderChangeLevelDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public OrderViewModel GetDoneOrdersForPrint(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int customerId = 0, int unitId = 0, string filterCustomerMobile = "", int filterExpertId = 0)
        {
            var date = DateTime.Now;
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                date = Convert.ToDateTime(estimatedTime).Date;
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IQueryable<Order> result = _context.Orders;

            IEnumerable<InformationOrderViewModel> information = ShowInformationDoneOrders();

            if (!string.IsNullOrEmpty(filterCustomerMobile))
            {
                information = information.Where(a => a.CustomerMobile.Contains(filterCustomerMobile));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date == date);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date >= fDate && r.OrderChangeLevelDate.Date <= tDate);
            }

            if (customerId != 0)
            {
                information = information.Where(a => a.CustomerId == customerId);
            }

            if (unitId != 0)
            {
                information = information.Where(a => a.UnitId == unitId);
            }

            if (filterExpertId != 0)
            {
                information = information.Where(a => a.ExpertId == filterExpertId);
            }
            

            OrderViewModel list = new OrderViewModel();
            list.InformationOrder = information.OrderByDescending(u => u.OrderChangeLevelDate).ToList();

            return list;
        }

        public OrderViewModel GetDeniedOrders(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int customerId = 0, int unitId = 0, string filterDamageDescription = "")
        {
            var date = DateTime.Now;
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                date = Convert.ToDateTime(estimatedTime).Date;
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IQueryable<Order> result = _context.Orders;

            IEnumerable<InformationOrderViewModel> information = ShowInformationDeniedOrders();

            if (!string.IsNullOrEmpty(filterDamageDescription))
            {
                information = information.Where(a => a.DamageDescription.Contains(filterDamageDescription));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date == date);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date >= fDate && r.OrderChangeLevelDate.Date <= tDate);
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
            editSendToCompany.Description = sendTo.Description;
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
                UnitId = s.UnitId,
                IsSend = s.IsSend,
                IsReturn = s.IsReturn,
                Description = s.Description
            }).Single();
        }

        public SendToCompanyViewModel GetSendToCompany(int pageId = 1, string setTime = "", string fromDate = "", string toDate = "", int customerId = 0, int companyId = 0, int unitId = 0)
        {
            var date = DateTime.Now;
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(setTime))
            {
                date = Convert.ToDateTime(setTime).Date;
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IQueryable<SendToCompany> result = _context.SendToCompanies;

            IEnumerable<InformationSendToCompanyViewModel> information = ShowInformationSendToCompany();

            if (!string.IsNullOrEmpty(setTime))
            {
                information = information.Where(r => r.SetDate.Date == date);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.SetDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.SetDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.SetDate.Date >= fDate && r.SetDate.Date <= tDate);
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
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);
            list.InformationSendToCompany = information.OrderBy(u => u.SetDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public SendToCompanyViewModel GetBackFromCompany(int pageId = 1, string returnTime = "", string fromDate = "", string toDate = "", int customerId = 0, int companyId = 0, int unitId = 0, int unitStatusId = 0)
        {
            var date = DateTime.Now;
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(returnTime))
            {
                date = Convert.ToDateTime(returnTime).Date;
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IQueryable<SendToCompany> result = _context.SendToCompanies;

            IEnumerable<InformationSendToCompanyViewModel> information = ShowInformationBackFromCompany();

            if (!string.IsNullOrEmpty(returnTime))
            {
                information = information.Where(r => r.SetDate.Date == date);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.SetDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.SetDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.SetDate.Date >= fDate && r.SetDate.Date <= tDate);
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
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);
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
