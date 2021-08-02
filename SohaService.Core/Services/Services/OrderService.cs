using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SohaService.Core.DTOs.Order;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Context;
using SohaService.DataLayer.Entities.Orders;

namespace SohaService.Core.Services.Services
{
    public class OrderService : IOrderService
    {
        private SohaServiceContext _context;

        public OrderService(SohaServiceContext context)
        {
            _context = context;
        }

        #region Orders

        public int AddOrder(Order order)
        {
            _context.Orders.AddAsync(order);
            _context.SaveChangesAsync();
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
            editOrder.ExpertId = order.ExpertId;
            editOrder.DamageDescription = order.DamageDescription;
            editOrder.EstimatedAmount = order.EstimatedAmount;
            editOrder.EstimatedToSendExpertTime = order.EstimatedToSendExpertTime;
            UpdateOrder(editOrder);
        }

        public void ChangeLevelOrder(Order order)
        {
            Order changeOrder = GetOrderById(order.OrderId);
            changeOrder.OrderLevelId = order.OrderLevelId;
            UpdateOrder(changeOrder);
        }

        public Order GetDataForEditOrder(int orderId)
        {
            return _context.Orders.Where(o => o.OrderId == orderId).Select(o => new Order()
            {
                OrderId = orderId,
                CustomerId = o.CustomerId,
                ExpertId = o.ExpertId,
                DamageDescription = o.DamageDescription,
                EstimatedAmount = o.EstimatedAmount,
                EstimatedToSendExpertTime = o.EstimatedToSendExpertTime
            }).Single();
        }
        
        public OrderViewModel GetDeletedOrders(int pageId = 1, string estimatedTime = "", int customerId = 0, int unitId = 0, string filterDamageDescription = "")
        {
            IQueryable<Order> result = _context.Orders.IgnoreQueryFilters().Where(e => e.IsDelete);

            if (!string.IsNullOrEmpty(filterDamageDescription))
            {
                result = result.Where(a => a.DamageDescription.Contains(filterDamageDescription));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                result = result.Where(r => r.OrderSetDate == Convert.ToDateTime(estimatedTime));
            }

            if (customerId != 0)
            {
                result = result.Where(a => a.CustomerId == customerId);
            }

            if (unitId != 0)
            {
                result = result.Where(a => a.UnitId == unitId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            OrderViewModel list = new OrderViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.Orders = result.OrderBy(u => u.OrderSetDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders.Find(orderId);
        }

        public OrderViewModel GetOrders(int pageId = 1, string estimatedTime = "", int customerId = 0, int unitId = 0, string filterDamageDescription = "")
        {
            IQueryable<Order> result = _context.Orders;

            if (!string.IsNullOrEmpty(filterDamageDescription))
            {
                result = result.Where(a => a.DamageDescription.Contains(filterDamageDescription));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                result = result.Where(r => r.OrderSetDate == Convert.ToDateTime(estimatedTime));
            }

            if (customerId != 0)
            {
                result = result.Where(a => a.CustomerId == customerId);
            }

            if (unitId != 0)
            {
                result = result.Where(a => a.UnitId == unitId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            OrderViewModel list = new OrderViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.Orders = result.OrderBy(u => u.OrderSetDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChangesAsync();
        }

        #endregion

        #region SendToCompany

        public int AddSendToCompany(SendToCompany sendTo)
        {
            _context.SendToCompanies.AddAsync(sendTo);
            _context.SaveChangesAsync();
            return sendTo.SendToCompanyId;
        }

        public void DeleteSendToCompany(int sendId)
        {
            SendToCompany sendTo = GetSendToCompanyById(sendId);
            sendTo.IsDelete = true;
            UpdateSendToCompany(sendTo);
        }

        public void EditSendToCompany(SendToCompany sendTo)
        {
            SendToCompany editSendToCompany = GetSendToCompanyById(sendTo.SendToCompanyId);
            editSendToCompany.CompanyId = sendTo.CompanyId;
            editSendToCompany.OrderId = sendTo.OrderId;
            editSendToCompany.UnitId = sendTo.UnitId;
            UpdateSendToCompany(editSendToCompany);
        }

        public SendToCompany GetDataForEditSendToCompany(int sendId)
        {
            return _context.SendToCompanies.Where(s => s.SendToCompanyId == sendId).Select(s => new SendToCompany()
            {
                SendToCompanyId = sendId,
                CompanyId = s.CompanyId,
                OrderId = s.OrderId,
                UnitId = s.UnitId
            }).Single();
        }

        public SendToCompanyViewModel GetDeletedSendToCompany(int pageId = 1, string setTime = "", int expertId = 0, int CompanyId = 0)
        {
            IQueryable<SendToCompany> result = _context.SendToCompanies.IgnoreQueryFilters().Where(e => e.IsDelete);

            if (!string.IsNullOrEmpty(setTime))
            {
                result = result.Where(r => r.SetDate == Convert.ToDateTime(setTime));
            }

            if (CompanyId != 0)
            {
                result = result.Where(a => a.CompanyId == CompanyId);
            }


            int take = 10;
            int skip = (pageId - 1) * take;

            SendToCompanyViewModel list = new SendToCompanyViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.SendToCompanies = result.OrderBy(u => u.SetDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public SendToCompanyViewModel GetSendToCompany(int pageId = 1, string setTime = "", int expertId = 0, int CompanyId = 0)
        {
            IQueryable<SendToCompany> result = _context.SendToCompanies;

            if (!string.IsNullOrEmpty(setTime))
            {
                result = result.Where(r => r.SetDate == Convert.ToDateTime(setTime));
            }

            if (CompanyId != 0)
            {
                result = result.Where(a => a.CompanyId == CompanyId);
            }


            int take = 10;
            int skip = (pageId - 1) * take;

            SendToCompanyViewModel list = new SendToCompanyViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.SendToCompanies = result.OrderBy(u => u.SetDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public SendToCompany GetSendToCompanyById(int sendId)
        {
            return _context.SendToCompanies.Find(sendId);
        }

        public void UpdateSendToCompany(SendToCompany sendTo)
        {
            _context.SendToCompanies.Update(sendTo);
            _context.SaveChangesAsync();
        }

        public void SetBackFromCompany(SendToCompany sendTo)
        {
            SendToCompany backFromCompany = GetSendToCompanyById(sendTo.SendToCompanyId);
            backFromCompany.AssemblingDate = sendTo.AssemblingDate;
            backFromCompany.UnitStatusId = sendTo.UnitStatusId;
            backFromCompany.ReturnDate = sendTo.ReturnDate;
            backFromCompany.IsSend = false;
            UpdateSendToCompany(backFromCompany);
        }

        public SendToCompany GetDataForSetBackFromCompany(int sendId)
        {
            return _context.SendToCompanies.Where(s => s.SendToCompanyId == sendId).Select(s => new SendToCompany()
            {
                UnitStatusId = s.UnitStatusId,
                AssemblingDate = s.AssemblingDate,
                ReturnDate = s.ReturnDate
            }).Single();
        }

        #endregion

    }
}
