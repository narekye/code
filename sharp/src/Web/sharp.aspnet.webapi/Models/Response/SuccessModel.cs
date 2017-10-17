namespace sharp.aspnet.webapi.Models
{
    public class SuccessModel<T> where T : class 
    {
        public Error Errors { get; set; }
        public T Data { get; set; }
        
        public static SuccessModel<T> Success(T data)
        {
            var response = new SuccessModel<T>
            {
                Data = data,
                Errors = new Error { Exception = null, HasError = false }
            };
            return response;
        }
    }
}