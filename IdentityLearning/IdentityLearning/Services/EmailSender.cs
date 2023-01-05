using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IdentityLearning.Services
{
	public class EmailSender : IEmailSender
	{
		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var fromEmail = "yourEmail";
			var pass = "yourpassword";
			var message = new MailMessage();
			message.From=new MailAddress(fromEmail);
			message.Subject = subject;
			message.To.Add(email);
			message.Body =$"<html><body>{htmlMessage}</body></html>" ;
			message.IsBodyHtml = true;

			var Smtp = new SmtpClient("smtp-mail.outlook.com")
			{
				Port = 587,
				Credentials = new NetworkCredential(fromEmail, pass),
				EnableSsl=true
				
			};
			Smtp.Send(message);

			
		}
	}
}
