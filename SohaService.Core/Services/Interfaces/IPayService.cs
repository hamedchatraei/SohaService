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
        int GetSumAmountPay(int orderId);
        PayViewModel GetPays(int pageId=1,int filterCustomerId=0,string filterPayDate="",string fromDate="",string toDate="");
        PayViewModel GetPayByCustomerId(int customerId, int pageId = 1, string fromDate = "", string toDate = "");
        List<InformationPayViewModel> ShowPays();
        List<InformationPayViewModel> ShowPayByCustomerId(int customerId);
        void UpdatePay(Pay pay);
    }
}
