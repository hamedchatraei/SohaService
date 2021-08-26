using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SohaService.Core.DTOs.Expert;
using SohaService.DataLayer.Entities.Expert;

namespace SohaService.Core.Services.Interfaces
{
    public interface IExpertService
    {
        int AddExpert(Expert expert);
        void DeleteExpert(int expertId);
        void EditExpert(Expert expert);
        ExpertViewModel GetExperts(int pageId = 1, string filterFamily = "", string filterMobile = "");
        ExpertViewModel GetDeletedExperts(int pageId = 1, string filterFamily = "", string filterMobile = "");
        Expert GetDataForEditExpert(int expertId);
        Expert GetExpertById(int expertId);
        void UpdateExpert(Expert expert);
        List<SelectListItem> GetExpertListItem();

    }
}
