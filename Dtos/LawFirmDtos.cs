using System.ComponentModel.DataAnnotations;
namespace ConnectLawyers.Dtos;

public class LawFirmDto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "About is required.")]
    [MaxLength(500, ErrorMessage = "Name must not be more than 500 characters long.")]
    public required string About { get; set; }

    [Url(ErrorMessage = "Website must be a proper url.")]
    [MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string? Website { get; set; }

    [Phone(ErrorMessage = "Phone number is invalid.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Email address is invalid.")]
    [MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public required string Email { get; set; }
    public bool IsFeatured { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public class LawFirmCreateDto
{
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "About is required.")]
    [MaxLength(500, ErrorMessage = "Name must not be more than 500 characters long.")]
    public required string About { get; set; }

    [Url(ErrorMessage = "Website must be a proper url.")]
    [MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string? Website { get; set; }

    [Phone(ErrorMessage = "Phone number is invalid.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Email address is invalid.")]
    [MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public required string Email { get; set; }
    public bool IsFeatured { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class LawFirmUpdateDto
{
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "About is required.")]
    [MaxLength(500, ErrorMessage = "Name must not be more than 500 characters long.")]
    public required string About { get; set; }

    [Url(ErrorMessage = "Website must be a proper url.")]
    [MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string? Website { get; set; }

    [Phone(ErrorMessage = "Phone number is invalid.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Email address is invalid.")]
    [MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public required string Email { get; set; }
    public bool IsFeatured { get; set; } = false;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class LawFirmDetailDto : LawFirmDto
{
    public List<LawyerDto> Lawyers { get; set; } = [];
}