using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorFromScratch.Shared
{
    public class CountryMapping
    {
        public int CountryMappingId { get; set; }
        public int Revision { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int SubRegionId { get; set; }
    }
}
