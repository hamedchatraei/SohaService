using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.Core.DTOs.Order;
using SohaService.DataLayer.Entities.Orders;

namespace SohaService.Core.Services.Interfaces
{
    public interface IOrderService
    {
        #region Orders

        int AddOrder(Order order);
        void DeleteOrder(int orderId);
        void EditOrder(Order order);
        void ChangeLevelOrder(Order order);
        OrderViewModel GetOrders(int pageId = 1,string estimatedTime="", int customerId=0,int unitId=0, string filterDamageDescription = "");
        OrderViewModel GetDeletedOrders(int pageId = 1, string estimatedTime = "", int customerId = 0, int unitId = 0, string filterDamageDescription = "");
        Order GetDataForEditOrder(int orderId);
        Order GetOrderById(int orderId);
        void UpdateOrder(Order order);

        #endregion

        #region SendToCompany

        int AddSendToCompany(SendToCompany sendTo);
        void DeleteSendToCompany(int sendId);
        void EditSendToCompany(SendToCompany sendTo);
        void SetBackFromCompany(SendToCompany sendTo);
        SendToCompanyViewModel GetSendToCompany(int pageId = 1, string setTime = "",int expertId=0, int CompanyId = 0);
        SendToCompanyViewModel GetDeletedSendToCompany(int pageId = 1, string setTime = "", int expertId = 0, int CompanyId = 0);
        SendToCompany GetDataForEditSendToCompany(int sendId);
        SendToCompany GetDataForSetBackFromCompany(int sendId);
        SendToCompany GetSendToCompanyById(int sendId);
        void UpdateSendToCompany(SendToCompany sendTo);

        #endregion
    }
}
