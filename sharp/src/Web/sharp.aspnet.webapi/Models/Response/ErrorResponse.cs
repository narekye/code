using System;

namespace sharp.aspnet.webapi.Models.Response
{
    public class ErrorResponse
    {
        public Error Data { get; set; }

        public static ErrorResponse Create(Exception ex)
        {
            return new ErrorResponse
            {
                Data = new Error
                {
                    Exception = ex,
                    HasError = true
                }
            };
        }
    }
}