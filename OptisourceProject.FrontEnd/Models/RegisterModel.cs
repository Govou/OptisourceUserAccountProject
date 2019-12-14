using OptisourceProject.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OptisourceProject.FrontEnd.Models
{
    public class RegisterModel :IValidatableObject
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public string Name { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ValidationResult vr;
            ServiceResponse serviceResponse = new ServiceResponse();
            var register = new RegisterModel();
            register.Password = Password;
            register.UserName = UserName;
            register.Email = Email;
            register.FirstName = FirstName;
            register.LastName = LastName;
            

            try
            {
                
                serviceResponse = RegisterService.Post(register);
            }
            catch (Exception ex)
            {
                serviceResponse.StatusCode = "09";
                serviceResponse.StatusResponse = ex.Message;
            }


            if (serviceResponse.StatusCode == "00")
            {
                vr = ValidationResult.Success;
                Name = serviceResponse.Name;
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