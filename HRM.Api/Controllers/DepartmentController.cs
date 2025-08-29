using HRM.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentService _service;

    public DepartmentController(DepartmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartments()
        => Ok(await _service.GetDepartmentsAsync());

    [HttpPost]
    public async Task<IActionResult> AddDepartment(DepartmentDto dto)
    {
        await _service.AddDepartmentAsync(dto.Name);
        return Ok("Department added successfully.");
    }
}

public record DepartmentDto(string Name);
