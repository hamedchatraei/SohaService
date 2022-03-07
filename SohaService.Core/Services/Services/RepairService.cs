using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SohaService.Core.DTOs.Order;
using SohaService.Core.DTOs.Repair;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Context;
using SohaService.DataLayer.Entities.Repair;

namespace SohaService.Core.Services.Services
{
    public class RepairService: IRepairService
    {
        private SohaServiceContext _context;
        private IConfiguration _configuration;

        public RepairService(SohaServiceContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public int AddRepair(Repair repair)
        {
            _context.Repairs.Add(repair);
            _context.SaveChanges();
            return repair.RepairId;
        }

        public void DeleteRepair(int repairId)
        {
            Repair repair = GetRepairById(repairId);
            repair.IsDelete = true;
            _context.SaveChanges();
        }

        public void EditRepair(Repair repair)
        {
            Repair editRepair = GetRepairById(repair.RepairId);
            editRepair.CustomerId = repair.CustomerId;
            editRepair.CompanyId = repair.CompanyId;
            editRepair.ReceivedUnitDate = repair.ReceivedUnitDate;
            editRepair.EstimatedToSendUnitDate = repair.EstimatedToSendUnitDate;
            editRepair.EstimatedAmount = repair.EstimatedAmount;
            editRepair.DamageDescription = repair.DamageDescription;
            editRepair.UnitName = repair.UnitName;
            UpdateRepair(editRepair);
        }

        public void EditDoneRepair(Repair repair)
        {
            Repair editRepair = GetRepairById(repair.RepairId);
            editRepair.UnitStatusId = repair.UnitStatusId;
            editRepair.RepairDate = repair.RepairDate;
            editRepair.SendUnitDate = repair.SendUnitDate;
            editRepair.Discount = repair.Discount;
            editRepair.FinalAmount = repair.FinalAmount;
            editRepair.TotalCost = repair.TotalCost;
            editRepair.ReceivedAmount = repair.ReceivedAmount;
            editRepair.RemainingAmount = repair.RemainingAmount;
            editRepair.DoneDescription = repair.DoneDescription;
            editRepair.IsReady = repair.IsReady;
            editRepair.IsRepair = repair.IsRepair;
            editRepair.IsSend = repair.IsSend;
            editRepair.ConfirmationStatusId = repair.ConfirmationStatusId;
            editRepair.CustomerId = repair.CustomerId;
            editRepair.CompanyId = repair.CompanyId;
            editRepair.ReceivedUnitDate = repair.ReceivedUnitDate;
            editRepair.EstimatedToSendUnitDate = repair.EstimatedToSendUnitDate;
            editRepair.EstimatedAmount = repair.EstimatedAmount;
            editRepair.DamageDescription = repair.DamageDescription;
            editRepair.UnitName = repair.UnitName;
            UpdateRepair(editRepair);
        }

        public RepairViewModel GetRepairs(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int filterCustomerId = 0, int filterUnitId = 0,
            int filterCompanyId = 0, string filterCustomerMobile = "")
        {
            var date = DateTime.Now;
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                date = Convert.ToDateTime(estimatedTime).Date;
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IEnumerable<InformationRepairViewModel> information = ShowInformationRepair();

            if (!string.IsNullOrEmpty(filterCustomerMobile))
            {
                information = information.Where(a => a.CustomerMobile.Contains(filterCustomerMobile));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                information = information.Where(r => r.EstimatedToSendUnitDate.Date == date);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.ReceivedUnitDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.ReceivedUnitDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.ReceivedUnitDate.Date >= fDate && r.ReceivedUnitDate.Date <= tDate);
            }

            if (filterCustomerId != 0)
            {
                information = information.Where(a => a.CustomerId == filterCustomerId);
            }

            if (filterCompanyId != 0)
            {
                information = information.Where(a => a.CompanyId == filterCompanyId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            RepairViewModel list = new RepairViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);
            list.InformationRepairViewModels = information.OrderByDescending(u => u.ReceivedUnitDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public RepairViewModel GetDoneRepairs(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "",
            int filterCustomerId = 0, int filterUnitId = 0, int filterCompanyId = 0, string filterCustomerMobile = "")
        {
            var date = DateTime.Now;
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                date = Convert.ToDateTime(estimatedTime).Date;
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IEnumerable<InformationRepairViewModel> information = ShowInformationDoneRepair();

            if (!string.IsNullOrEmpty(filterCustomerMobile))
            {
                information = information.Where(a => a.CustomerMobile.Contains(filterCustomerMobile));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                information = information.Where(r => r.SendUnitDate.Date == date);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.SendUnitDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.SendUnitDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.SendUnitDate.Date >= fDate && r.SendUnitDate.Date <= tDate);
            }

            if (filterCustomerId != 0)
            {
                information = information.Where(a => a.CustomerId == filterCustomerId);
            }

            if (filterCompanyId != 0)
            {
                information = information.Where(a => a.CompanyId == filterCompanyId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            RepairViewModel list = new RepairViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);
            list.InformationRepairViewModels = information.OrderByDescending(u => u.RepairDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public RepairViewModel GetDeniedRepairs(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "",
            int filterCustomerId = 0, int filterUnitId = 0, int filterCompanyId = 0, string filterDamageDesc = "")
        {
            var date = DateTime.Now;
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                date = Convert.ToDateTime(estimatedTime).Date;
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IEnumerable<InformationRepairViewModel> information = ShowInformationDeniedRepairs();

            if (!string.IsNullOrEmpty(filterDamageDesc))
            {
                information = information.Where(a => a.DamageDescription.Contains(filterDamageDesc));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                information = information.Where(r => r.SendUnitDate.Date == date);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.SendUnitDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.SendUnitDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.SendUnitDate.Date >= fDate && r.SendUnitDate.Date <= tDate);
            }

            if (filterCustomerId != 0)
            {
                information = information.Where(a => a.CustomerId == filterCustomerId);
            }

            if (filterCompanyId != 0)
            {
                information = information.Where(a => a.CompanyId == filterCompanyId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            RepairViewModel list = new RepairViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);
            list.InformationRepairViewModels = information.OrderByDescending(u => u.RepairDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public RepairViewModel GetRepairedRepairs(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "",
            int filterCustomerId = 0, int filterUnitId = 0, int filterCompanyId = 0, string filterCustomerMobile = "")
        {
            var date = DateTime.Now;
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                date = Convert.ToDateTime(estimatedTime).Date;
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IEnumerable<InformationRepairViewModel> information = ShowInformationRepairedRepair();

            if (!string.IsNullOrEmpty(filterCustomerMobile))
            {
                information = information.Where(a => a.CustomerMobile.Contains(filterCustomerMobile));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                information = information.Where(r => r.EstimatedToSendUnitDate.Date == date);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.RepairDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.RepairDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.RepairDate.Date >= fDate && r.RepairDate.Date <= tDate);
            }

            if (filterCustomerId != 0)
            {
                information = information.Where(a => a.CustomerId == filterCustomerId);
            }

            if (filterCompanyId != 0)
            {
                information = information.Where(a => a.CompanyId == filterCompanyId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            RepairViewModel list = new RepairViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);
            list.InformationRepairViewModels = information.OrderByDescending(u => u.RepairDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public RepairViewModel GetDeletedRepair(int pageId = 1, string estimatedTime = "", int filterCustomerId = 0,
            int filterUnitId = 0, int filterCompanyId = 0, string filterCustomerMobile = "")
        {
            IEnumerable<InformationRepairViewModel> information = ShowInformationDeletedRepair();

            if (!string.IsNullOrEmpty(filterCustomerMobile))
            {
                information = information.Where(a => a.CustomerMobile.Contains(filterCustomerMobile));
            }

            if (!string.IsNullOrEmpty(estimatedTime))
            {
                information = information.Where(r => r.SendUnitDate.ToString("d") == estimatedTime);
            }
            
            if (filterCustomerId != 0)
            {
                information = information.Where(a => a.CustomerId == filterCustomerId);
            }

            if (filterCompanyId != 0)
            {
                information = information.Where(a => a.CompanyId == filterCompanyId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            RepairViewModel list = new RepairViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);
            list.InformationRepairViewModels = information.OrderByDescending(u => u.ReceivedUnitDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public RepairViewModel GetCustomersRepair(int customerId, int pageId = 1, string fromDate = "", string toDate = "")
        {
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IEnumerable<InformationRepairViewModel> result = ShowCustomersRepair(customerId);

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                result = result.Where(r => r.SendUnitDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                result = result.Where(r => r.SendUnitDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                result = result.Where(r => r.SendUnitDate.Date >= fDate && r.SendUnitDate.Date <= tDate);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            RepairViewModel list = new RepairViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.InformationRepairViewModels = result.OrderBy(u => u.SendUnitDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public List<InformationRepairViewModel> ShowCustomersRepair(int customerId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationRepairViewModel>("ShowCustomersRepair", new { customerId = customerId }, commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public List<InformationRepairViewModel> ShowInformationRepair()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationRepairViewModel>("ShowInformationRepair", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public List<InformationRepairViewModel> ShowInformationDoneRepair()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationRepairViewModel>("ShowInformationDoneRepair", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public List<InformationRepairViewModel> ShowInformationDeniedRepairs()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationRepairViewModel>("ShowInformationDeniedRepairs", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public List<InformationRepairViewModel> ShowInformationRepairedRepair()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationRepairViewModel>("ShowInformationRepairedRepair", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public List<InformationRepairViewModel> ShowInformationDeletedRepair()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationRepairViewModel>("ShowInformationDeletedRepair", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public InformationRepairViewModel ShowInformationRepairById(int repairId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationRepairViewModel>("ShowInformationRepairById", new { repairId = repairId }, commandType: CommandType.StoredProcedure).Single();

                return Show;
            }
        }

        public Repair GetDataForEditRepair(int repairId)
        {
            return _context.Repairs.Where(r => r.RepairId == repairId).Select(r => new Repair()
            {
                RepairId = repairId,
                CustomerId = r.CustomerId,
                CompanyId = r.CompanyId,
                ReceivedUnitDate = r.ReceivedUnitDate,
                EstimatedToSendUnitDate = r.EstimatedToSendUnitDate,
                EstimatedAmount = r.EstimatedAmount,
                DamageDescription = r.DamageDescription,
                UnitStatusId = r.UnitStatusId,
                RepairDate = r.RepairDate,
                SendUnitDate = r.SendUnitDate,
                Discount = r.Discount,
                FinalAmount = r.FinalAmount,
                TotalCost = r.TotalCost,
                ReceivedAmount = r.ReceivedAmount,
                RemainingAmount = r.RemainingAmount,
                DoneDescription = r.DoneDescription,
                UnitName = r.UnitName,
                ConfirmationStatusId = r.ConfirmationStatusId,
                IsReady = r.IsReady,
                IsRepair = r.IsRepair,
                IsSend = r.IsSend
            }).Single();
        }

        public Repair GetRepairById(int repairId)
        {
            return _context.Repairs.Find(repairId);
        }

        public void UpdateRepair(Repair repair)
        {
            _context.Repairs.Update(repair);
            _context.SaveChanges();
        }
    }
}
