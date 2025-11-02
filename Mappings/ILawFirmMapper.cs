using ConnectLawyers.Dtos;
using ConnectLawyers.Models;

namespace ConnectLawyers.Mappings;

public interface ILawFirmMapper
{
    LawFirmDto MapToDto(LawFirm lawFirm);
    LawFirm MapToEntity(LawFirmCreateDto createDto);
    void MapToEntity(LawFirmUpdateDto updateDto, LawFirm lawFirm);
    LawFirmDetailDto MapToDetailDto(LawFirm lawFirm);
}