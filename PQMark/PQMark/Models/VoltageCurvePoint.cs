using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSF.Data.Model;

namespace PQMark.Models
{
    public class VoltageCurvePoint
    {
        [PrimaryKey(true)]
        public int ID { get; set; }
        public int VoltageCurveID { get; set; }
        public float PerUnitMagnitude { get; set; }
        public float DurationSeconds { get; set; }
        public int LoadOrder { get; set; }
    }
}