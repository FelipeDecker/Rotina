using Rotina.DomainService.IServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Rotina.Service.Services
{
    public class MessageService : IMessageService
    {
        public async Task<bool> SendEmail()
        {
            try
            {
                SmtpClient smtpClient = new();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("deckerfelipe2@gmail.com", "wenerktoyvopktdw");
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new();
                mailMessage.From = new MailAddress("deckerfelipe2@gmail.com");
                mailMessage.Subject = "Rotina";
                mailMessage.Body = "Erro grave";
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add("felipe-decker@hotmail.com");

                await smtpClient.SendMailAsync(mailMessage);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<bool> SendSms()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendWhatsApp()
        {
            throw new NotImplementedException();
        }
    }
}
