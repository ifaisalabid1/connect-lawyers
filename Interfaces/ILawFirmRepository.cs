using ConnectLawyers.Models;

namespace ConnectLawyers.Interfaces;

public interface ILawFirmRepository : IRepository<LawFirm>
{
    Task<LawFirm?> GetByEmailAsync(string email);
    Task<IEnumerable<LawFirm>?> GetFeaturedAsync();
    Task<LawFirm?> GetByIdWithLawyersAsync(int id);
}