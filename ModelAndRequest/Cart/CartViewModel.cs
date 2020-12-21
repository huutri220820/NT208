//Vo Huu Tri - 18521531 UIT
namespace ModelAndRequest.Cart
{
    public class CartViewModel
    {
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string bookImage { get; set; }
        public decimal price { get; set; }
        public decimal sale { get; set; }
        public int quantity { get; set; }
    }
}