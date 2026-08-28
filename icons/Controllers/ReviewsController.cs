using icons.Core.Contracts;
using icons.Core.Dtos.Review;
using icons.Data;
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

        public ReviewsController(IReviewService service, IIconService iconService, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _iconService = iconService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddReview(int id)
        {
            var icon = await _iconService.GetIconByIdAsync(id);
            var user = await _userManager.GetUserAsync(User);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with id {id} was not found");
            }

            if (user == null)
            {
                throw new InvalidOperationException("User must be logged in to create an icon.");
            }

            var dto = new ReviewCreateDto
            {
                IconId = icon.Id,
                UserId = user.Id
            };

            return PartialView("_CreateReview", dto);
        }


        [HttpPost]
        public async Task<IActionResult> AddReview(int id, ReviewsCreateViewModel model)
        {
            var icon = await _iconService.GetIconByIdAsync(id);
            var user = await _userManager.GetUserAsync(User);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with id {id} was not found");
            }

            if (user == null)
            {
                throw new InvalidOperationException("User must be logged in to create an icon.");
            }

            var review = new ReviewCreateDto
            {
                Title = model.Title,
                Description = model.Description,
                Rating = model.Rating,
                IconId = icon.Id,
                UserId = user.Id
            };

            await _service.AddReviewAsync(review);

            return RedirectToAction("Icon", "Icons");
        }
    }
}
