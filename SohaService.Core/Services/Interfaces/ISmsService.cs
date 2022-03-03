using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.DataLayer.Entities.ApiKey;

namespace SohaService.Core.Services.Interfaces
{
    public interface ISmsService
    {
        ApiKey ShowApiKey();
        void EditApiKey(ApiKey apiKey);
    }
}
