using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndRequest.Cart
{
    public class CartViewModel
    {
        public Guid userId { get; set; }
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string bookImage { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}
