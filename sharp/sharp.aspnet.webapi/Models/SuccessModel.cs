namespace sharp.aspnet.webapi.Models
{
    public class SuccessModel<T>
    {
        public string Error { get; set; }
        public T Data { get; set; }
    }
}