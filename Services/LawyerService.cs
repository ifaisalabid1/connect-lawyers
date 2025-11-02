using ConnectLawyers.Dtos;
using ConnectLawyers.Interfaces;
using ConnectLawyers.Mappings;

namespace ConnectLawyers.Services;

public class LawyerService(ILawyerRepository lawyerRepository, ILawyerMapper lawyerMapper) : ILawyerService
{
    private readonly ILawyerRepository _lawyerRepository = lawyerRepository;
    private readonly ILawyerMapper _lawyerMapper = lawyerMapper;

    public async Task<ApiResponse<LawyerDto>> CreateLawyerAsync(LawyerCreateDto createDto)
    {
        try
        {
            var existingLawyer = await _lawyerRepository.GetByEmailAsync(createDto.Email);

            if (existingLawyer is not null)
            {
                return ApiResponse<LawyerDto>.Fail("Lawyer already exists.");
            }

            var lawyer = _lawyerMapper.MapToEntity(createDto);
            var createdLawyer = await _lawyerRepository.AddAsync(lawyer);
            var lawyerDto = _lawyerMapper.MapToDto(createdLawyer);

            return ApiResponse<LawyerDto>.Ok(lawyerDto, "Lawyer created successfully.")
        }
        catch (Exception ex)
        {
            return ApiResponse<LawyerDto>.Fail($"Error creating lawyer: {ex.Message}");
        }
    }

    public async Task<ApiResponse<bool>> DeleteLawyerAsync(int id)
    {
        try
        {
            var lawyer = await _lawyerRepository.GetByIdAsync(id);
            if (lawyer is null)
            {
                return ApiResponse<bool>.Fail("Lawyer not found.");
            }

            await _lawyerRepository.DeleteAsync(lawyer);
            return ApiResponse<bool>.Ok(true, "lawyer deleted successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.Fail($"Error deleting lawyer: {ex.Message}");
        }
    }

    public async Task<ApiResponse<IEnumerable<LawyerDto>>> GetAllLawyersAsync()
    {
        try
        {
            var lawyers = await _lawyerRepository.GetAllAsync();
            var lawyerDtos = lawyers.Select(_lawyerMapper.MapToDto);
            return ApiResponse<IEnumerable<LawyerDto>>.Ok(lawyerDtos);
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<LawyerDto>>.Fail($"Error retrieving lawyers: {ex.Message}");
        }
    }

    public async Task<ApiResponse<IEnumerable<LawyerDto>>> GetFeaturedLawyersAsync()
    {
        try
        {
            var featuredLawyers = await _lawyerRepository.GetFeaturedAsync();
            if (featuredLawyers is null)
            {
                return ApiResponse<IEnumerable<LawyerDto>>.Fail("Featured lawyers not found.");
            }
            var featuredLawyersDto = featuredLawyers.Select(_lawyerMapper.MapToDto);
            return ApiResponse<IEnumerable<LawyerDto>>.Ok(featuredLawyersDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<LawyerDto>>.Fail($"Error retrieving featured lawyers: {ex.Message}");
        }
    }

    public async Task<ApiResponse<LawyerDto>> GetLawyerByEmailAsync(string email)
    {
        try
        {
            var lawyer = await _lawyerRepository.GetByEmailAsync(email);
            if (lawyer is null)
            {
                return ApiResponse<LawyerDto>.Fail("Lawyer not found.");
            }

            var lawyerDto = _lawyerMapper.MapToDto(lawyer);
            return ApiResponse<LawyerDto>.Ok(lawyerDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<LawyerDto>.Fail($"Error retrieving lawyer: {ex.Message}");
        }
    }

    public async Task<ApiResponse<LawyerDto>> GetLawyerByIdAsync(int id)
    {
        try
        {
            var lawyer = await _lawyerRepository.GetByIdAsync(id);
            if (lawyer is null)
            {
                return ApiResponse<LawyerDto>.Fail("Lawyer not found.");
            }

            var lawyerDto = _lawyerMapper.MapToDto(lawyer);
            return ApiResponse<LawyerDto>.Ok(lawyerDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<LawyerDto>.Fail($"Error retrieving lawyer: {ex.Message}");
        }
    }

    public async Task<ApiResponse<LawyerDto>> GetLawyerWithLawFirmAsync(int id)
    {
        try
        {
            var lawyer = await _lawyerRepository.GetByIdWithLawFirmAsync(id);
            if (lawyer is null)
            {
                return ApiResponse<LawyerDto>.Fail("Lawyer not found.");
            }

            var lawyerDto = _lawyerMapper.MapToDto(lawyer);
            return ApiResponse<LawyerDto>.Ok(lawyerDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<LawyerDto>.Fail($"Error retrieving lawyer: {ex.Message}");
        }
    }

    public async Task<ApiResponse<IEnumerable<LawyerDto>>> GetLawyersByLawFirmAsync(int lawFirmId)
    {
        try
        {
            var lawyers = await _lawyerRepository.GetLawyersByLawFirmAsync(lawFirmId);
            if (lawyers is null)
            {
                return ApiResponse<IEnumerable<LawyerDto>>.Fail("Lawyer is not associated with any law firm.");
            }
            var lawyerDtos = lawyers.Select(_lawyerMapper.MapToDto);
            return ApiResponse<IEnumerable<LawyerDto>>.Ok(lawyerDtos);
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<LawyerDto>>.Fail($"Error retrieving lawyers: {ex.Message}");
        }
    }

    public async Task<ApiResponse<LawyerDto>> UpdateLawyerAsync(int id, LawyerUpdateDto updateDto)
    {
        try
        {
            var existingLawyer = await _lawyerRepository.GetByIdAsync(id);
            if (existingLawyer is null)
            {
                return ApiResponse<LawyerDto>.Fail("Lawyer not found.");
            }
            _lawyerMapper.MapToEntity(updateDto, existingLawyer);
            var updatedLawyer = await _lawyerRepository.UpdateAsync(existingLawyer);
            var lawyerDto = _lawyerMapper.MapToDto(updatedLawyer);
            return ApiResponse<LawyerDto>.Ok(lawyerDto, "Lawyer updated successfully");

        }
        catch (Exception ex)
        {
            return ApiResponse<LawyerDto>.Fail($"Error updating lawyer: {ex.Message}");
        }
    }
}