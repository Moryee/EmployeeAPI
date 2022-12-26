using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Models;

public class EmployeeDBContext : DbContext
{
    public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employee { get; set; } = null!;
}