using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using SohaService.Core.Services.Interfaces;

namespace SohaService.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IBackupService _backupService;
        private IWebHostEnvironment _hostingEnvironment;

        public HomeController(IBackupService backupService, IWebHostEnvironment hostingEnvironment)
        {
            _backupService = backupService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("BackupDB")]
        public IActionResult BackupDB()
        {
            return View();
        }

        [HttpPost]
        [Route("BackupDB")]
        public IActionResult BackupDB(string name,string path)
        {
            name = "SohaService_DB";
            path = path + "\\";
            //path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot" , "backup");

            _backupService.Backup(name,path);

            return Redirect("/");
        }
    }
}
