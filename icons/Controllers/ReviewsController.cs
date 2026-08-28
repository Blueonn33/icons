using icons.Core.Contracts;
using icons.Core.Dtos.Review;
using icons.Models.Reviews;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _service;

        public ReviewsController(IReviewService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetReviews(int id)
        {
            var reviews = await _service.GetAllReviewsByIconIdAsync(id);

            var reviewDtos = reviews.Select(r => new ReviewGetDto
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                PublishedTime = r.PublishedTime,
                Rating = r.Rating,
                Username = r.Username,
                UserProfilePictureUrl = r.UserProfilePictureUrl
            }).ToList();

            var model = new ReviewsViewModel
            {
                Reviews = reviewDtos
            };

            return PartialView("_Reviews", model);
        }
    }
}
