//Vo Huu Tri - 18521531 UIT
using ModelAndRequest.API;
using System.Threading.Tasks;

namespace ServiceLayer.SummaryService
{
    public interface ISummaryService
    {
        Task<ApiResult<object>> Get();
    }
}