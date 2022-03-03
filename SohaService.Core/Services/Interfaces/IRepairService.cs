using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.Core.DTOs.Repair;
using SohaService.DataLayer.Entities.Repair;

namespace SohaService.Core.Services.Interfaces
{
    public interface IRepairService
    {
        int AddRepair(Repair repair);
        void DeleteRepair(int repairId);
        void EditRepair(Repair repair);
        void EditDoneRepair(Repair repair);
        RepairViewModel GetRepairs(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int filterCustomerId = 0,
            int filterUnitId = 0, int filterCompanyId = 0, string filterCustomerMobile = "");
        RepairViewModel GetDoneRepairs(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int filterCustomerId = 0,
            int filterUnitId = 0, int filterCompanyId = 0, string filterCustomerMobile = "");
        RepairViewModel GetDeniedRepairs(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int filterCustomerId = 0,
            int filterUnitId = 0, int filterCompanyId = 0, string filterDamageDesc = "");
        RepairViewModel GetRepairedRepairs(int pageId = 1, string estimatedTime = "", string fromDate = "", string toDate = "", int filterCustomerId = 0,
            int filterUnitId = 0, int filterCompanyId = 0, string filterCustomerMobile = "");
        RepairViewModel GetDeletedRepair(int pageId = 1, string estimatedTime = "", int filterCustomerId = 0,
            int filterUnitId = 0, int filterCompanyId = 0, string filterCustomerMobile = "");
        RepairViewModel GetCustomersRepair(int customerId, int pageId = 1, string fromDate = "", string toDate = "");
        List<InformationRepairViewModel> ShowInformationRepair();
        List<InformationRepairViewModel> ShowInformationDoneRepair();
        List<InformationRepairViewModel> ShowInformationDeniedRepairs();
        List<InformationRepairViewModel> ShowInformationRepairedRepair();
        List<InformationRepairViewModel> ShowInformationDeletedRepair();
        InformationRepairViewModel ShowInformationRepairById(int repairId);
        List<InformationRepairViewModel> ShowCustomersRepair(int customerId);
        Repair GetDataForEditRepair(int repairId);
        Repair GetRepairById(int repairId);
        void UpdateRepair(Repair repair);
    }
}
