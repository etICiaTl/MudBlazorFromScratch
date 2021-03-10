using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorFromScratch.Shared
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryAbbr2 { get; set; }
        public string CountryAbbr3 { get; set; }
        public int CountryCodeISO { get; set; }
    }
}
