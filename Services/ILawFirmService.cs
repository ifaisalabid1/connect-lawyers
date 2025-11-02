using ConnectLawyers.Dtos;

namespace ConnectLawyers.Services;

public interface ILawFirmService
{
    Task<ApiResponse<IEnumerable<LawFirmDto>>> GetAllLawFirmsAsync();
    Task<ApiResponse<LawFirmDto>> GetLawFirmByIdAsync(int id);
    Task<ApiResponse<LawFirmDto>> GetLawFirmByEmailAsync(string email);
    Task<ApiResponse<LawFirmDetailDto>> GetLawFirmDetailByIdAsync(int id);
    Task<ApiResponse<IEnumerable<LawFirmDto>>> GetFeaturedLawFirmsAsync();
    Task<ApiResponse<LawFirmDto>> CreateLawFirmAsync(LawFirmCreateDto createDto);
    Task<ApiResponse<LawFirmDto>> UpdateLawFirmAsync(int id, LawFirmUpdateDto updateDto);
    Task<ApiResponse<bool>> DeleteLawFirmAsync(int id);
}