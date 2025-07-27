using Microsoft.AspNetCore.Mvc;
using SBS.Models.Common;

namespace SBS.Utilities.Exceptions
{
    public static class ExceptionHandler
    {
        public static ActionResult<ApiResponse> HandleError(this Exception ex)
        {
            return ex switch
            {
                //ValidationException validationEx => HandleValidationError(validationEx),
                NotFoundException => new NotFoundObjectResult(new ApiResponse(string.Empty, false, ex.Message)),
                BadRequestException => new BadRequestObjectResult(new ApiResponse(string.Empty, false, ex.Message)),
                UnauthorizedAccessException => new UnauthorizedObjectResult(new ApiResponse(string.Empty, false, "Unauthorized access")),
                _ => new ObjectResult(new ApiResponse(string.Empty, false, "An unexpected error occurred"))
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                }
            };
        }

        //private static ActionResult<ApiResponse> HandleValidationError(ValidationException validationEx)
        //{

        //    var errorData = validationEx.Errors.Select(e => new
        //    {
        //        propertyName = e.PropertyName,
        //        attemptedValue = e.AttemptedValue,
        //        errorMessage = e.ErrorMessage
        //    }).ToList();

        //    return new BadRequestObjectResult(new ApiResponse(errorData, false, "Model Validation Failed!"));
        //}
    }
}
