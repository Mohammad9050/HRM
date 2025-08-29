using HRM.Application.Interfaces;
//using HRM.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using HRM.Domain.Entities;
using HRM.Infrastructure.Persistence.Models;
using DomainDepartment = HRM.Domain.Entities.Department;
using DbDepartment = HRM.Infrastructure.Persistence.Models.Department;

namespace HRM.Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly HrmContext _context;

    public DepartmentRepository(HrmContext context)
    {
        _context = context;
    }

    public async Task<List<DomainDepartment>> GetAllAsync()
                => await _context.Departments
            .Select(e => new DomainDepartment
            {
                Id = e.Id,
                Name = e.Name,
             
            })
            .ToListAsync();


    public async Task<DomainDepartment?> GetByIdAsync(int id)
    {
        var e = await _context.Departments.FindAsync(id);
        if (e == null) return null;

        return new DomainDepartment
        {
            Id = e.Id,
            Name = e.Name,
      
        };
    }


    public async Task AddAsync(DomainDepartment Department)
    {
        {
            var dbDepartment = new DbDepartment
            {
                Name = Department.Name,

            };

            _context.Departments.Add(dbDepartment);
            await _context.SaveChangesAsync();
        }
    }
}
