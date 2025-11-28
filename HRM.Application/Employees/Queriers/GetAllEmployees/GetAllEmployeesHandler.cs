using MediatR;
using HRM.Application.DTOs;
using HRM.Application.Interfaces;

namespace HRM.Application.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>
{
    private readonly IEmployeeRepository _repository;

    public GetAllEmployeesHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _repository.GetAllAsync();

        return employees.Select(e => new EmployeeDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Salary = e.Salary,
            DepartmentId = e.DepartmentId
        }).ToList();
    }
}
