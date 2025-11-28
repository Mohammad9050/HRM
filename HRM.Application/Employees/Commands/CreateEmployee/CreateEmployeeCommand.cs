using MediatR;

namespace HRM.Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommand : IRequest<int>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
}
