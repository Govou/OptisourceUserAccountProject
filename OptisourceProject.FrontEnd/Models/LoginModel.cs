using OptisourceProject.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace OptisourceProject.FrontEnd.Models
{
    public class LoginModel: IValidatableObject
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        public string ErrorMessage { get; set; }
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ValidationResult vr;
            ServiceResponse serviceResponse = new ServiceResponse();
            var login = new LoginModel();
            login.Password = Password;
            login.Email = Email;

            try
            {
                serviceResponse = LoginService.Post(login);
            }
            catch (Exception ex)
            {
                serviceResponse.StatusCode = "09";
                serviceResponse.StatusResponse = ex.Message;
            }


            if (serviceResponse.StatusCode == "00")
            {
                Name = serviceResponse.Name;
                vr = ValidationResult.Success;
            }
         

            else
            {
                vr = new ValidationResult(serviceResponse.StatusResponse);
                
            }

            ErrorMessage = serviceResponse.StatusResponse;
            return new List<ValidationResult>() { vr };

        }
    }
}