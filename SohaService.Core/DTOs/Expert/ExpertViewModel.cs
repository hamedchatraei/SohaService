using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SohaService.Core.DTOs.Expert
{
    public class ExpertViewModel
    {
        public List<DataLayer.Entities.Expert.Expert> Experts { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
