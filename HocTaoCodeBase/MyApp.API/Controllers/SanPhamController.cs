using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Services;

namespace MyApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SanPhamController : ControllerBase
{
    private readonly ISanPhamService _service;

    public SanPhamController(ISanPhamService service)
    {
        _service = service;
    }

    // GET: api/sanpham
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var data = await _service.GetAllAsync(ct);
        return Ok(data);
    }

    // GET: api/sanpham/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct)
    {
        var item = await _service.GetByIdAsync(id, ct);
        if (item == null)
            return NotFound();

        return Ok(item);
    }

    // POST: api/sanpham
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateSanPhamRequest request,
        CancellationToken ct)
    {
        var id = await _service.CreateAsync(request, ct);

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            null);
    }

    // PUT: api/sanpham/5/gia
    [HttpPut("{id:int}/gia")]
    public async Task<IActionResult> UpdateGia(
        int id,
        [FromBody] int giaMoi,
        CancellationToken ct)
    {
        try
        {
            await _service.UpdateGiaAsync(id, giaMoi, ct);
            return NoContent();
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }

    // DELETE: api/sanpham/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _service.DeleteAsync(id, ct);
        return NoContent();
    }
}