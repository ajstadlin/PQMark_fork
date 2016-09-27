using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSF.Data.Model;

namespace PQMark.Models
{
    public class VoltageBin
    {
        [PrimaryKey(true)]
        public int ID { get; set; }
        public string Label { get; set; }
        public float Max { get; set; }
        public float Min { get; set; }
        public int LoadOrder { get; set; }
    }
}