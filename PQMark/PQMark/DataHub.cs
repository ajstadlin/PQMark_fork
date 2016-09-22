using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PQMark
{
    public class DataHub: Hub
    {
        public string Hello()
        {
            return "hi";
        }
    }
}