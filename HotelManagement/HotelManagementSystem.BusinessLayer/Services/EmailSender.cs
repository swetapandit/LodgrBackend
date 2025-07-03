using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using HotelManagementSystem.BusinessLayer.Interface;

namespace HotelManagementSystem.BusinessLayer.Services
{
    public class EmailSender : IEmailSender
    {
        // enter your email credentials
        public EmailSender()
        {
        }
       public Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_email, _password)
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_email),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(email);

                return client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., logging it
                throw new InvalidOperationException("Failed to send email.", ex);
            }
        }
    }
}
