using ModelAndRequest.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.SummaryService
{
    public interface ISummaryService
    {
        Task<ApiResult<object>> Get();
    }
}
