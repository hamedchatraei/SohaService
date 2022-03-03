using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SohaService.DataLayer.Entities.ApiKey
{
    public class ApiKey
    {
        public int ApiKeyId { get; set; }
        public string SecurityCode { get; set; }
        public string ApiKeyCode { get; set; }

    }
}
