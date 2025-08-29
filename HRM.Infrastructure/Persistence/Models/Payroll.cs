using System;
using System.Collections.Generic;

namespace HRM.Infrastructure.Persistence.Models;

public partial class Payroll
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int Year { get; set; }

    public int Month { get; set; }

    public decimal BaseSalary { get; set; }

    public decimal Deductions { get; set; }

    public decimal? NetSalary { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
