namespace HRM.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly HireDate { get; set; }   // بهتره به جای DateOnly اینجا DateTime بذاری
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
}
