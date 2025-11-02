using System.ComponentModel.DataAnnotations;

namespace ConnectLawyers.Dtos;

public class LawyerDto
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

    [Range(0, 100, ErrorMessage = "Year of Experience must be between 0 and 100.")]
    public int YearOfExperience { get; set; } = 0;
    public int? LawFirmId { get; set; }
    public string? LawFirmName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public class LawyerCreateDto
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

    public int? LawFirmId { get; set; }

    [Range(0, 100, ErrorMessage = "Year of Experience must be between 0 and 100.")]
    public int YearOfExperience { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class LawyerUpdateDto
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

    [Range(0, 100, ErrorMessage = "Year of Experience must be between 0 and 100.")]
    public int YearOfExperience { get; set; } = 0;

    public int? LawFirmId { get; set; }
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}