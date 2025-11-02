using ConnectLawyers.Dtos;

namespace ConnectLawyers.Services;

public interface ILawyerService
{
    Task<ApiResponse<IEnumerable<LawyerDto>>> GetAllLawyersAsync();
    Task<ApiResponse<LawyerDto>> GetLawyerByIdAsync(int id);
    Task<ApiResponse<LawyerDto>> GetLawyerByEmailAsync(string email);
    Task<ApiResponse<LawyerDto>> GetLawyerWithLawFirmAsync(int id);
    Task<ApiResponse<IEnumerable<LawyerDto>>> GetLawyersByLawFirmAsync(int lawFirmId);
    Task<ApiResponse<IEnumerable<LawyerDto>>> GetFeaturedLawyersAsync();
    Task<ApiResponse<LawyerDto>> CreateLawyerAsync(LawyerCreateDto createDto);
    Task<ApiResponse<LawyerDto>> UpdateLawyerAsync(int id, LawyerUpdateDto updateDto);
    Task<ApiResponse<bool>> DeleteLawyerAsync(int id);
}