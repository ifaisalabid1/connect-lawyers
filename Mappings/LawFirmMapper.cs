using ConnectLawyers.Dtos;
using ConnectLawyers.Models;

namespace ConnectLawyers.Mappings;

public class LawFirmMapper(ILawyerMapper lawyerMapper) : ILawFirmMapper
{
    private readonly ILawyerMapper _lawyerMapper = lawyerMapper;

    public LawFirmDetailDto MapToDetailDto(LawFirm lawFirm)
    {
        ArgumentNullException.ThrowIfNull(lawFirm);

        var dto = new LawFirmDetailDto
        {
            Id = lawFirm.Id,
            Name = lawFirm.Name,
            About = lawFirm.About,
            Website = lawFirm.Website ?? string.Empty,
            Phone = lawFirm.Phone ?? string.Empty,
            Email = lawFirm.Email,
            IsFeatured = lawFirm.IsFeatured,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        if (lawFirm.Lawyers is not null)
        {
            dto.Lawyers = [.. lawFirm.Lawyers.Select(_lawyerMapper.MapToDto)];
        }
        return dto;
    }

    public LawFirmDto MapToDto(LawFirm lawFirm)
    {
        ArgumentNullException.ThrowIfNull(lawFirm);

        return new LawFirmDto
        {
            Id = lawFirm.Id,
            Name = lawFirm.Name,
            About = lawFirm.About,
            Website = lawFirm.Website ?? string.Empty,
            Phone = lawFirm.Phone ?? string.Empty,
            Email = lawFirm.Email,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    public LawFirm MapToEntity(LawFirmCreateDto createDto)
    {
        ArgumentNullException.ThrowIfNull(createDto);

        return new LawFirm
        {
            Name = createDto.Name,
            About = createDto.About,
            Website = createDto.Website ?? string.Empty,
            Phone = createDto.Phone ?? string.Empty,
            Email = createDto.Email,
            IsFeatured = createDto.IsFeatured,
            CreatedAt = DateTime.UtcNow,
        };
    }

    public void MapToEntity(LawFirmUpdateDto updateDto, LawFirm lawFirm)
    {
        ArgumentNullException.ThrowIfNull(updateDto);
        ArgumentNullException.ThrowIfNull(lawFirm);

        lawFirm.Name = updateDto.Name;
        lawFirm.About = updateDto.About;
        lawFirm.Website = updateDto.Website ?? string.Empty;
        lawFirm.Phone = updateDto.Phone ?? string.Empty;
        lawFirm.Email = updateDto.Email;
        lawFirm.IsFeatured = updateDto.IsFeatured;
        lawFirm.UpdatedAt = DateTime.UtcNow;
    }
}