using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.DataLayer.Entities.Orders;

namespace SohaService.Core.DTOs.Order
{
    public class OrderViewModel
    {
        public List<DataLayer.Entities.Orders.Order> Orders { get; set; }
        public List<InformationOrderViewModel> InformationOrder { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class InformationOrderViewModel
    {
        public int OrderId { get; set; }
        public int OrderLevelId { get; set; }
        public int CustomerId { get; set; }
        public int ExpertId { get; set; }
        public int UnitId { get; set; }
        public DateTime OrderSetDate { get; set; }
        public DateTime OrderChangeLevelDate { get; set; }
        public DateTime EstimatedToSendExpertTime { get; set; }
        public int EstimatedAmount { get; set; }
        public int ReceivedAmount { get; set; }
        public int RemainingAmount { get; set; }
        public string DamageDescription { get; set; }
        public string DoneDescription { get; set; }
        public string OrderLevelTitle { get; set; }
        public string CustomerNameFamily { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerUNumber { get; set; }
        public string ExpertNameFamily { get; set; }
        public string ExpertMobile { get; set; }
        public string UnitName { get; set; }
        public string CustomerFamily { get; set; }
        public string ExpertFamily { get; set; }
        public bool IsDelete { get; set; }

    }

    public class SendToCompanyViewModel
    {
        public List<SendToCompany> SendToCompanies { get; set; }
        public List<InformationSendToCompanyViewModel> InformationSendToCompany { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class InformationSendToCompanyViewModel
    {
        public int SendToCompanyId { get; set; }
        public int OrderId { get; set; }
        public int OrderLevelId { get; set; }
        public int UnitId { get; set; }
        public int CompanyId { get; set; }
        public int UnitStatusId { get; set; }
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyAddress { get; set; }
        public string CustomerNameFamily { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerUNumber { get; set; }
        public string CustomerFamily { get; set; }
        public string OrderLevelTitle { get; set; }
        public string UnitName { get; set; }
        public string UnitStatusTitle { get; set; }
        public DateTime SetDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime AssemblingDate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsSend { get; set; }
        public bool IsReturn { get; set; }
    }
}
