using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndRequest.API
{
    public class ApiResult<T>
    {
        public bool IsSuccsess { get; set; }
        public string Message { get; set; }
        public T PayLoad { get; set; }

        public ApiResult()
        {

        }
        public ApiResult(bool isSuccess, string messge, T payload)
        {
            this.IsSuccsess = isSuccess;
            this.Message = messge;
            this.PayLoad = payload;
        }
    }
}
