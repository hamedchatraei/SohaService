using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SohaService.Core.DTOs.Pay
{
    public class DebtorsViewModel
    {
        public List<InformationDebtorsViewModel> InformationDebtorsViewModels { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class InformationDebtorsViewModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerNameFamily { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerAddress { get; set; }
        public string UnitName { get; set; }
        public string DamageDescription { get; set; }
        public DateTime OrderChangeLevelDate { get; set; }
        public int TotalCost { get; set; }
        public int FinalAmount { get; set; }
        public int RemainingAmount { get; set; }
        public string WitchOne { get; set; }
        public string DoneDescription { get; set; }
    }
}
