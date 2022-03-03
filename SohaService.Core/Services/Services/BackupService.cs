using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SohaService.Core.Services.Interfaces;

namespace SohaService.Core.Services.Services
{
    public class BackupService: IBackupService
    {
        private IConfiguration _configuration;

        public BackupService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Backup(string name,string path)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SohaConnection")))
            {
                var Show = db.Query("backupSoha", new {name=name, path = path }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
