using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SohaService.DataLayer.Entities.Orders
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int OrderLevelId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        
        public int ExpertId { get; set; }

        public int UnitId { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime OrderSetDate { get; set; }

        public DateTime OrderChangeLevelDate { get; set; }

        [Display(Name = "زمان برآورد شده ارسال کارشناس")]
        public DateTime EstimatedToSendExpertTime { get; set; }

        [Display(Name = "هزینه برآورد شده")]
        public int EstimatedAmount { get; set; }

        [Display(Name = "تخفیف")]
        public int Discount { get; set; }

        [Display(Name = "علت تخفیف")]
        public string DiscountTitle { get; set; }

        [Display(Name = "هزینه کل")]
        public int TotalCost { get; set; }

        [Display(Name = "هزینه دریافت شده")]
        public int ReceivedAmount { get; set; }

        [Display(Name = "هزینه باقی مانده")]
        public int RemainingAmount { get; set; }

        [Display(Name = "شرح خرابی")]
        public string DamageDescription { get; set; }

        [Display(Name = "توضیحات")]
        public string DoneDescription { get; set; }
        public bool IsDelete { get; set; }


        #region Relations

        public OrderLevel OrderLevel { get; set; }
        public Customer.Customer Customer { get; set; }
        public Expert.Expert Expert { get; set; }
        public SendToCompany SendToCompany { get; set; }
        public Unit.Unit Unit { get; set; }
        public List<Pay.Pay> Pays { get; set; }

        #endregion

    }
}
