using AutoMapper;
using icons.Core.Contracts;
using icons.Core.Dtos.Icon;
using icons.Core.Dtos.Review;
using icons.Core.Enums;
using icons.Core.Services;
using icons.Data;
using icons.Data.Enums;
using icons.Models.Icons;
using icons.Models.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    [Authorize]
    public class IconsController : Controller
    {
        private readonly IIconService _service;
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CloudinaryService _cloudinary;
        private readonly IMapper _mapper;

        public IconsController(
            IIconService service,
            IReviewService reviewService,
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            CloudinaryService cloudinary,
            IMapper mapper)
        {
            _service = service;
            _reviewService = reviewService;
            _userService = userService;
            _userManager = userManager;
            _cloudinary = cloudinary;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(EnumIconSortOptions sort = EnumIconSortOptions.DateDesc)
        {
            var user = await _userManager.GetUserAsync(User);
            var dtos = await _service.GetAllIconsSortedAsync(sort);

            var icons = new IconsViewModel()
            {
                GetAllIcons = _mapper.Map<IEnumerable<IconViewModel>>(dtos),
                UserId = user?.Id ?? string.Empty,
                Sort = sort
            };

            if (!icons.GetAllIcons.Any())
            {
                return View("NoIcons");
            }

            return View(icons);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Icon(int id, EnumReviewSortOptions sort = EnumReviewSortOptions.DateDesc)
        {
            var icon = await _service.GetIconByIdAsync(id);
            var reviewDtos = await _reviewService.GetAllReviewsByIconIdSortedAsync(id, sort);

            if (icon == null)
            {
                return NotFound();
            }

            var model = new IconDescriptionViewModel
            {
                Id = icon.Id,
                ImageUrl = icon.ImageUrl,
                Title = icon.Title,
                Description = icon.Description,
                Username = icon.Username,
                UserProfilePictureUrl = icon.UserProfilePictureUrl,
                UserId = icon.UserId,
                AverageRating = icon.AverageRating,
                PublishedTime = icon.PublishedTime,
                Reviews = _mapper.Map<IEnumerable<ReviewViewModel>>(reviewDtos)
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateIcon(IconsCreateViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new InvalidOperationException("User must be logged in to create an icon.");
            }

            var imageUrl = await _cloudinary.UploadImageAsync(model.ImageFile, "icons");

            var icon = new IconCreateDto()
            {
                ImageUrl = imageUrl,
                Title = model.Title,
                Description = model.Description,
                UserId = user.Id
            };

            await _service.AddIconAsync(icon);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteIcon(int id)
        {
            await _service.DeleteIconAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var icon = await _service.GetIconByIdAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with id {id} was not found.");
            }

            var updateIcon = new IconsUpdateViewModel()
            {
                Id = id,
                ImageUrl = icon.ImageUrl,
                Title = icon.Title,
                Description = icon.Description
            };

            return View(updateIcon);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIcon(int id, IconsUpdateViewModel model)
        {
            var currentIcon = await _service.GetIconByIdAsync(id);

            string imageUrl = currentIcon.ImageUrl;

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                imageUrl = await _cloudinary.UploadImageAsync(
                    model.ImageFile,
                    "icons");
            }

            var updateIcon = new IconUpdateDto
            {
                Id = model.Id,
                ImageUrl = imageUrl,
                Title = string.IsNullOrWhiteSpace(model.Title)
                    ? currentIcon.Title
                    : model.Title,
                Description = string.IsNullOrWhiteSpace(model.Description)
                    ? currentIcon.Description
                    : model.Description
            };

            await _service.UpdateIconAsync(updateIcon.Id, updateIcon);
            return RedirectToAction("Index");
        }
    }
}
