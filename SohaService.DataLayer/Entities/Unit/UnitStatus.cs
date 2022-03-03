using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.DataLayer.Entities.Orders;

namespace SohaService.DataLayer.Entities.Unit
{
    public class UnitStatus
    {
        [Key]
        public int UnitStatusId { get; set; }

        [Display(Name = "وضعیت قطعه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string UnitStatusTitle { get; set; }
        public bool IsDelete { get; set; }

        #region Relations

        public List<SendToCompany> SendToCompanies { get; set; }
        public List<Repair.Repair> Repairs { get; set; }

        #endregion

    }
}
