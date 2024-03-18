using AutoMapper;
using EgeriaTaskBackend.Domain.Dto;
using EgeriaTaskBackend.Domain.RequsetPayloads;
using EgeriaTaskBackend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EgeriaTaskBackend.Business.EmailService
{
    public class EmailService :BaseService, IEmailService
    {
        private readonly EgeriaContext egeriaContext;
        const string fromEmail = "task.for.egeria@outlook.com";
        const string password = "EgeriaTask";
        const string subject = "Customer Order Information";
         string emailString;


       public EmailService(EgeriaContext egeriaContext)
        {
            this.egeriaContext = egeriaContext;
           
        }
        public async Task<bool> SendEmail(EmailPayload emailPayload)
        {
            var emailDto = await ConvertOrderInformationToString(emailPayload.Objkey);
            if(emailDto) {
                try
                {
                    var client = new SmtpClient("smtp-mail.outlook.com", 587)
                    {
                        EnableSsl = true,
                        Credentials = new NetworkCredential(fromEmail, password)
                    };
                    await client.SendMailAsync(
                        new MailMessage(
                             from: fromEmail,
                             to: emailPayload.Email,
                             subject,
                             emailString)
                        );
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A problem has existed while sending the email:" + ex.Message);
                    return false;
                }
            }
            return false;

        }

        public async Task<bool> ConvertOrderInformationToString(string orderObjkey)
        {
            var matchedOrder = await egeriaContext.Orders.FirstOrDefaultAsync(o => o.Objkey == orderObjkey);
            if (matchedOrder != null)
            {
                // Tarih ve saat bilgisini biçimlendirme
                string formattedDate = matchedOrder.DateEntered.ToString("yyyy-MM-dd HH:mm:ss");

                // Tüm bilgileri bir stringe dönüştürme
                 emailString = $"Your order information is given below;\nOrder date: {formattedDate}\nOrder State: {matchedOrder.State}\nOrder Objkey: {matchedOrder.Objkey}";

                return true;
            }
            return false;
           
        }
    }
}
