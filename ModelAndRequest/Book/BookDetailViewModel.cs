using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndRequest.Book
{
    public class BookDetailViewModel : BookViewModel
    {
        public int categoryId { get; set; }
        public string description { get; set; }
    }
}
