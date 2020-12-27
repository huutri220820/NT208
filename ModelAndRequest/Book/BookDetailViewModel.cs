//Vo Huu Tri - 18521531 UIT
using ModelAndRequest.Rating;
using System.Collections.Generic;

namespace ModelAndRequest.Book
{
    public class BookDetailViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public float price { get; set; }
        public float sale { get; set; }
        public string category { get; set; }
        public int categoryId { get; set; }
        public int available { get; set; }

        //base64 or url image
        public string image { get; set; }

        public string keyWord { get; set; }
        public string description { get; set; }
        public List<RatingViewModel> comments { get; set; }
    }
}