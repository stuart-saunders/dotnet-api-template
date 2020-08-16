using System;
using Microsoft.AspNetCore.Http;

namespace Api.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                StatusCodes.Status400BadRequest => "Bad Request",
                StatusCodes.Status401Unauthorized => "Not Authorised",
                StatusCodes.Status404NotFound => "Resource Not Found",
                StatusCodes.Status500InternalServerError => "Server Error",
                _ => null
            };
        }
    }
}