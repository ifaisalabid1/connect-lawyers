using ConnectLawyers.Dtos;
using ConnectLawyers.Models;

namespace ConnectLawyers.Mappings;

public class LawyerMapper : ILawyerMapper
{
    public LawyerDto MapToDto(Lawyer lawyer)
    {
        ArgumentNullException.ThrowIfNull(lawyer);

        return new LawyerDto
        {
            Id = lawyer.Id,
            Name = lawyer.Name,
            About = lawyer.About,
            Website = lawyer.Website ?? string.Empty,
            Phone = lawyer.Phone ?? string.Empty,
            Email = lawyer.Email,
            IsFeatured = lawyer.IsFeatured,
            YearOfExperience = lawyer.YearOfExperience,
            LawFirmId = lawyer.LawFirmId,
            LawFirmName = lawyer.LawFirm?.Name ?? string.Empty,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    public Lawyer MapToEntity(LawyerCreateDto createDto)
    {
        ArgumentNullException.ThrowIfNull(createDto);

        return new Lawyer
        {
            Name = createDto.Name,
            About = createDto.About,
            Website = createDto.Website ?? string.Empty,
            Phone = createDto.Phone ?? string.Empty,
            Email = createDto.Email,
            IsFeatured = createDto.IsFeatured,
            YearOfExperience = createDto.YearOfExperience,
            LawFirmId = createDto.LawFirmId,
            CreatedAt = DateTime.UtcNow,
        };
    }

    public void MapToEntity(LawyerUpdateDto updateDto, Lawyer lawyer)
    {
        ArgumentNullException.ThrowIfNull(updateDto);
        ArgumentNullException.ThrowIfNull(lawyer);

        lawyer.Name = updateDto.Name;
        lawyer.About = updateDto.About;
        lawyer.Website = updateDto.Website ?? string.Empty;
        lawyer.Phone = updateDto.Phone ?? string.Empty;
        lawyer.Email = updateDto.Email;
        lawyer.IsFeatured = updateDto.IsFeatured;
        lawyer.YearOfExperience = updateDto.YearOfExperience;
        lawyer.LawFirmId = updateDto.LawFirmId;
        lawyer.UpdatedAt = DateTime.UtcNow;

    }
}