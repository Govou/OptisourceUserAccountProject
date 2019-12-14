using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptisourceProject.WebApi.Models
{
    public class LoginResponse
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string StatusCode { get; set; }
        public string StatusResponse { get; set; }
    }
}