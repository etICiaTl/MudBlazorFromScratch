using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorFromScratch.Shared
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public string Country { get; set; }
        public string Status { get; set; }
    }
}
