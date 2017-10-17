using System;

namespace sharp.aspnet.webapi.Models.Response
{
    public class Error
    {
        public bool HasError { get; set; }
        public Exception Exception { get; set; }
    }
}