using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERP.Common.Constants
{
    public static class Utility
    {
        public static string GenerateUniqueId()
        {
            return Guid.NewGuid().ToString();
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString(AppConstants.DateFormat);
        }

        public static string GetCurrentDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static bool IsValidEmail(string email)
        {
            var emailValidator = new EmailAddressAttribute();
            return emailValidator.IsValid(email);
        }
        public static string ConvertToDateFormat(DateTime date, string format = "MM/dd/yyyy")
        {
            return date.ToString(format);
        }

        public static async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var fromEmail = "your-email@example.com";  // Configure your email
            var smtpClient = new SmtpClient("smtp.example.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("your-email@example.com", "your-email-password"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage(fromEmail, toEmail, subject, body);

            await smtpClient.SendMailAsync(mailMessage);
        }
        public static string GenerateRandomPassword(int length = 8)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                password.Append(validChars[random.Next(validChars.Length)]);
            }

            return password.ToString();
        }
    }
}
