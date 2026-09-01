using icons.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace icons.Data.Common
{
    public class IconRepository : Repository<Icon>, IIconRepository
    {
        private readonly ApplicationDbContext _context;
        public IconRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Icon>> GetAllIconsAsync()
        {
            return await _context.Icons.ToListAsync();
        }

        public async Task<IEnumerable<Icon>> GetAllIconsByUserIdAsync(string userId)
        {
            return await _context.Icons
                .AsNoTracking()
                .Where(i => i.UserId == userId)
                .ToListAsync();
        }

        public async Task<Icon?> GetIconWithReviewsByIdAsync(int id)
        {
            return await _context.Icons
                .AsNoTracking()
                .Include(i => i.Reviews)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Icon>> GetTop3IconsAsync()
        {
            return await _context.Icons
                .AsNoTracking()
                .OrderByDescending(i => i.AverageRating)
                .Take(3)
                .ToListAsync();
        }
    }
}