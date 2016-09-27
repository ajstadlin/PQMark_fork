using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PQMark.Models
{
    public class PQVoltageEvent
    {
        public int DurationID { get; set; }
        public int VoltageBinID { get; set; }
        public int Count { get; set; }
    }
}