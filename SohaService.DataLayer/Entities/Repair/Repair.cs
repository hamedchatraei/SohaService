using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.DataLayer.Entities.Unit;

namespace SohaService.DataLayer.Entities.Repair
{
    public class Repair
    {
        [Key]
        public int RepairId { get; set; }
        public int CustomerId { get; set; }
        public int UnitStatusId { get; set; }
        public int CompanyId { get; set; }
        public int ConfirmationStatusId { get; set; }
        public DateTime ReceivedUnitDate { get; set; }
        public DateTime EstimatedToSendUnitDate { get; set; }
        public DateTime RepairDate { get; set; }
        public DateTime SendUnitDate { get; set; }
        public int EstimatedAmount { get; set; }
        public int Discount { get; set; }
        public int FinalAmount { get; set; }
        public int TotalCost { get; set; }
        public int ReceivedAmount { get; set; }
        public int RemainingAmount { get; set; }
        public string DamageDescription { get; set; }
        public string DoneDescription { get; set; }
        public bool IsRepair { get; set; }
        public bool IsReady{ get; set; }
        public bool IsSend{ get; set; }
        public bool IsDelete { get; set; }
        public string WitchOne { get; set; }
        public string UnitName { get; set; }
        public string registrant { get; set; }

        #region Relations

        public Customer.Customer Customer { get; set; }
        public UnitStatus UnitStatus { get; set; }
        public Company.Company Company { get; set; }
        public List<Pay.Pay> Pays { get; set; }
        public ConfirmationStatus.ConfirmationStatus ConfirmationStatus { get; set; }

        #endregion
    }
}
