using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERP.Common.Constants
{
    public static class GlobalExceptionHandler
    {
        public static string HandleException(Exception ex)
        {
            Logger.LogError(ex);
            return "An unexpected error occurred. Please contact support.";
        }
    }
}
