//Vo Huu Tri - 18521531 UIT
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelAndRequest.Rating;
using ServiceLayer.RatingService;
using System;
using System.Linq;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/rating/[action]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService ratingService;

        public RatingController(IRatingService ratingService)
        {
            this.ratingService = ratingService;
        }

        [HttpPost]
        [Route("/api/rating/vote")]
        [Authorize(policy: "User")]
        public IActionResult PostRating(RatingRequest rating)
        {
            var userId = User.Claims.First(x => x.Type == "userId").Value;
            rating.UserId = Guid.Parse(userId);
            var result = ratingService.AddRating(rating);
            return Ok(result);
        }
    }
}