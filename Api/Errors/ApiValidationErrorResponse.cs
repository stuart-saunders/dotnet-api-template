using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Api.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(StatusCodes.Status400BadRequest)
        {
            
        }

        public IEnumerable<string> Errors { get; set; }
    }
}