// Ignore Spelling: Api

namespace SBS.Models.Common
{
    public class ApiResponse
    {
        public ApiResponse()
        {
        }
        public ApiResponse(object? data = null, bool success = true, string message = "")
        {
            Data = data;
            Success = success;
            Message = message;
        }

        public object? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
