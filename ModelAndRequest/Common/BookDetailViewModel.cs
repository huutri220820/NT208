using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndRequest.Common
{
    public class BookDetailViewModel : BookViewModel
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}
