using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SohaService.Core.DTOs.Expert;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Entities.Expert;

namespace SohaService.Web.Controllers
{
    public class ExpertController : Controller
    {
        private IExpertService _expertService;

        public ExpertController(IExpertService expertService)
        {
            _expertService = expertService;
        }

        #region Experts

        [Route("Experts")]
        public IActionResult Experts(int pageId = 1, string filterFamily = "", string filterMobile = "")
        {
            ExpertViewModel expert = _expertService.GetExperts(pageId, filterFamily, filterMobile);

            return View(expert);
        }

        #endregion

        #region DeletedExperts

        [Route("DeletedExperts")]
        public IActionResult DeletedExperts(int pageId = 1, string filterFamily = "", string filterMobile = "")
        {
            ExpertViewModel expert = _expertService.GetDeletedExperts(pageId, filterFamily, filterMobile);

            return View(expert);
        }

        #endregion

        #region InformationExpert

        [Route("InformationExpert/{id}")]
        public IActionResult InformationExpert(int id)
        {
            Expert expert = _expertService.GetExpertById(id);

            return View(expert);
        }

        #endregion

        #region AddExpert

        [Route("AddExpert")]
        public IActionResult AddExpert()
        {
            return View();
        }

        [HttpPost]
        [Route("AddExpert")]
        public IActionResult AddExpert(Expert expert)
        {
            if (!ModelState.IsValid)
                return View(expert);

            _expertService.AddExpert(expert);

            int expertId = expert.ExpertId;

            return Redirect($"/InformationExpert/{expertId}");
        }

        #endregion

        #region EditExpert

        [Route("EditExpert/{id}")]
        public IActionResult EditExpert(int id)
        {
            Expert editExpert = _expertService.GetDataForEditExpert(id);

            return View(editExpert);
        }

        [HttpPost]
        [Route("EditExpert/{id}")]
        public IActionResult EditExpert(Expert expert)
        {
            if (!ModelState.IsValid)
                return View(expert);

            _expertService.EditExpert(expert);

            int expertId = expert.ExpertId;

            return Redirect($"/InformationExpert/{expertId}");
        }

        #endregion

        #region DeleteExpert

        [Route("DeleteExpert/{id}")]
        public IActionResult DeleteExpert(int id)
        {
            Expert expert = _expertService.GetExpertById(id);

            return View(expert);
        }

        [HttpPost]
        [Route("DeleteExpert/{id}")]
        public IActionResult DeleteExpert(Expert expert)
        {
            _expertService.DeleteExpert(expert.ExpertId);

            return Redirect("/Experts");
        }

        #endregion
    }
}
