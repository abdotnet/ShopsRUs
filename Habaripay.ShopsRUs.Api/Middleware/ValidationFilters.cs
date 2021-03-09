using Habaripay.ShopsRUs.Domain.Contracts;
using Habaripay.ShopsRUs.Domain.Helpers;
using Habaripay.ShopsRUs.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Api.Middleware
{
    public class ValidationFilters : Attribute, IAsyncResultFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // Before the controller 
            if (!context.ModelState.IsValid)
            {
                var errorsInModelStates = context.ModelState
                    .Where(c => c.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(c => c.ErrorMessage)).ToArray();

                var errorResponse = new ErrorResponse();

                foreach (var error in errorsInModelStates)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel()
                        {
                            FieldName = error.Key,
                            Message = subError
                        };
                        errorResponse.Errors.Add(errorModel);
                    }
                }

                var apiResponse = new ApiResponse<ErrorResponse>();
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                context.Result = new BadRequestObjectResult(ApiResponse<ErrorResponse>.Error(errorResponse, AppStatusCode.BadRequest, "Bad Request"));
                await context.Result.ExecuteResultAsync(context);
                return;
            }
            await next();
        }
    }
}
