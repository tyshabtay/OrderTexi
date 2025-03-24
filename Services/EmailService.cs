using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace OrderTexi.Services
{
    public class EmailService
    {
        public static bool IsValidEmail(string email)
        {
            var emailAddress = new EmailAddressAttribute();
            return emailAddress.IsValid(email);
        }
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8 || password.Length > 10)
                return false;
            if (!Regex.IsMatch(password, @"[a-z]") && !Regex.IsMatch(password, @"[A-Z]")) return false; // לפחות תו אלפביתי קטן או גדול
            if (!Regex.IsMatch(password, @"[0-9]")) return false; // לפחות תו מספרי
            return true;
        }

        public static void SendEmail(  string email= "tyshabtay@gmail.com" ,string  to= "estyshabtay@gmail.com")
        {
            //SmtpClient client = new SmtpClient("smtp.example.com", 587); // או 465 בהתאם לשרת
            //client.EnableSsl = true; // הפעלת SSL
            var fromAddress = new MailAddress(email);
            var toAddress = new MailAddress(to);
            const string fromPassword = "thanrkh5678";
          
            var smtp = new SmtpClient
            {
                //STARTTLS
                Host = "smtp.gmail.com", // לדוגמה: smtp.gmail.comstring subject , string body ,
                Port = 587,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                  Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword)
               //System.Net.Mail.MailCommand()
            };    

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "איפוס סיסמא subject",
                Body = "שלום וברכה " +
                "שלחנו לכם קישור לאיפוס סיסמא"
            })
            {
               
                smtp.Send(message);
            }
        }
    }

}

