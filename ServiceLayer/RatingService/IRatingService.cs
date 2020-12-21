//Vo Huu Tri - 18521531 UIT
using ModelAndRequest.API;
using ModelAndRequest.Rating;

namespace ServiceLayer.RatingService
{
    public interface IRatingService
    {
        ApiResult<string> AddRating(RatingRequest ratingRequest);
    }
}