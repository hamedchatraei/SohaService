using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SohaService.Core.DTOs.Repair
{
    public class RepairViewModel
    {
        public List<DataLayer.Entities.Repair.Repair> Repairs { get; set; }
        public List<InformationRepairViewModel> InformationRepairViewModels { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }

    public class InformationRepairViewModel
    {
        public int RepairId { get; set; }
        public int CustomerId { get; set; }
        public int UnitStatusId { get; set; }
        public int CompanyId { get; set; }
        public DateTime ReceivedUnitDate { get; set; }
        public DateTime EstimatedToSendUnitDate { get; set; }
        public DateTime RepairDate { get; set; }
        public DateTime SendUnitDate { get; set; }
        public int EstimatedAmount { get; set; }
        public int Discount { get; set; }
        public int TotalCost { get; set; }
        public int RemainingAmount { get; set; }
        public string DamageDescription { get; set; }
        public string DoneDescription { get; set; }
        public string CustomersNameFamily { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerUNumber { get; set; }
        public string UnitName { get; set; }
        public string UnitStatusTitle { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyAddress { get; set; }
        public bool IsRepair { get; set; }
        public bool IsReady { get; set; }
        public int ReceivedAmount { get; set; }
        public bool IsDelete { get; set; }
        public bool IsSend { get; set; }
        public int ConfirmationStatusId { get; set; }
        public int FinalAmount { get; set; }
        public string registrant { get; set; }

    }
}
