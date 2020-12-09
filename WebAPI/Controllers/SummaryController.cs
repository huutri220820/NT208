using Microsoft.AspNetCore.Mvc;
using ServiceLayer.SummaryService;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly ISummaryService summaryService;

        public SummaryController(ISummaryService summaryService)
        {
            this.summaryService = summaryService;
        }

        [Route("summary/get")]
        [HttpGet]
        public async Task<IActionResult> GetSummary()
        {
            var result = await this.summaryService.Get();
            return Ok(result);
        }
    }
}
