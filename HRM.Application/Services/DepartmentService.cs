using HRM.Application.Interfaces;
using HRM.Domain.Entities;


namespace HRM.Application.Services;

public class DepartmentService
{
    private readonly IDepartmentRepository _repository;

    public DepartmentService(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Department>> GetDepartmentsAsync()
        => await _repository.GetAllAsync();

    public async Task AddDepartmentAsync(string name)
    {
        var Department = new Department
        {
            Name = name
        };
        await _repository.AddAsync(Department);
    }
}