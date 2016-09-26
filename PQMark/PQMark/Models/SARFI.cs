using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSF.Data.Model;

namespace PQMark.Models
{
    public class SARFI
    {
        [PrimaryKey(true)]
        public int ID { get; set; }
        public int IndexID { get; set; }
        public int SiteID { get; set; }
        public float Count { get; set; } 

    }
}