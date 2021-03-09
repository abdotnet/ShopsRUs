using Habaripay.ShopsRUs.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Domain.Contracts
{
    public class ApiResponse<TEntity>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public TEntity Data { get; set; }

        public static ApiResponse<TEntity> Successful(TEntity model, string status = "00", string message = "Successful")
        {
            ApiResponse<TEntity> response = new ApiResponse<TEntity>();
            response.Data = model;
            response.Status = status;
            response.Message = message;

            return response;
        }

        public static ApiResponse<TEntity> Error(TEntity model, string status = "03", string message = "An error occured")
        {
            ApiResponse<TEntity> response = new ApiResponse<TEntity>();
            response.Data = model;
            response.Status = status;
            response.Message = message;

            return response;
        }
    }
}
