using HRM.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _service;

    public EmployeeController(EmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
        => Ok(await _service.GetEmployeesAsync());

    [HttpPost]
    public async Task<IActionResult> AddEmployee(EmployeeDto dto)
    {
        await _service.AddEmployeeAsync(dto.FirstName, dto.LastName, dto.HireDate, dto.Salary, dto.departmentId);
        return Ok("Employee added successfully.");
    }
}

public record EmployeeDto(string FirstName, string LastName, DateOnly HireDate, decimal Salary, int departmentId);
