using Habaripay.ShopsRUs.Api.Helpers;
using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Api.Middleware
{
    public static class ExceptionHandler
    {
        public static string Get(this HttpContext context, Exception ex)
        {
            var responseModel = new ApiResponse<object>();

            try
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;

                if (ex.GetType() == typeof(SecurityTokenValidationException))
                {
                    responseModel.Message = "Invalid token";
                    responseModel.Status = AppStatusCode.InvalidToken;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(SecurityTokenInvalidIssuerException))
                {
                    responseModel.Message = "Invalid issuer";
                    responseModel.Status = AppStatusCode.InvalidIssuer;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(SecurityTokenExpiredException))
                {
                    responseModel.Message = "Token expired";
                    responseModel.Status = AppStatusCode.TokenExpired;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(ModelValidationException))
                {
                    ModelValidationException? error = ex as ModelValidationException;
                    responseModel.Status = AppStatusCode.ModelValidation;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(ArgumentNullException))
                {
                    ModelValidationException error = ex as ModelValidationException;
                    responseModel.Status = AppStatusCode.ModelValidation;
                    responseModel.Message = "Parameter passed is incorrect.";
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(AlreadyExistException))
                {
                    responseModel.Status = AppStatusCode.AlreadyExist;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(NotFoundException))
                {
                    responseModel.Status = AppStatusCode.NotFound;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }
                else if (ex.GetType() == typeof(NotActiveException))
                {
                    responseModel.Status = AppStatusCode.NotActive;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(BadRequestException))
                {
                    responseModel.Status = AppStatusCode.BadRequest;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(VerificationCodeException))
                {
                    responseModel.Status = AppStatusCode.VerificationCode;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(PasswordException))
                {
                    responseModel.Status = AppStatusCode.PasswordError;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(SessionExpiredException))
                {
                    responseModel.Status = AppStatusCode.SessionExpired;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(InvalidOperationException))
                {
                    responseModel.Status = AppStatusCode.InvalidOperation;
                    responseModel.Message = ex.Message; // "Invalid Request";
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                }
                else if (ex.GetType() == typeof(LoginException))
                {
                    responseModel.Status = AppStatusCode.LoginOperation;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    responseModel.Status = AppStatusCode.GenericError;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                return JsonConvert.SerializeObject(responseModel);
            }
            catch (Exception _ex)
            {
                responseModel.Status = AppStatusCode.GenericError;
                responseModel.Message = _ex.Message != null ? _ex.Message : "Please contact the administrator";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return JsonConvert.SerializeObject(responseModel);
            }
        }
    }
}
