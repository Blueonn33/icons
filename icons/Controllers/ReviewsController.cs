using icons.Core.Contracts;
using icons.Core.Dtos.Review;
using icons.Data;
using icons.Data.Models;
using icons.Models.Reviews;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _service;
        private readonly IIconService _iconService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewsController(
            IReviewService service,
            IIconService iconService,
            UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _iconService = iconService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(ReviewsCreateViewModel model)
        {
            var icon = await _iconService.GetIconByIdAsync(model.IconId);
            var user = await _userManager.GetUserAsync(User);

            if (icon == null)
            {
                return NotFound();
            }

            if (user == null)
            {
                return Unauthorized();
            }

            var review = new ReviewCreateDto
            {
                Title = model.Title,
                Description = model.Description,
                Rating = model.Rating,
                IconId = icon.Id,
                Username = user.Name,
                UserProfilePictureUrl = string.IsNullOrWhiteSpace(user.ProfilePictureUrl)
                    ? "~/img/default-profile-pic.jpg"
                    : user.ProfilePictureUrl,
                UserId = user.Id
            };

            await _service.AddReviewAsync(review);

            return RedirectToAction("Icon", "Icons", new
            {
                id = model.IconId
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _service.GetReviewByIdAsync(id);

            if (review == null)
            {
                throw new KeyNotFoundException($"Review with id {id} was not found");
            }

            await _service.DeleteReviewAsync(id);
            return RedirectToAction("Icon", "Icons", new Icon { Id = review.IconId });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReview(int id, ReviewsUpdateViewModel model)
        {
            var review = await _service.GetReviewByIdAsync(id);

            if (review == null)
            {
                throw new KeyNotFoundException($"Review with id {id} was not found");
            }

            var updateReview = new ReviewUpdateDto
            {
                Id = review.Id,
                Title = string.IsNullOrWhiteSpace(model.Title) ? review.Title : model.Title,
                Description = string.IsNullOrWhiteSpace(model.Description) ? review.Description : model.Description
            };

            await _service.UpdateReviewAsync(updateReview.Id, updateReview);
            return RedirectToAction("Icon", "Icons", new Icon { Id = review.IconId });
        }
    }
}