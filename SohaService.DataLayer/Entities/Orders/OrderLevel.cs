using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SohaService.DataLayer.Entities.Orders
{
    public class OrderLevel
    {
        [Key]
        public int OrderLevelId { get; set; }

        [Display(Name = "مرحله ی سفارش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string OrderLevelTitle { get; set; }


        #region Relations

        public List<Order> Orders { get; set; }

        #endregion

    }
}
