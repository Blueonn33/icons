using icons.Core.Enums;
using icons.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace icons.Data.Common
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsByIconIdAsync(int id)
        {
            var icon = await _context.Icons.FindAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with id {id} was not found");
            }

            return await _context.Reviews
                .AsNoTracking()
                .Where(r => r.IconId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetAllReviewsByIconIdSortedAsync(int id, EnumReviewSortOptions sort)
        {
            var icon = await _context.Icons.FindAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with id {id} was not found");
            }

            var query = _context.Reviews
                .AsNoTracking()
                .Where(r => r.IconId == id);

            return sort switch
            {
                EnumReviewSortOptions.DateAsc => await query.OrderBy(r => r.PublishedTime).ToListAsync(),
                EnumReviewSortOptions.DateDesc => await query.OrderByDescending(r => r.PublishedTime).ToListAsync(),
                EnumReviewSortOptions.RatingAsc => await query.OrderBy(r => r.Rating).ToListAsync(),
                EnumReviewSortOptions.RatingDesc => await query.OrderByDescending(r => r.Rating).ToListAsync(),
                _ => await query.ToListAsync()
            };
        }
    }
}
