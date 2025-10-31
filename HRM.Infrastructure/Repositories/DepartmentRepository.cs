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
    {
        var query = from d in _context.Departments
                    join employee in _context.Employees on d.Id equals employee.DepartmentId into _employee
                    from employee in _employee.DefaultIfEmpty()
                    //let totalSalary = (from e in _context.Employees
                    //                   where e.DepartmentId == d.Id select e.Salary).Sum()
             
                    select new DomainDepartment
                    {
                        Id = d.Id,
                        Name = d.Name,
                        employeeName = employee.FirstName + ' ' + employee.LastName,
                       // sumSalary = totalSalary
                    };

        return await query.ToListAsync();
    }


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
            var tran = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

            try
            {

                var dbDepartment = new DbDepartment
                {
                    Name = Department.Name,

                };

                var dbDepartment2 = new DbDepartment
                {
                    Name = Department.Name + "Sample",

                };

                _context.Departments.Add(dbDepartment);
                _context.Departments.Add(dbDepartment2);

                await _context.SaveChangesAsync();
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }

            
           
        }
    }
}
