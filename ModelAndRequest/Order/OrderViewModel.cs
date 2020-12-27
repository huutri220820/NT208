//Vo Huu Tri - 18521531 UIT
using DataLayer.Enums;
using System;

namespace ModelAndRequest.Order
{
    public class OrderViewModel
    {
        public int id { get; set; }
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string sdt { get; set; }
        public string address { get; set; }
        public DateTime dateCreate { get; set; }
        public DateTime? dateReceive { get; set; }
        public DateTime? dateReturn { get; set; }
        public OrderStatus orderStatus { get; set; }
        public float totalPrice { get; set; }
    }
}