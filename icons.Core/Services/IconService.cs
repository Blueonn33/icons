using icons.Core.Contracts;
using icons.Core.Dtos.Icon;
using icons.Data.Common;
using icons.Data.Models;

namespace icons.Core.Services
{
    public class IconService : IIconService
    {
        private readonly IRepository<Icon> _repository;

        public IconService(IRepository<Icon> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IconGetDto>> GetAllIconsAsync()
        {
            var icons = await _repository.GetAllAsync();

            return icons.Select(i => new IconGetDto
            {
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                Title = i.Title,
                Description = i.Description,
                AverageRating = i.AverageRating,
                Username = i.Username
            });
        }

        public async Task<IEnumerable<IconGetDto>> GetAllIconsByUserIdAsync(string userId)
        {
            var icons = await _repository.GetAllAsync();

            return icons
                .Where(i => i.UserId == userId)
                .Select(i => new IconGetDto
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl,
                    Title = i.Title,
                    Description = i.Description,
                    AverageRating = i.AverageRating,
                    Username = i.Username
                });
        }

        public async Task<IEnumerable<IconGetDto>> GetTop3IconsAsync()
        {
            var icons = await _repository.GetAllAsync();

            return icons
                .OrderByDescending(i => i.AverageRating)
                .Take(3)
                .Select(i => new IconGetDto
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl,
                    Title = i.Title,
                    Description = i.Description,
                    AverageRating = i.AverageRating,
                    Username = i.Username
                });
        }

        public async Task<IconGetDto?> GetIconByIdAsync(int id)
        {
            var icon = await _repository.GetByIdAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Entity of type {typeof(IconGetDto).Name} with Id {id} was not found.");
            }

            return new IconGetDto
            {
                Id = icon.Id,
                ImageUrl = icon.ImageUrl,
                Title = icon.Title,
                Description = icon.Description,
                AverageRating = icon.AverageRating,
                Username = icon.Username
            };
        }

        public Task AddIconAsync(IconCreateDto icon)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIconAsync(int id, IconUpdateDto icon)
        {
            throw new NotImplementedException();
        }

        public Task DeleteIconAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
