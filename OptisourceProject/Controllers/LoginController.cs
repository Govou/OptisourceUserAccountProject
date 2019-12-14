using Microsoft.AspNet.Identity;
using OptisourceProject.WebApi.Helpers;
using OptisourceProject.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OptisourceProject.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        [Route("api/Login")]
        public IHttpActionResult Post([FromBody]Login model)
        {
            LoginResponse loginResponse = new LoginResponse();
            var rndNum = new Random().Next(999999999);
            var login = new Login
            {
                RequestId = rndNum.ToString(),
                Password = Encryptor.EncryptAesManaged(model.Password),
                TimeStamp = DateTime.Now,
                Email = model.Email,
            };
            Register reg = new Register();
            
            
         
            // var hashedPassword = new PasswordHasher().HashPassword(model.Password); 
            var hashedPassword = Encryptor.EncryptAesManaged(model.Password);
            Audit audit = new Audit
            {
                Activity = "Login",
                RequestId = rndNum.ToString(),
                UserHostName = GetComputerDetails.GetHostName(),
                UserIPAddress = GetComputerDetails.GetIPAddress()
            };

            if (!ModelState.IsValid)
            {
                loginResponse.StatusCode = "03";
                loginResponse.StatusResponse = "Invalid model";
                return BadRequest(ModelState);
            }

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                reg = db.Registers.FirstOrDefault(x => x.Email == model.Email && x.Password == hashedPassword);

                if (reg != null)
                {
                    audit.Success = true;
                    audit.Comment = "Success";
                    loginResponse.StatusCode = "00";
                    loginResponse.StatusResponse = "Found";
                    loginResponse.Username = model.Email;
                    loginResponse.Name = reg.FirstName + " " + reg.LastName;
                    login.Status = "Success";
                }
                else
                {
                    loginResponse.StatusCode = "02";
                    audit.Comment = "Wrong email and password combination";
                    loginResponse.StatusResponse = "Wrong email and password combination";
                    login.Status = "Failed";
                }
                audit.TimeStamp = DateTime.Now;

                db.Logins.Add(login);
                db.Audits.Add(audit);
                db.SaveChanges();
            }

            return Ok(loginResponse);
        }
    }
}
