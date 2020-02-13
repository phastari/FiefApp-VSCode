using System.Collections.Generic;
using Application.Common.Models;

namespace Application.Fiefs.Queries.InitializeFief
{
    public class InitializeFiefVm
    {
        public List<ShortFief> Fiefs { get; set; }
        public List<ShortRoad> Roads { get; set; }
        public List<ShortInheritance> Inheritances { get; set; }
        public List<IndustryLookupDto> Industries { get; set; }
        public List<StewardLookupDto> Stewards { get; set; }
        public string FiefId { get; set; }
    }
}