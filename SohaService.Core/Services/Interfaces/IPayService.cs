using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.Core.DTOs.Pay;
using SohaService.DataLayer.Entities.Pay;

namespace SohaService.Core.Services.Interfaces
{
    public interface IPayService
    {
        int AddPay(Pay pay);
        void EditPay(Pay pay);
        void DeletePay(int payId);
        Pay GetDataForEditPay(int payId);
        Pay GetPayById(int payId);
        Pay GetFirstPayByOrderId(int orderId);
        Pay GetFirstPayByRepairId(int repairId);
        int GetSumAmountPay(int orderId);
        int GetSumAmountRepairPay(int repairId);
        PayViewModel GetPays(int pageId=1,int filterCustomerId=0,string filterPayDate="",string fromDate="",string toDate="");
        PayViewModel GetOrderPays(int pageId=1,int filterCustomerId=0,string filterPayDate="",string fromDate="",string toDate="");
        PayViewModel GetRepairPays(int pageId=1,int filterCustomerId=0,string filterPayDate="",string fromDate="",string toDate="");
        PayViewModel GetPaysForPrint(string fromDate = "", string toDate = "", int filterCustomerId = 0);
        PayViewModel GetOrderPaysForPrint(string fromDate = "", string toDate = "", int filterCustomerId = 0);
        PayViewModel GetRepairPaysForPrint(string fromDate = "", string toDate = "", int filterCustomerId = 0);
        PayViewModel GetPayByCustomerId(int customerId, int pageId = 1, string fromDate = "", string toDate = "");
        List<InformationPayViewModel> ShowPays();
        List<InformationPayViewModel> ShowPayByCustomerId(int customerId);
        void UpdatePay(Pay pay);
    }
}
