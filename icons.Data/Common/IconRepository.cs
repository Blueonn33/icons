using icons.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace icons.Data.Common
{
    public class IconRepository : Repository<Icon>
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
    }
}
