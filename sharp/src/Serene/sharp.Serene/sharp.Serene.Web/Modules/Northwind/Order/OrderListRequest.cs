using Serenity.Services;

namespace sharp.Serene.Northwind
{
    public class OrderListRequest : ListRequest
    {
        public int? ProductID { get; set; }
    }
}