//Vo Huu Tri - 18521531 UIT
namespace ModelAndRequest.Book
{
    public class BookViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public decimal price { get; set; }
        public decimal sale { get; set; }
        public string category { get; set; }
        public int? star { get; set; }
        public int? rating_count { get; set; }
        public int available { get; set; }

        //base64 or url image
        public string image { get; set; }
    }
}