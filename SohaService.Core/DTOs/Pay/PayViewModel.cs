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
    }

    public class InformationPayViewModel
    {
        public int PayId { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int Amount { get; set; }
        public DateTime PayDate { get; set; }
        public int ExpertId { get; set; }
        public DateTime OrderSetDate { get; set; }
        public DateTime OrderChangeLevelDate { get; set; }
        public DateTime EstimatedToSendExpertTime { get; set; }
        public int EstimatedAmount { get; set; }
        public int ReceivedAmount { get; set; }
        public int RemainingAmount { get; set; }
        public string DamageDescription { get; set; }
        public string DoneDescription { get; set; }
        public int UnitId { get; set; }
        public string CustomerNameFamily { get; set; }
        public string CustomerFamily { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerUNumber { get; set; }
        public string UnitName { get; set; }
        public int Discount { get; set; }
        public string DiscountTitle { get; set; }
        public int TotalCost { get; set; }

    }
}
