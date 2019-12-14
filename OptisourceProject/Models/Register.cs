using Microsoft.AspNet.Identity;
using OptisourceProject.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OptisourceProject.WebApi.Models
{
    public class Register
    {

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }
     
        public DateTime TimeStamp { get; set; }
       // public string Address { get; set; }
        [Required]
        public string Password { get; set; }
        
        public string RequestId { get; set; }
    }
}