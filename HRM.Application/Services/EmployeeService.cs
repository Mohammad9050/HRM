
using HRM.Domain.Entities;
using HRM.Domain.Interfaces.Repositories;


namespace HRM.Application.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Employee>> GetEmployeesAsync()
        => await _repository.GetAllAsync();

    public async Task AddEmployeeAsync(string firstName, string lastName, DateOnly hireDate, decimal salary, int departmentId)
    {
        var employee = new Employee
        {
            FirstName = firstName,
            LastName = lastName,
            HireDate = hireDate,
            Salary = salary,
            DepartmentId = departmentId
        };
        await _repository.AddAsync(employee);
    }
}
