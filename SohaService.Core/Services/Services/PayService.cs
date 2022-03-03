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
using SohaService.Core.DTOs.Pay;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Context;
using SohaService.DataLayer.Entities.Orders;
using SohaService.DataLayer.Entities.Pay;
using SohaService.DataLayer.Entities.Repair;

namespace SohaService.Core.Services.Services
{
    public class PayService : IPayService
    {
        private SohaServiceContext _context;
        private IConfiguration _configuration;

        public PayService(SohaServiceContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public int AddPay(Pay pay)
        {
            _context.Pay.Add(pay);
            _context.SaveChanges();
            return pay.PayId;
        }

        public Pay GetPayById(int payId)
        {
            return _context.Pay.Find(payId);
        }

        public Pay GetFirstPayByOrderId(int orderId)
        {
            return _context.Pay.First(p => p.OrderId == orderId);
        }

        public Pay GetFirstPayByRepairId(int repairId)
        {
            return _context.Pay.First(p => p.RepairId == repairId);
        }

        public int GetSumAmountPay(int orderId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@orderID", orderId);
                p.Add("@sumAmount", "", DbType.Int32, direction: ParameterDirection.Output);

                db.Query<Pay>("GetSumAmountPay", p, commandType: CommandType.StoredProcedure);

                var sumAmount = p.Get<int>("@sumAmount");

                return sumAmount;
            }
        }

        public int GetSumAmountRepairPay(int repairId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@repairId", repairId);
                p.Add("@sumAmount", "", DbType.Int32, direction: ParameterDirection.Output);

                db.Query<Pay>("GetSumAmountRepairPay", p, commandType: CommandType.StoredProcedure);

                var sumAmount = p.Get<int>("@sumAmount");

                return sumAmount;
            }
        }

        public PayViewModel GetPays(int pageId = 1, int filterCustomerId = 0, string filterPayDate = "", string fromDate = "",
            string toDate = "")
        {
            var date = DateTime.Now;
            var fDate = DateTime.Now;
            var tDate = DateTime.Now;

            if (!string.IsNullOrEmpty(filterPayDate))
            {
                date = Convert.ToDateTime(filterPayDate).Date;
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                fDate = Convert.ToDateTime(fromDate).Date;
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                tDate = Convert.ToDateTime(toDate).Date;
            }

            IEnumerable<InformationPayViewModel> information = ShowPays();

            if (!string.IsNullOrEmpty(filterPayDate))
            {
                information = information.Where(r => r.OrderChangeLevelDate.Date == date);
            }

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.PayDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.PayDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.PayDate.Date >= fDate && r.PayDate.Date <= tDate);
            }

            if (filterCustomerId != 0)
            {
                information = information.Where(a => a.OrderCustomerId == filterCustomerId || a.RepairCustomerId == filterCustomerId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            PayViewModel list = new PayViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)information.Count() / take);

            list.StartPage = (pageId - 2 <= 0) ? 1 : pageId - 2;
            list.EndPage = (pageId + 9 > list.PageCount) ? list.PageCount : pageId + 9;

            list.InformationPayViewModels = information.OrderByDescending(u => u.PayDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public PayViewModel GetPaysForPrint(string fromDate = "", string toDate = "", int filterCustomerId = 0)
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

            IEnumerable<InformationPayViewModel> information = ShowPays();
            

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.PayDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                information = information.Where(r => r.PayDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                information = information.Where(r => r.PayDate.Date >= fDate && r.PayDate.Date <= tDate);
            }

            if (filterCustomerId != 0)
            {
                information = information.Where(a => a.OrderCustomerId == filterCustomerId || a.RepairCustomerId == filterCustomerId);
            }

            PayViewModel list = new PayViewModel();
            list.InformationPayViewModels = information.OrderByDescending(u => u.PayDate).ToList();

            return list;
        }

        public PayViewModel GetPayByCustomerId(int customerId, int pageId = 1, string fromDate = "", string toDate = "")
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
            
            IEnumerable<InformationPayViewModel> result = ShowPayByCustomerId(customerId);

            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                result = result.Where(r => r.PayDate.Date >= fDate);
            }
            else if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                result = result.Where(r => r.PayDate.Date <= tDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                result = result.Where(r => r.PayDate.Date >= fDate && r.PayDate.Date <= tDate);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            PayViewModel list = new PayViewModel();
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling((decimal)result.Count() / take);
            list.InformationPayViewModels = result.OrderBy(u => u.PayDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public List<InformationPayViewModel> ShowPays()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationPayViewModel>("ShowPays", commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public List<InformationPayViewModel> ShowPayByCustomerId(int customerId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query<InformationPayViewModel>("ShowPayByCustomerId",new {customerId=customerId}, commandType: CommandType.StoredProcedure).ToList();

                return Show;
            }
        }

        public void EditPay(Pay pay)
        {
            Pay editPay = GetPayById(pay.PayId);
            editPay.Amount = pay.Amount;
            editPay.PayDate = pay.PayDate;
            UpdatePay(editPay);
        }

        public void DeletePay(int payId)
        {
            Pay pay = GetPayById(payId);

            _context.Pay.Remove(pay);
            _context.SaveChanges();
        }

        public void UpdatePay(Pay pay)
        {
            _context.Pay.Update(pay);
            _context.SaveChanges();
        }

        public Pay GetDataForEditPay(int payId)
        {
            return _context.Pay.Where(p => p.PayId == payId).Select(p => new Pay()
            {
                PayId = payId,
                OrderId = p.OrderId,
                RepairId = p.RepairId,
                Amount = p.Amount,
                PayDate = p.PayDate
            }).Single();
        }
    }
}
