using Microsoft.AspNetCore.Http;

namespace ModelAndRequest.Book
{
    public class BookRequest
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal sale { get; set; }
        public int categoryId { get; set; }
        public int available { get; set; }
        public IFormFile image { get; set; }
        public string descripton { get; set; }
        public string keyWord { get; set; }
    }
}
