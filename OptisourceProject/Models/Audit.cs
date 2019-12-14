using OptisourceProject.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptisourceProject.WebApi.Models
{
    public class Audit
    {


        public int Id { get; set; }
        public string UserIPAddress { get; set; }
        public string UserHostName { get; set;  }
        public string Activity { get; set; }
        public bool Success { get; set; }
        // public DateTime TimeStamp { get { return timeStamp; } private set { value = DateTime.Now; timeStamp = value; } }
        public DateTime TimeStamp { get; set; }
        public string Comment { get; set; }
        public string RequestId { get; set; }
    }
}