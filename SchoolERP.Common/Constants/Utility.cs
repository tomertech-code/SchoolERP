using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
