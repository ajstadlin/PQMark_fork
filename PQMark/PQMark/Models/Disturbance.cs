﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSF.Data.Model;

namespace PQMark.Models
{
    public class Disturbance
    {
        [PrimaryKey(true)]
        public int ID { get; set; }
        public int EventID { get; set; }
        public int PhaseID { get; set; }
        public float Magnitude { get; set; }
        public float PerUnitMagnitude { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public float DurationSeconds { get; set; }
        public float DurationCycles { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int SiteID { get; set; }
    }
}