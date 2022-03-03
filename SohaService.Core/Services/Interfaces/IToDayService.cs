using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.DataLayer.Entities.Today;

namespace SohaService.Core.Services.Interfaces
{
    public interface IToDayService
    {
        void EditToDay(string toDay);
        ToDay GetToDay();

    }
}
