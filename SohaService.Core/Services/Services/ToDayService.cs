using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.Core.Services.Interfaces;
using SohaService.DataLayer.Context;
using SohaService.DataLayer.Entities.Today;

namespace SohaService.Core.Services.Services
{
    public class ToDayService : IToDayService
    {
        private SohaServiceContext _context;

        public ToDayService(SohaServiceContext context)
        {
            _context = context;
        }


        public void EditToDay(string toDay)
        {
            ToDay editToDay = _context.ToDays.Find(1);
            editToDay.ToDayTitle = toDay;
            _context.ToDays.Update(editToDay);
            _context.SaveChanges();
        }

        public ToDay GetToDay()
        {
            return _context.ToDays.FirstOrDefault();
        }
    }
}
