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

        [Display(Name = "مشتری")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
        public int CustomerId { get; set; }

        [Required]
        public int ExpertId { get; set; }

        [Display(Name = "قطعه")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
        public int UnitId { get; set; }

        [Required]
        public int ConfirmationStatusId { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime OrderSetDate { get; set; }

        public DateTime OrderChangeLevelDate { get; set; }

        [Display(Name = "زمان برآورد شده ارسال کارشناس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime EstimatedToSendExpertTime { get; set; }

        [Display(Name = "هزینه برآورد شده سرویس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int EstimatedServiceAmount { get; set; }

        [Display(Name = "هزینه برآورد شده محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int EstimatedUnitAmount { get; set; }

        [Display(Name = "هزینه برآورد شده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int EstimatedAmount { get; set; }

        [Display(Name = "تخفیف")]
        public int Discount { get; set; }

        [Display(Name = "هزینه قطعی")]
        public int FinalAmount { get; set; }

        [Display(Name = "هزینه کل")]
        public int TotalCost { get; set; }

        [Display(Name = "هزینه دریافت شده")]
        public int ReceivedAmount { get; set; }

        [Display(Name = "هزینه باقی مانده")]
        public int RemainingAmount { get; set; }

        [Display(Name = "شرح خرابی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string DamageDescription { get; set; }

        [Display(Name = "توضیحات")]
        public string DoneDescription { get; set; }

        [Display(Name = "آدرس")]
        public string OrderAddress { get; set; }

        public bool IsDelete { get; set; }
        public string WitchOne { get; set; } 
        public string registrant { get; set; }


        #region Relations

        public OrderLevel OrderLevel { get; set; }
        public Customer.Customer Customer { get; set; }
        public Expert.Expert Expert { get; set; }
        public SendToCompany SendToCompany { get; set; }
        public Unit.Unit Unit { get; set; }
        public List<Pay.Pay> Pays { get; set; }
        public ConfirmationStatus.ConfirmationStatus ConfirmationStatus { get; set; }

        #endregion

    }
}
