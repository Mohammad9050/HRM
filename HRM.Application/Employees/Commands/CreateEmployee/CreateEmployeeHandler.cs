using HRM.Application.Interfaces;
using MediatR;
using HRM.Domain.Entities;

namespace HRM.Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IEmployeeRepository _repository;

    public CreateEmployeeHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Salary = request.Salary,
            DepartmentId = request.DepartmentId
        };

        await _repository.AddAsync(employee);

        return employee.Id;
    }
}
