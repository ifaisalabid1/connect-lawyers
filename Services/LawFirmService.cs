using ConnectLawyers.Dtos;
using ConnectLawyers.Interfaces;
using ConnectLawyers.Mappings;

namespace ConnectLawyers.Services;

public class LawFirmService(ILawFirmRepository lawFirmRepository, ILawFirmMapper lawFirmMapper) : ILawFirmService
{
    private readonly ILawFirmRepository _lawFirmRepository = lawFirmRepository;
    private readonly ILawFirmMapper _lawFirmMapper = lawFirmMapper;

    public async Task<ApiResponse<LawFirmDto>> CreateLawFirmAsync(LawFirmCreateDto createDto)
    {
        try
        {
            var existingLawFirm = await _lawFirmRepository.GetByEmailAsync(createDto.Email);

            if (existingLawFirm is not null)
            {
                return ApiResponse<LawFirmDto>.Fail("Law firm already exists.");
            }

            var lawFirm = _lawFirmMapper.MapToEntity(createDto);
            var createdLawFirm = await _lawFirmRepository.AddAsync(lawFirm);
            var lawFirmDto = _lawFirmMapper.MapToDto(createdLawFirm);

            return ApiResponse<LawFirmDto>.Ok(lawFirmDto, "Law firm created successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<LawFirmDto>.Fail($"Error creating law firm: {ex.Message}");
        }
    }

    public async Task<ApiResponse<bool>> DeleteLawFirmAsync(int id)
    {
        try
        {
            var lawFirm = await _lawFirmRepository.GetByIdAsync(id);

            if (lawFirm is null)
            {
                return ApiResponse<bool>.Fail("Law firm not found.");
            }

            await _lawFirmRepository.DeleteAsync(lawFirm);
            return ApiResponse<bool>.Ok(true, "Law firm deleted successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.Fail($"Error deleting law firm: {ex.Message}");
        }
    }

    public async Task<ApiResponse<IEnumerable<LawFirmDto>>> GetAllLawFirmsAsync()
    {
        try
        {
            var lawFirms = await _lawFirmRepository.GetAllAsync();
            var lawFirmDtos = lawFirms.Select(_lawFirmMapper.MapToDto);
            return ApiResponse<IEnumerable<LawFirmDto>>.Ok(lawFirmDtos);
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<LawFirmDto>>.Fail($"Error retrieving law firms: {ex.Message}");
        }
    }

    public async Task<ApiResponse<IEnumerable<LawFirmDto>>> GetFeaturedLawFirmsAsync()
    {
        try
        {
            var featuredLawFirms = await _lawFirmRepository.GetFeaturedAsync();
            if (featuredLawFirms is null)
            {
                return ApiResponse<IEnumerable<LawFirmDto>>.Fail("Featured law firms not found.");
            }

            var featuredLawFirmsDtos = featuredLawFirms.Select(_lawFirmMapper.MapToDto);
            return ApiResponse<IEnumerable<LawFirmDto>>.Ok(featuredLawFirmsDtos);
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<LawFirmDto>>.Fail($"Error retrieving featured law firms: {ex.Message}");
        }
    }

    public async Task<ApiResponse<LawFirmDto>> GetLawFirmByEmailAsync(string email)
    {
        try
        {
            var lawFirm = await _lawFirmRepository.GetByEmailAsync(email);
            if (lawFirm is null)
            {
                return ApiResponse<LawFirmDto>.Fail("Law firm not found.");
            }

            var lawFirmDto = _lawFirmMapper.MapToDto(lawFirm);
            return ApiResponse<LawFirmDto>.Ok(lawFirmDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<LawFirmDto>.Fail($"Error retrieving law firm: {ex.Message}");
        }
    }

    public async Task<ApiResponse<LawFirmDto>> GetLawFirmByIdAsync(int id)
    {
        try
        {
            var lawFirm = await _lawFirmRepository.GetByIdAsync(id);
            if (lawFirm is null)
            {
                return ApiResponse<LawFirmDto>.Fail("Law firm not found.");
            }

            var lawFirmDto = _lawFirmMapper.MapToDto(lawFirm);
            return ApiResponse<LawFirmDto>.Ok(lawFirmDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<LawFirmDto>.Fail($"Error retrieving law firm: {ex.Message}");
        }
    }

    public async Task<ApiResponse<LawFirmDetailDto>> GetLawFirmDetailByIdAsync(int id)
    {
        try

        {
            var lawFirm = await _lawFirmRepository.GetByIdWithLawyersAsync(id);

            if (lawFirm is null)
            {
                return ApiResponse<LawFirmDetailDto>.Fail("Law Firm not found");
            }

            var lawFirmDetailDto = _lawFirmMapper.MapToDetailDto(lawFirm);

            return ApiResponse<LawFirmDetailDto>.Ok(lawFirmDetailDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<LawFirmDetailDto>.Fail($"Error retrieving law firm details: {ex.Message}");
        }
    }

    public async Task<ApiResponse<LawFirmDto>> UpdateLawFirmAsync(int id, LawFirmUpdateDto updateDto)
    {
        try
        {
            var existingLawFirm = await _lawFirmRepository.GetByIdAsync(id);
            if (existingLawFirm is null)
            {
                return ApiResponse<LawFirmDto>.Fail("Law firm not found.");
            }

            _lawFirmMapper.MapToEntity(updateDto, existingLawFirm);
            var updatedLawFirm = await _lawFirmRepository.UpdateAsync(existingLawFirm);
            var lawFirmDto = _lawFirmMapper.MapToDto(updatedLawFirm);
            return ApiResponse<LawFirmDto>.Ok(lawFirmDto, "Law firm updated successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<LawFirmDto>.Fail($"Error updating law firm: {ex.Message}");
        }
    }
}