using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSF.Data.Model;

namespace PQMark.Models
{
    [TableName("Company")]
    public class Company
    {
        [PrimaryKey(true)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public bool Benchmark { get; set; }
    }
}