using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.DataLayer.Entities.Unit;

namespace SohaService.DataLayer.Entities.Orders
{
    public class SendToCompany
    {
        [Key]
        public int SendToCompanyId { get; set; }
        public int OrderId { get; set; }
        public int CompanyId { get; set; }
        public int UnitId { get; set; }
        public int UnitStatusId { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime SetDate { get; set; }

        [Display(Name = "تاریخ بازگشت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "تاریخ نصب مجدد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime AssemblingDate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsSend { get; set; }

        #region Relations

        public Order Order { get; set; }
        public Company.Company Company { get; set; }
        public Unit.Unit Unit { get; set; }
        public UnitStatus UnitStatus { get; set; }

        #endregion

    }
}
