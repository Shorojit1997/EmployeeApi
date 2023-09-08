using EmployeeApi.Data;
using EmployeeApi.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeApi.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDbContext context, ILogger logger) : base(context, logger)
        {

        }

        public async Task<List<Employee>> GetEmployeeWhoHasNoAbsentRecordAsync()
        {
            var employeesWithNoAbsentRecords = _context.Employees
           .Where(employee => !_context.Attendance.Any(att => att.EmployeeId == employee.Id && att.IsAbsent==true))
           .OrderByDescending(employee => employee.Salary)
           .ToList();

            return employeesWithNoAbsentRecords;
        }

        public async Task<List<Employee>> GetThirdHightestSalaryAsync()
        {
            return await _context.Employees.Select(em=>em)
                .Distinct( ).OrderByDescending(op=>op.Salary).Skip(2).Take(1).ToListAsync();
        }
    }
}
