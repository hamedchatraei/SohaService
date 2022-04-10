using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SohaService.Core.DTOs.Pay
{
    public class PayViewModel
    {
        public List<InformationPayViewModel> InformationPayViewModels { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }

    public class InformationPayViewModel
    {
        public int? OrderId { get; set; }
        public int? RepairId { get; set; }
        public int PayId { get; set; }
        public int Amount { get; set; }
        public DateTime PayDate { get; set; }
        public int OrderCustomerId { get; set; }
        public int RepairCustomerId { get; set; }
        public int ReapirUnitId { get; set; }
        public int OrderUnitId { get; set; }
        public string OrderWitchOne { get; set; }
        public string RepairWitchOne { get; set; }
        public string OrderDamageDescription { get; set; }
        public string RepairDamageDescription { get; set; }
        public DateTime OrderChangeLevelDate { get; set; }
        public DateTime SendUnitDate { get; set; }
        public int ExpertId { get; set; }
        public DateTime OrderSetDate { get; set; }
        public DateTime EstimatedToSendExpertTime { get; set; }
        public int OrderEstimatedAmount { get; set; }
        public int OrderReceivedAmount { get; set; }
        public int OrderRemainingAmount { get; set; }
        public string OrderDoneDescription { get; set; }
        public int OrderDiscount { get; set; }
        public int OrderTotalCost { get; set; }
        public int UnitStatusId { get; set; }
        public int CompanyId { get; set; }
        public DateTime ReceivedUnitDate { get; set; }
        public DateTime EstimatedToSendUnitDate { get; set; }
        public DateTime RepairDate { get; set; }
        public int RepairEstimatedAmount { get; set; }
        public int RepairDiscount { get; set; }
        public int RepairTotalCost { get; set; }
        public int RepairReceivedAmount { get; set; }
        public int RepairRemainingAmount { get; set; }
        public string RepairDoneDescription { get; set; }
        public bool IsRepair { get; set; }
        public bool IsReady { get; set; }
        public bool IsSend { get; set; }
        public int RepairFinalAmount { get; set; }
        public int OrderFinalAmount { get; set; }
        public string RepairUnitName { get; set; }
        public string OrderUnitName { get; set; }

    }
}
