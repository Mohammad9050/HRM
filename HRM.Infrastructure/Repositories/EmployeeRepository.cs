using HRM.Application.Interfaces;
//using HRM.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using HRM.Domain.Entities;
using HRM.Infrastructure.Persistence.Models;
using DomainEmployee = HRM.Domain.Entities.Employee;
using DbEmployee = HRM.Infrastructure.Persistence.Models.Employee;

namespace HRM.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly HrmContext _context;

    public EmployeeRepository(HrmContext context)
    {
        _context = context;
    }

    public async Task<List<DomainEmployee>> GetAllAsync()
                => await _context.Employees
            .Select(e => new DomainEmployee
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                HireDate = e.HireDate,
                Salary = e.Salary
            })
            .ToListAsync();


    public async Task<DomainEmployee?> GetByIdAsync(int id)
    {
        var e = await _context.Employees.FindAsync(id);
        if (e == null) return null;

        return new DomainEmployee
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            HireDate = e.HireDate,
            Salary = e.Salary
        };
    }


    public async Task AddAsync(DomainEmployee employee)
    {
        {
            var dbEmployee = new DbEmployee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                HireDate = employee.HireDate,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId
            };

            _context.Employees.Add(dbEmployee);
            await _context.SaveChangesAsync();
        }
    }
}
