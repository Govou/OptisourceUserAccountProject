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
    public class RegisterController : ApiController
    {
        [HttpPost]
        [Route("api/Register")]
        public IHttpActionResult Post([FromBody]Register model)
        {
            LoginResponse loginResponse = new LoginResponse();
            var rndNum = new Random().Next(999999999);
            var saved = 0;
            model.RequestId = rndNum.ToString();
          
            Audit audit = new Audit
            {
                Activity = "Register",
                TimeStamp = DateTime.Now,
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
               
              var regExist = db.Registers.Any(x => x.Email == model.Email);
                if (regExist)
                {
                    loginResponse.StatusCode = "08";
                    loginResponse.StatusResponse = "User already exist";
                    audit.Comment = "User already exist";
                   
                }

                else
                {
                    model.TimeStamp = DateTime.Now;
                    model.Password = Encryptor.EncryptAesManaged(model.Password);
                    db.Registers.Add(model);

                    try
                    {
                        saved = db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        audit.Comment = ex.Message;
                    }

                    if (saved > 0)
                    {
                        audit.Success = true;
                        audit.Comment = "Success";
                        loginResponse.StatusCode = "00";
                        loginResponse.StatusResponse = "Successful";
                        loginResponse.Username = model.UserName;
                        loginResponse.Name = model.FirstName + " " + model.LastName;
                    }
                    else
                    {
                        loginResponse.StatusCode = "04";
                        loginResponse.StatusResponse = "Failed";
                        audit.Comment = "Failed";
                    }
                }
               
                audit.TimeStamp = DateTime.Now;
                db.Audits.Add(audit);

                db.SaveChanges();
            }

            return Ok(loginResponse);
        }
    }
}
