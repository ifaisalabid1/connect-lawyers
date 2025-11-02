using ConnectLawyers.Dtos;
using ConnectLawyers.Models;

namespace ConnectLawyers.Mappings;

public interface ILawyerMapper
{
    LawyerDto MapToDto(Lawyer lawyer);
    Lawyer MapToEntity(LawyerCreateDto createDto);
    void MapToEntity(LawyerUpdateDto updateDto, Lawyer lawyer);
}