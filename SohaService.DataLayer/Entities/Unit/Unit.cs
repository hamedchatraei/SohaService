using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.DataLayer.Entities.Orders;

namespace SohaService.DataLayer.Entities.Unit
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string UnitName { get; set; }
        public bool IsDelete { get; set; }

        #region Relations

        public List<SendToCompany> SendToCompanies { get; set; }
        public List<Order> Orders { get; set; }

        #endregion

    }
}
