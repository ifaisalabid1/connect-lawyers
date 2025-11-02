using ConnectLawyers.Data;
using ConnectLawyers.Interfaces;
using ConnectLawyers.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectLawyers.Repositories;

public class LawFirmRepository(AppDbContext context) : BaseRepository<LawFirm>(context), ILawFirmRepository
{
    public async Task<LawFirm?> GetByEmailAsync(string email)
    {
        return await _context.LawFirms
            .FirstOrDefaultAsync(f => f.Email.ToLower() == email.ToLower());
    }

    public async Task<LawFirm?> GetByIdWithLawyersAsync(int id)
    {
        return await _context.LawFirms
            .Include(f => f.Lawyers)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<LawFirm>?> GetFeaturedAsync()
    {
        return await _context.LawFirms
            .Where(f => f.IsFeatured)
            .ToListAsync();
    }
}