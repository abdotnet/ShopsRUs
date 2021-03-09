using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Api.Helpers
{
    public class ExceptionHelper
    {
    }
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException(string message) : base(message)
        {

        }
    }
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
    public class NotActiveException : Exception
    {
        public NotActiveException(string message) : base(message)
        {

        }
    }
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }

    }
    public class VerificationCodeException : Exception
    {
        public VerificationCodeException(string message) : base(message)
        {

        }
    }
    public class PasswordException : Exception
    {
        public PasswordException(string message) : base(message)
        {

        }
    }
    public class SessionExpiredException : Exception
    {
        public SessionExpiredException(string message) : base(message)
        {

        }
    }
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ModelValidationException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ModelValidationException(string message) : base(message)
        {

        }
    }
}
