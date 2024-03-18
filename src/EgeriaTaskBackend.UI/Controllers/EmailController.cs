using EgeriaTaskBackend.Business.EmailService;
using EgeriaTaskBackend.Domain.RequsetPayloads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgeriaTaskBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly  IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost("SendOrderInformation")]

        public async Task<IActionResult> SendOrderInformationToCustomerEmail([FromBody]EmailPayload emailPayload) { 
        
        var sendEmail=await emailService.SendEmail(emailPayload);
            if (sendEmail)
            {
                return Ok("Email has been sent successfully");
            }
            return NotFound("Failed to send email. Invalid email address.");
        }
    }
}
