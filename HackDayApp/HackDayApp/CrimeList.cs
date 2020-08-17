using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackDayApp
{
    public class CrimeList
    {
        public string centralLatitude { get; set; }
        public string centralLongitude { get; set; }
        public List<Crime> crimes;
    }
}
