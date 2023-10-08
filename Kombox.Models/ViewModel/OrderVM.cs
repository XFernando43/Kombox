using Kombox.Models.Models;

namespace Kombox.Models.ViewModel
{
    public class OrderVM
    {
        public OrderHeader orderHeader { get; set; }
        public IEnumerable<OrderDetail> orderDetails { get; set; }
    }
}
