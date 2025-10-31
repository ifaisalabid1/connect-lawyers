using ConnectLawyers.Models;

namespace ConnectLawyers.Interfaces;

public interface ILawyerRepository : IRepository<Lawyer>
{
    Task<IEnumerable<Lawyer>?> GetLawyersByLawFirmAsync(int lawFirmId);
    Task<Lawyer?> GetByEmailAsync(string email);
    Task<IEnumerable<Lawyer>?> GetFeaturedAsync();
    Task<Lawyer?> GetByIdWithLawFirmAsync(int id);
}