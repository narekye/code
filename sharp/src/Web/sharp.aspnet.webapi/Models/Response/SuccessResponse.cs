namespace sharp.aspnet.webapi.Models.Response
{
    public class SuccessResponse<T> where T : class
    {
        public Error Errors { get; set; }
        public T Data { get; set; }

        public static SuccessResponse<T> Success(T data)
        {
            var response = new SuccessResponse<T>
            {
                Data = data,
                Errors = new Error { Exception = null, HasError = false }
            };
            return response;
        }
    }
}