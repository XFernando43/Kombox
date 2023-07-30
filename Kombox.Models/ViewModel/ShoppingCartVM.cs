using Kombox.Models.Models;

namespace Kombox.Models.ViewModel
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        public OrderHeader OrderHeader { get; set; }
        //public double OrderTotal { get; set; }
    }
}
