
using HRM.Domain.Entities;

namespace HRM.Domain.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task AddAsync(Department department);
        Task<Department?> GetByIdAsync(int id);
        Task<List<Department>> GetAllAsync();
        Task UpdateAsync(Department department);
        Task DeleteAsync(Department department);
        Task SaveChangesAsync();
    }
}
