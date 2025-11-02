using ConnectLawyers.Dtos;
using ConnectLawyers.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConnectLawyers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LawFirmsController(ILawFirmService lawFirmService) : ControllerBase
{
    private readonly ILawFirmService _lawFirmService = lawFirmService;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<LawFirmDto>>>> GetLawFirms()
    {
        var result = await _lawFirmService.GetAllLawFirmsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<LawFirmDto>>> GetLawFirm(int id)
    {
        var result = await _lawFirmService.GetLawFirmByIdAsync(id);
        if (!result.Success)
        {
            return NotFound(result);
        }
        return Ok(result);
    }

    [HttpGet("{id}/detail")]
    public async Task<ActionResult<ApiResponse<LawFirmDetailDto>>> GetLawFirmDetail(int id)
    {
        var result = await _lawFirmService.GetLawFirmDetailByIdAsync(id);
        if (!result.Success)
        {
            return NotFound(result);
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<LawFirmDto>>> CreateLawFirm(LawFirmCreateDto createDto)
    {
        var result = await _lawFirmService.CreateLawFirmAsync(createDto);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return CreatedAtAction(nameof(GetLawFirm), new { id = result.Data!.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<LawFirmDto>>> UpateLawFirm(int id, LawFirmUpdateDto updateDto)
    {
        var result = await _lawFirmService.UpdateLawFirmAsync(id, updateDto);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteLawFirm(int id)
    {
        var result = await _lawFirmService.DeleteLawFirmAsync(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpGet("featured")]
    public async Task<ActionResult<ApiResponse<IEnumerable<LawFirmDto>>>> GetFeaturedLawFirms()
    {
        var result = await _lawFirmService.GetFeaturedLawFirmsAsync();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}