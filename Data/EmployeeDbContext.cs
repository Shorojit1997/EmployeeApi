using EmployeeApi.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeApi.Data
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendance { get; set; }

    }
}
