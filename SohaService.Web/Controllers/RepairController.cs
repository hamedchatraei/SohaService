using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SohaService.Core.Convertor;
using SohaService.Core.DTOs.Repair;
using SohaService.Core.Security;
using SohaService.Core.Senders;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.ApiKey;
using SohaService.DataLayer.Entities.Customer;
using SohaService.DataLayer.Entities.Pay;
using SohaService.DataLayer.Entities.Repair;
using SohaService.DataLayer.Entities.Unit;
using SohaService.DataLayer.Entities.User;

namespace SohaService.Web.Controllers
{
    [PermissionChecker(1044)]
    public class RepairController : Controller
    {
        private IRepairService _repairService;
        private ICustomerService _customerService;
        private IUnitService _unitService;
        private ICompanyService _companyService;
        private IPayService _payService;
        private IUserService _userService;
        private ISmsService _smsService;

        public RepairController(IRepairService repairService, ICustomerService customerService, IUnitService unitService, ICompanyService companyService, IPayService payService, IUserService userService, ISmsService smsService)
        {
            _repairService = repairService;
            _customerService = customerService;
            _unitService = unitService;
            _companyService = companyService;
            _payService = payService;
            _userService = userService;
            _smsService = smsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Repairs

        [Route("Repairs")]
        public IActionResult Repairs(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int filterCustomerId = 0,
            int filterUnitId = 0, int filterCompanyId = 0, string filterCustomerMobile = "")
        {
            if (estimatedTime == "today")
            {
                estimatedTime = DateTime.Now.ToString();

            }

            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                toDate = "";
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                estimatedTime = "";
            }

            RepairViewModel repair = _repairService.GetRepairs(pageId,estimatedTime,fromDate,toDate,filterCustomerId,filterUnitId,filterCompanyId, filterCustomerMobile);

            List<SelectListItem> customers = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب مشتری",Value = ""}
            };
            customers.AddRange(_customerService.GetCustomerListItem());
            ViewData["customers"] = new SelectList(customers, "Value", "Text", 0);

            List<SelectListItem> units = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب قطعه",Value = ""}
            };
            units.AddRange(_unitService.GetUnitListItem());
            ViewData["units"] = new SelectList(units, "Value", "Text", 0);

