using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Context;
using SohaService.DataLayer.Entities.ApiKey;

namespace SohaService.Core.Services.Services
{
    public class SmsService : ISmsService
    {
        private SohaServiceContext _context;

        public SmsService(SohaServiceContext context)
        {
            _context = context;
        }

        public void EditApiKey(ApiKey apiKey)
        {
            ApiKey editApiKey = _context.ApiKeys.Find(1);
            editApiKey.SecurityCode = apiKey.SecurityCode;
            editApiKey.ApiKeyCode = apiKey.ApiKeyCode;
            _context.ApiKeys.Update(editApiKey);
            _context.SaveChanges();
        }

        public ApiKey ShowApiKey()
        {
            return _context.ApiKeys.Find(1);
        }
    }
}
