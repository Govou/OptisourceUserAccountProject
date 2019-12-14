using Microsoft.AspNet.Identity;
using OptisourceProject.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OptisourceProject.WebApi.Models
{
    public class Login
    {
      

        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime TimeStamp { get; set; }
  
        [Required]
        public string Password { get; set; }
       
        public string RequestId { get; set; }
        public string Status { get; set; }
    }
}