using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.DataLayer.Entities.Orders;

namespace SohaService.DataLayer.Entities.Pay
{
    public class Pay
    {
        [Key]
        public int PayId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }

        [Display(Name = "تاریخ پرداخت")]
        [Required]
        public DateTime PayDate { get; set; }

        #region Relations

        public Order Order { get; set; }

        #endregion
    }
}
