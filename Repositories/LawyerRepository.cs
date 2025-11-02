using ConnectLawyers.Data;
using ConnectLawyers.Interfaces;
using ConnectLawyers.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectLawyers.Repositories;

public class LawyerRepository(AppDbContext context) : BaseRepository<Lawyer>(context), ILawyerRepository
{
    public async Task<Lawyer?> GetByEmailAsync(string email)
    {
        return await _context.Lawyers
            .FirstOrDefaultAsync(l => l.Email.ToLower() == email.ToLower());
    }

    public async Task<Lawyer?> GetByIdWithLawFirmAsync(int id)
    {
        return await _context.Lawyers
            .Include(l => l.LawFirm)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<IEnumerable<Lawyer>?> GetFeaturedAsync()
    {
        return await _context.Lawyers
            .Where(l => l.IsFeatured)
            .ToListAsync();
    }

    public async Task<IEnumerable<Lawyer>?> GetLawyersByLawFirmAsync(int lawFirmId)
    {
        return await _context.Lawyers
            .Include(l => l.LawFirm)
            .Where(l => l.LawFirmId == lawFirmId)
            .ToListAsync();
    }
}