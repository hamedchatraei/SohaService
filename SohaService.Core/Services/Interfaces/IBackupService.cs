using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SohaService.Core.Services.Interfaces
{
    public interface IBackupService
    {
        void Backup(string name,string path);
    }
}
