using AutoMapper;
using icons.Core.Contracts;
using icons.Core.ViewModels.Reviews;
using icons.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    public class ReviewsController(
        IReviewService _reviewService,
        IIconService _iconService,
        UserManager<ApplicationUser> _userManager,
        IMapper _mapper,
        ILogger<ReviewsController> _logger) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateReview(int iconId, ReviewInputModel model)
        {
            if (model.Rating == null)
            {
                ModelState.AddModelError(nameof(ReviewInputModel.Rating), "Не си поставил оценка");
            }

            var icon = await _iconService.GetIconByIdAsync(iconId);
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
                var review = new ReviewInputModel()
                {
                    Title = model.Title,
                    Description = model.Description,
                    IconId = model.IconId,
                    Rating = model.Rating,
                    UserId = user.Id,
                    Username = user.Name,
                    UserProfilePictureUrl = user.ProfilePictureUrl
                };

                await _reviewService.AddReviewAsync(review);
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
            var review = await _reviewService.GetReviewByIdAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            try
            {
                bool isDeleted = await _reviewService.DeleteReviewAsync(id);

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
        public async Task<IActionResult> UpdateReview(int id, ReviewInputModel model)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            try
            {
                var updateReview = new ReviewInputModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description
                };

                bool isUpdated = await _reviewService.UpdateReviewAsync(updateReview.Id, updateReview);

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