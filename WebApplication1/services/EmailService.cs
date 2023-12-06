using System.Net;
using System.Net.Mail;
using WebApplication1.data.dto.request;

namespace WebApplication1.services;

public class EmailService
{
    public void SendRegistrationEmail(EmailNotificationRequest emailNotificationRequest)
    {

        string fromAddress = "a.daniel@native.semicolon.africa";


        using (var message = new MailMessage(fromAddress,emailNotificationRequest.Recipients))
        {
         
            message.Subject = "Welcome to Your App!";
            message.Body = emailNotificationRequest.Text;

            using (var smtpClient = new SmtpClient("smtp.elasticemail.com"))
            {
                smtpClient.Credentials = new NetworkCredential("a.daniel@native.semicolon.africa",
                    "AA9062FE5F06A9629FA1CEDFEB32A33F9570");
                smtpClient.Port = 2525;
                smtpClient.EnableSsl = true;

                smtpClient.Send(message);
            }
        }
    }


}

    
 
