using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using SohaService.Core.DTOs.Customer;
using SohaService.Core.DTOs.Order;
using SohaService.Core.DTOs.Pay;
using SohaService.DataLayer.Entities.Orders;

namespace SohaService.Core.Services.Interfaces
{
    public interface IOrderService
    {
        #region Orders

        int AddOrder(Order order);
        void DeleteOrder(int orderId);
        void EditOrder(Order order);
        void EditDoneOrder(Order order);
        void ChangeLevelOrder(Order order);
        OrderViewModel GetReadyOrders(int pageId = 1, string estimatedTime="", int customerId = 0, int unitId = 0, string filterCustomerMobile = "");
        OrderViewModel GetDoneOrders(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int customerId = 0, int unitId = 0, string filterCustomerMobile = "",int filterExpertId=0);
        OrderViewModel GetDoneOrdersForPrint(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int customerId = 0, int unitId = 0, string filterCustomerMobile = "",int filterExpertId=0);
        OrderViewModel GetDeniedOrders(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int customerId = 0, int unitId = 0, string filterDamageDescription = "");
        OrderViewModel GetDeletedOrders(int pageId = 1, string estimatedTime = "", int customerId = 0, int unitId = 0, string filterCustomerMobile = "");
        DebtorsViewModel GetDebtors(int pageId = 1, int filterCustomerId = 0,string filterAmount="",string filterDoneDate="",string fromDate="",string toDate="");
        DebtorsViewModel GetOrderDebtors(int pageId = 1, int filterCustomerId = 0,string filterAmount="",string filterDoneDate="",string fromDate="",string toDate="");
        DebtorsViewModel GetRepairDebtors(int pageId = 1, int filterCustomerId = 0,string filterAmount="",string filterDoneDate="",string fromDate="",string toDate="");
        DebtorsViewModel GetDebtorsForPrint(string fromDate = "", string toDate = "", int filterCustomerId = 0);
        DebtorsViewModel GetOrderDebtorsForPrint(string fromDate = "", string toDate = "", int filterCustomerId = 0);
        DebtorsViewModel GetRepairDebtorsForPrint(string fromDate = "", string toDate = "", int filterCustomerId = 0);
        OrderViewModel GetCustomersOrder(int customerId, int pageId = 1, string fromDate = "", string toDate = "");
        OrderViewModel GetReadyOrderByDate(string date);
        List<InformationOrderViewModel> ShowInformationOrder();
        List<InformationOrderViewModel> ShowInformationDoneOrders();
        List<InformationOrderViewModel> ShowInformationDeniedOrders();
        List<InformationOrderViewModel> ShowDeletedInformationOrder();
        List<InformationDebtorsViewModel> ShowDebtors();
        List<InformationOrderViewModel> ShowCustomersOrder(int customerId);
        InformationOrderViewModel ShowInformationOrderById(int orderId);
        Order GetDataForEditOrder(int orderId);
        Order GetOrderById(int orderId);
        int GetCountOrderByDate(DateTime date);
        void UpdateOrder(Order order);

        #endregion

        #region SendToCompany

        int AddSendToCompany(SendToCompany sendTo);
        void DeleteSendToCompany(int sendId);
        void EditSendToCompany(SendToCompany sendTo);
        void EditBackFromCompany(SendToCompany sendTo);
        SendToCompanyViewModel GetSendToCompany(int pageId = 1, string setTime = "", string fromDate = "", string toDate = "", int customerId=0, int companyId = 0, int unitId = 0);
        SendToCompanyViewModel GetBackFromCompany(int pageId = 1, string returnTime = "", string fromDate = "", string toDate = "", int customerId = 0, int companyId = 0, int unitId = 0,int unitStatusId=0);
        List<InformationSendToCompanyViewModel> ShowInformationSendToCompany();
        List<InformationSendToCompanyViewModel> ShowInformationBackFromCompany();
        List<InformationSendToCompanyViewModel> ShowInformationDeletedSendToCompany();
        InformationSendToCompanyViewModel ShowInformationSendToCompanyById(int orderId);
        SendToCompany GetDataForEditSendToCompany(int sendId);
        SendToCompany GetSendToCompanyById(int sendId);
        SendToCompany GetSendToCompanyByOrderId(int orderId);
        void UpdateSendToCompany(SendToCompany sendTo);

        #endregion
    }
}
