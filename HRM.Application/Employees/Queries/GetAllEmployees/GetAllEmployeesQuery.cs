using MediatR;
using HRM.Application.DTOs;

namespace HRM.Application.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesQuery : IRequest<List<EmployeeDto>>
{
}
