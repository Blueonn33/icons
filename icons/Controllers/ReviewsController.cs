using icons.Core.Contracts;
using icons.Core.Dtos.Review;
using icons.Data;
using icons.Models.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _service;
        private readonly IIconService _iconService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ReviewsController> _logger;

        public ReviewsController(
            IReviewService service,
            IIconService iconService,
            UserManager<ApplicationUser> userManager,
            ILogger<ReviewsController> logger)
        {
            _service = service;
            _iconService = iconService;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(ReviewsCreateViewModel model)
        {
            if (model.Rating == null)
            {
                ModelState.AddModelError(nameof(ReviewsCreateViewModel.Rating), "Не си поставил оценка");
            }

            var icon = await _iconService.GetIconByIdAsync(model.IconId);
            var user = await _userManager.GetUserAsync(User);

            if (icon == null)
            {
                return NotFound();
            }

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var review = new ReviewCreateDto
                {
                    Title = model.Title,
                    Description = model.Description,
                    Rating = model.Rating,
                    IconId = model.IconId,
                    UserProfilePictureUrl = user.ProfilePictureUrl,
                    Username = user.Name,
                    UserId = user.Id
                };

                await _service.AddReviewAsync(review);
                TempData["Success"] = "Успешно написа ревю";
            }
            catch (Exception e)
            {
                _logger.LogCritical("Възникна грешка. Провери logs");
                TempData["Error"] = "Не е въведена оценка";
            }

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
                return NotFound();
            }

            try
            {
                bool isDeleted = await _service.DeleteReviewAsync(id);

                if (!isDeleted)
                {
                    return NotFound();
                }

                TempData["Success"] = "Успешно изтри ревюто";
            }
            catch (Exception _)
            {
                _logger.LogCritical("Възникна грешка. Провери logs");
                TempData["Error"] = "Възникна грешка при изтриването на ревюто";
            }

            return RedirectToAction("Icon", "Icons", new
            {
                id = review.IconId
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReview(int id, ReviewsUpdateViewModel model)
        {
            var review = await _service.GetReviewByIdAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            try
            {
                var updateReview = new ReviewUpdateDto
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description
                };

                bool isUpdated = await _service.UpdateReviewAsync(updateReview.Id, updateReview);

                if (!isUpdated)
                {
                    return NotFound();
                }

                TempData["Success"] = "Успешно редактира ревюто";
            }
            catch (Exception _)
            {
                _logger.LogCritical("Възникна грешка. Провери logs");
                TempData["Error"] = "Възникна грешка при редактирането на ревюто";
            }

            return RedirectToAction("Icon", "Icons", new
            {
                id = review.IconId
            });
        }
    }
}