            List<SelectListItem> company = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب شرکت",Value = ""}
            };
            company.AddRange(_companyService.GetCompanyListItem());
            ViewData["company"] = new SelectList(company, "Value", "Text", 0);

            ViewData["esTime"] = estimatedTime;

            return View(repair);
        }

        #endregion

        #region RepairedRepairs

        [Route("RepairedRepairs")]
        public IActionResult RepairedRepairs(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int filterCustomerId = 0,
            int filterUnitId = 0, int filterCompanyId = 0, string filterCustomerMobile = "")
        {
            if (estimatedTime == "today")
            {
                estimatedTime = DateTime.Now.ToString();

            }

            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                toDate = "";
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                estimatedTime = "";
            }

            RepairViewModel repair = _repairService.GetRepairedRepairs(pageId, estimatedTime,fromDate,toDate,filterCustomerId,filterUnitId,filterCompanyId, filterCustomerMobile);

            List<SelectListItem> customers = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب مشتری",Value = ""}
            };
            customers.AddRange(_customerService.GetCustomerListItem());
            ViewData["customers"] = new SelectList(customers, "Value", "Text", 0);

            List<SelectListItem> units = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب قطعه",Value = ""}
            };
            units.AddRange(_unitService.GetUnitListItem());
            ViewData["units"] = new SelectList(units, "Value", "Text", 0);

            List<SelectListItem> company = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب شرکت",Value = ""}
            };
            company.AddRange(_companyService.GetCompanyListItem());
            ViewData["company"] = new SelectList(company, "Value", "Text", 0);

            return View(repair);
        }

        #endregion

        #region DoneRepairs

        [Route("DoneRepairs")]
        public IActionResult DoneRepairs(int pageId = 1, string estimatedTime = "", string fromDate = "",
            string toDate = "", int filterCustomerId = 0,
            int filterUnitId = 0, int filterCompanyId = 0, string filterCustomerMobile = "")
        {
            if (estimatedTime == "today")
            {
                estimatedTime = DateTime.Now.ToString();

            }

            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                toDate = "";
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                estimatedTime = "";
            }

            RepairViewModel repair = _repairService.GetDoneRepairs(pageId, estimatedTime, fromDate, toDate,
                filterCustomerId, filterUnitId, filterCompanyId, filterCustomerMobile);

            List<SelectListItem> customers = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب مشتری",Value = ""}
            };
            customers.AddRange(_customerService.GetCustomerListItem());
            ViewData["customers"] = new SelectList(customers, "Value", "Text", 0);

            List<SelectListItem> units = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب قطعه",Value = ""}
            };
            units.AddRange(_unitService.GetUnitListItem());
            ViewData["units"] = new SelectList(units, "Value", "Text", 0);

            List<SelectListItem> company = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب شرکت",Value = ""}
            };
            company.AddRange(_companyService.GetCompanyListItem());
            ViewData["company"] = new SelectList(company, "Value", "Text", 0);

            return View(repair);
        }

        #endregion

        #region DeniedRepairs

        [Route("DeniedRepairs")]
        public IActionResult DeniedRepairs(int pageId = 1, string estimatedTime = "", string fromDate = "",
            string toDate = "", int filterCustomerId = 0,
            int filterUnitId = 0, int filterCompanyId = 0, string filterCustomerMobile = "")
        {
            if (estimatedTime == "today")
            {
                estimatedTime = DateTime.Now.ToString();

            }

            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                fromDate = "";
                toDate = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                toDate = "";
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                fromDate = "";
                estimatedTime = "";
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                estimatedTime = "";
            }

            RepairViewModel repair = _repairService.GetDeniedRepairs(pageId, estimatedTime, fromDate, toDate,
                filterCustomerId, filterUnitId, filterCompanyId, filterCustomerMobile);

            List<SelectListItem> customers = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب مشتری",Value = ""}
            };
            customers.AddRange(_customerService.GetCustomerListItem());
            ViewData["customers"] = new SelectList(customers, "Value", "Text", 0);

            List<SelectListItem> units = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب قطعه",Value = ""}
            };
            units.AddRange(_unitService.GetUnitListItem());
            ViewData["units"] = new SelectList(units, "Value", "Text", 0);

            List<SelectListItem> company = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب شرکت",Value = ""}
            };
            company.AddRange(_companyService.GetCompanyListItem());
            ViewData["company"] = new SelectList(company, "Value", "Text", 0);

            return View(repair);
        }

        #endregion

        #region DeletedRepairs

        [Route("DeletedRepairs")]
        public IActionResult DeletedRepairs(int pageId = 1, string estimatedTime = "", int filterCustomerId = 0,
            int filterUnitId = 0, int filterCompanyId = 0, string filterCustomerMobile = "")
        {
            RepairViewModel repair = _repairService.GetDeletedRepair(pageId, estimatedTime, filterCustomerId,
                filterUnitId, filterCompanyId, filterCustomerMobile);

            List<SelectListItem> customers = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب مشتری",Value = ""}
            };
            customers.AddRange(_customerService.GetCustomerListItem());
            ViewData["customers"] = new SelectList(customers, "Value", "Text", 0);

            List<SelectListItem> units = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب قطعه",Value = ""}
            };
            units.AddRange(_unitService.GetUnitListItem());
            ViewData["units"] = new SelectList(units, "Value", "Text", 0);

            List<SelectListItem> company = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب شرکت",Value = ""}
            };
            company.AddRange(_companyService.GetCompanyListItem());
            ViewData["company"] = new SelectList(company, "Value", "Text", 0);

            return View(repair);
        }

        #endregion

        #region InformationRepair

        [Route("InformationRepair/{id}")]
        public IActionResult InformationRepair(int id)
        {
            InformationRepairViewModel repair = _repairService.ShowInformationRepairById(id);

            return View(repair);
        }

        #endregion

        #region AddRepair

        [Route("AddRepair/{id}")]
        public IActionResult AddRepair(int id)
        {
            List<SelectListItem> customers = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب مشتری",Value = ""}
            };
            customers.AddRange(_customerService.GetCustomerListItem());
            ViewData["customers"] = new SelectList(customers, "Value", "Text", id);

            List<SelectListItem> units = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب قطعه",Value = ""}
            };
            units.AddRange(_unitService.GetUnitListItem());
            ViewData["units"] = new SelectList(units, "Value", "Text", 0);

            List<SelectListItem> company = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب شرکت",Value = ""}
            };
            company.AddRange(_companyService.GetCompanyListItem());
            ViewData["company"] = new SelectList(company, "Value", "Text", 0);

            return View();
        }

        [HttpPost]
        [Route("AddRepair/{id}")]
        public IActionResult AddRepair(Repair repair)
        {
            if (!ModelState.IsValid)
                return View(repair);

            User myUser = _userService.GetUserByUserName(User.Identity.Name);

            repair.RepairDate=DateTime.Now;
            repair.SendUnitDate=DateTime.Now;
            repair.ReceivedUnitDate=DateTime.Now;
            repair.UnitStatusId = 1;
            repair.IsRepair = false;
            repair.IsReady = true;
            repair.IsSend = false;
            repair.WitchOne = "Repair";
            repair.ConfirmationStatusId = 1;
            repair.registrant = myUser.UserAliasName;

            int repairId = _repairService.AddRepair(repair);

            Customer customer = _customerService.GetCustomerById(repair.CustomerId);

            DataLayer.Entities.User.User user = _userService.GetUserByUserName(User.Identity.Name);


            ApiKey apiKey = _smsService.ShowApiKey();
            string userApiKey = apiKey.ApiKeyCode;
            string secretCode = apiKey.SecurityCode;

            //SendSMS.SendForRepair(customer.CustomerMobile,customer.CustomerName,repair.UnitName,user.UserAliasName);
            SendSMS sms = new SendSMS();
            sms.SendForRepair(customer.CustomerMobile, customer.CustomerName,repair.UnitName,user.UserAliasName,userApiKey,secretCode);

            return Redirect($"/InformationRepair/{repairId}");
        }

        #endregion

        #region RepairedRepair

        [Route("RepairedRepair/{id}")]
        public IActionResult RepairedRepair(int id)
        {
            Repair repair = _repairService.GetDataForEditRepair(id);

            List<SelectListItem> unitStatus = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب وضعیت قطعه",Value = ""}
            };
            unitStatus.AddRange(_unitService.GetUnitStatusListItem());
            ViewData["unitStatus"] = new SelectList(unitStatus, "Value", "Text", 0);

            return View(repair);
        }

        [HttpPost]
        [Route("RepairedRepair/{id}")]
        public IActionResult RepairedRepair(Repair repair)
        {
            if (!ModelState.IsValid)
                return View(repair);


            repair.IsRepair = true;
            repair.IsReady = false;
            repair.IsSend = false;
            repair.ConfirmationStatusId = 2;

            _repairService.EditDoneRepair(repair);

            int repairId = repair.RepairId;

            Customer customer = _customerService.GetCustomerById(repair.CustomerId);

            DataLayer.Entities.User.User user = _userService.GetUserByUserName(User.Identity.Name);


            ApiKey apiKey = _smsService.ShowApiKey();
            string userApiKey = apiKey.ApiKeyCode;
            string secretCode = apiKey.SecurityCode;

            //SendSMS.SendForRepair(customer.CustomerMobile,customer.CustomerName,repair.UnitName,user.UserAliasName);
            SendSMS sms = new SendSMS();
            sms.SendForAcceptRepair(customer.CustomerMobile, customer.CustomerName, repair.UnitName, user.UserAliasName, userApiKey, secretCode);

            return Redirect($"/InformationRepair/{repairId}");
        }

        #endregion

        #region DoneRepair

        [Route("DoneRepair/{id}")]
        public IActionResult DoneRepair(int id)
        {
            Repair repair = _repairService.GetDataForEditRepair(id);

            return View(repair);
        }

        [HttpPost]
        [Route("DoneRepair/{id}")]
        public IActionResult DoneRepair(Repair repair)
        {
            if (!ModelState.IsValid)
                return View(repair);


            Pay pay = new Pay();
            pay.RepairId = repair.RepairId;
            pay.Amount = repair.ReceivedAmount;
            pay.PayDate = repair.SendUnitDate;

            _payService.AddPay(pay);

            int fAmount = repair.FinalAmount;
            int discount = repair.Discount;
            int totalCost = fAmount - discount;
            int resAmount = _payService.GetSumAmountRepairPay(repair.RepairId);
            int remAmount = totalCost - resAmount;

            repair.TotalCost = totalCost;
            repair.RemainingAmount = remAmount;
            repair.IsRepair = false;
            repair.IsReady = false;
            repair.IsSend = true;
            repair.ConfirmationStatusId = 2;

            _repairService.EditDoneRepair(repair);

            int repairId = repair.RepairId;

            return Redirect($"/InformationRepair/{repairId}");
        }

        #endregion

        #region EditRepair

        [Route("EditRepair/{id}")]
        public IActionResult EditRepair(int id)
        {
            Repair repair = _repairService.GetDataForEditRepair(id);

            List<SelectListItem> customers = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب مشتری",Value = ""}
            };
            customers.AddRange(_customerService.GetCustomerListItem());
            ViewData["customers"] = new SelectList(customers, "Value", "Text", 0);

            List<SelectListItem> units = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب قطعه",Value = ""}
            };
            units.AddRange(_unitService.GetUnitListItem());
            ViewData["units"] = new SelectList(units, "Value", "Text", 0);

            List<SelectListItem> company = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب شرکت",Value = ""}
            };
            company.AddRange(_companyService.GetCompanyListItem());
            ViewData["company"] = new SelectList(company, "Value", "Text", 0);

            return View(repair);
        }

        [HttpPost]
        [Route("EditRepair/{id}")]
        public IActionResult EditRepair(Repair repair)
        {
            if (!ModelState.IsValid)
                return View(repair);

            

            _repairService.EditRepair(repair);

            int repairId = repair.RepairId;
            return Redirect($"/InformationRepair/{repairId}");
        }

        #endregion

        #region EditRepairedRepair

        [Route("EditRepairedRepair/{id}")]
        public IActionResult EditRepairedRepair(int id)
        {
            Repair repair = _repairService.GetDataForEditRepair(id);

            List<SelectListItem> unitStatus = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب وضعیت قطعه",Value = ""}
            };
            unitStatus.AddRange(_unitService.GetUnitStatusListItem());
            ViewData["unitStatus"] = new SelectList(unitStatus, "Value", "Text", 0);

            List<SelectListItem> company = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب شرکت",Value = ""}
            };
            company.AddRange(_companyService.GetCompanyListItem());
            ViewData["company"] = new SelectList(company, "Value", "Text", 0);

            return View(repair);
        }

        [HttpPost]
        [Route("EditRepairedRepair/{id}")]
        public IActionResult EditRepairedRepair(Repair repair)
        {
            if (!ModelState.IsValid)
                return View(repair);

            _repairService.EditDoneRepair(repair);

            int repairId = repair.RepairId;
            return Redirect($"/InformationRepair/{repairId}");
        }

        #endregion

        #region EditDoneRepair

        [Route("EditDoneRepair/{id}")]
        public IActionResult EditDoneRepair(int id)
        {
            Repair repair = _repairService.GetDataForEditRepair(id);

            return View(repair);
        }

        [HttpPost]
        [Route("EditDoneRepair/{id}")]
        public IActionResult EditDoneRepair(Repair repair)
        {
            if (!ModelState.IsValid)
                return View(repair);

            Pay pay = _payService.GetFirstPayByRepairId(repair.RepairId);
            pay.RepairId = repair.RepairId;
            pay.Amount = repair.ReceivedAmount;
            pay.PayDate = repair.SendUnitDate;

            _payService.EditPay(pay);

            int fAmount = repair.FinalAmount;
            int discount = repair.Discount;
            int totalCost = fAmount - discount;
            int resAmount = _payService.GetSumAmountRepairPay(repair.RepairId);
            int remAmount = totalCost - resAmount;

            repair.TotalCost = totalCost;
            repair.RemainingAmount = remAmount;
            repair.IsRepair = false;
            repair.IsReady = false;
            repair.IsSend = true;
            repair.ConfirmationStatusId = 2;

            repair.IsSend = true;
            _repairService.EditDoneRepair(repair);

            int repairId = repair.RepairId;
            return Redirect($"/InformationRepair/{repairId}");
        }

        #endregion

        #region DeleteRepair

        [Route("DeleteRepair/{id}")]
        public IActionResult DeleteRepair(int id)
        {
            Repair repair = _repairService.GetRepairById(id);

            return View(repair);
        }

        [HttpPost]
        [Route("DeleteRepair/{id}")]
        public IActionResult DeleteRepair(Repair repair)
        {
            _repairService.DeleteRepair(repair.RepairId);

            return Redirect("/Repairs");
        }

        #endregion
    }
}
