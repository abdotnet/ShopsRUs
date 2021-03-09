using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Domain.Helpers
{
    public class AppStatusCode
    {
        public static string Successful { get; set; } = "00";
        public static string BadRequest { get; set; } = "01";
        public static string Pending { get; set; } = "02";
        public static string InvalidIssuer { get; set; } = "03";
        public static string TokenExpired { get; set; } = "04";
        public static string ModelValidation { get; set; } = "05";
        public static string AlreadyExist { get; set; } = "06";
        public static string NotFound { get; set; } = "07";
        public static string NotActive { get; set; } = "08";
        public static string InvalidToken { get; set; } = "09";
        public static string VerificationCode { get; set; } = "11";
        public static string PasswordError { get; set; } = "12";
        public static string SessionExpired { get; set; } = "13";
        public static string InvalidOperation { get; set; } = "14";
        public static string LoginOperation { get; set; } = "15";
        public static string GenericError { get; set; } = "16";
    }
}
