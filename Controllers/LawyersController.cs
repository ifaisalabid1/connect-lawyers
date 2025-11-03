using ConnectLawyers.Dtos;
using ConnectLawyers.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConnectLawyers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LawyersController(ILawyerService lawyerService) : ControllerBase
{
    private readonly ILawyerService _lawyerService = lawyerService;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<LawyerDto>>>> GetLawyers()
    {
        var result = await _lawyerService.GetAllLawyersAsync();
        return Ok(result);
    }

    [HttpGet("with-law-firm")]
    public async Task<ActionResult<ApiResponse<IEnumerable<LawyerDto>>>> GetLawyersWithLawFirm()
    {
        var result = await _lawyerService.GetAllLawyersWithLawFirmAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<LawyerDto>>> GetLawyer(int id)
    {
        var result = await _lawyerService.GetLawyerByIdAsync(id);
        if (!result.Success)
        {
            return NotFound(result);
        }
        return Ok(result);
    }

    [HttpGet("law-firm/{lawFirmId}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<LawyerDto>>>> GetLawyersByLawFirm(int lawFirmId)
    {
        var result = await _lawyerService.GetLawyersByLawFirmAsync(lawFirmId);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<LawyerDto>>> CreateLawyer(LawyerCreateDto createDto)
    {
        var result = await _lawyerService.CreateLawyerAsync(createDto);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return CreatedAtAction(nameof(GetLawyer), new { id = result.Data!.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<LawyerDto>>> UpateLawyer(int id, LawyerUpdateDto updateDto)
    {
        var result = await _lawyerService.UpdateLawyerAsync(id, updateDto);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteLawyer(int id)
    {
        var result = await _lawyerService.DeleteLawyerAsync(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpGet("featured")]
    public async Task<ActionResult<ApiResponse<IEnumerable<LawyerDto>>>> GetFeaturedLawyers()
    {
        var result = await _lawyerService.GetFeaturedLawyersAsync();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}