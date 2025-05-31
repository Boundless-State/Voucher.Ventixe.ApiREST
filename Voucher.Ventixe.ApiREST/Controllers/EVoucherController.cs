using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Voucher.Ventixe.ApiREST.Models;
using Voucher.Ventixe.ApiREST.Services;

namespace Voucher.Ventixe.ApiREST.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EVoucherController : ControllerBase
{
    private readonly EVoucherService _service;

    public EVoucherController(EVoucherService service)
    {
        _service = service;
    }

    /// <summary>
    /// Hämtar alla e-vouchers.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<EVoucherDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    /// <summary>
    /// Hämtar en specifik e-voucher via dess ID.
    /// </summary>
    /// <param name="id">E-voucher ID</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<EVoucherDto>> GetById(string id)
    {
        var result = await _service.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Skapar en ny e-voucher.
    /// </summary>
    /// <param name="dto">Data för att skapa e-voucher</param>
    [HttpPost]
    public async Task<ActionResult<EVoucherDto>> Create(CreateEVoucherDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Uppdaterar en befintlig e-voucher.
    /// </summary>
    /// <param name="id">E-voucher ID</param>
    /// <param name="dto">Uppdaterad data</param>
    [HttpPut("{id}")]

    public async Task<IActionResult> Update(string id, UpdateEVoucherDto dto)
    {
        var success = await _service.UpdateAsync(id, dto);
        return success ? NoContent() : NotFound();
    }

    /// <summary>
    /// Tar bort en e-voucher.
    /// </summary>
    /// <param name="id">E-voucher ID</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}
