namespace Rainfall.Api.Core.Application.Common.Response.Error
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string ErrorDetail { get; set; }
    }
    public class ErrorDetail
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }

}
