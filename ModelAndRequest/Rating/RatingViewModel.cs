using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndRequest.Rating
{
    public class RatingViewModel
    {
        public int id { get; set; }
        public Guid userId { get; set; }
        public string username { get; set; }
        public string avatar { get; set; }
        public string comment { get; set; }
        public int rating { get; set; }
    }
}
