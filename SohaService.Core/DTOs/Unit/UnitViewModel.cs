using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SohaService.DataLayer.Entities.Unit;

namespace SohaService.Core.DTOs.Unit
{
    public class UnitViewModel
    {
        public List<DataLayer.Entities.Unit.Unit> Units { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class UnitStatusViewModel
    {
        public List<UnitStatus> UnitStatus { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
