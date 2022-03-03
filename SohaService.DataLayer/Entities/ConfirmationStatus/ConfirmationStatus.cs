using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.DataLayer.Entities.Orders;

namespace SohaService.DataLayer.Entities.ConfirmationStatus
{
    public class ConfirmationStatus
    {
        [Key]
        public int ConfirmationStatusId { get; set; }
        public string ConfirmationStatusTitle { get; set; }

        #region Relations

        public List<Order> Orders { get; set; }
        public List<Repair.Repair> Repairs { get; set; }

        #endregion
    }
}
