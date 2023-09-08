using EmployeeApi.Data;
using EmployeeApi.Entity;
using EmployeeApi.Model;
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
            var absentEmployeeIds = await _context.Attendance
          .Where(att => att.IsAbsent == true)
          .Select(att => att.EmployeeId)
          .ToListAsync();

           
            var employeesWithNoAbsentRecord = await _context.Employees
                .Where(emp => !absentEmployeeIds.Contains(emp.Id))
                .ToListAsync();

            if(employeesWithNoAbsentRecord != null ) {
                return employeesWithNoAbsentRecord;
            }
            else
                return new List<Employee>();

        }

        public async Task<string> GetEmployHierarchyAsync(int employeeId)
        {
            string hierarchy = "";

            while (true)
            {
                var employee = await _context.Employees
                    .Where(emp => emp.Id == employeeId)
                    .FirstOrDefaultAsync();

                if (employee == null)
                {
                    break;
                }

                hierarchy =  (string.IsNullOrEmpty(hierarchy) ? "" : hierarchy+ " -> ") + employee.Name ;

                if (employee.SuperVisorId == null)
                {
                    break;
                }

                employeeId = employee.SuperVisorId.Value;
            }

            return hierarchy;
        }


        public async Task<List<MonthlyReportModel>> GetMonthlyReportAsync()
        {
            var currentDate = DateTime.Now;
            var startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var employees = await _context.Employees.ToListAsync();

            List<MonthlyReportModel> monthlyReportModels = new List<MonthlyReportModel>();

            foreach(var employee in employees)
            {
                var totalPresent = await _context.Attendance
                   .CountAsync(att => att.EmployeeId == employee.Id && att.AttendanceDate >= startDate && att.AttendanceDate <= endDate && att.IsPresent == true);
                var totalAbsent = await _context.Attendance
                    .CountAsync(att => att.EmployeeId == employee.Id && att.AttendanceDate >= startDate && att.AttendanceDate <= endDate && att.IsAbsent == true);

                var totalOffDay = await _context.Attendance
                    .CountAsync(att => att.EmployeeId == employee.Id && att.AttendanceDate >= startDate && att.AttendanceDate <= endDate && att.IsOffDay == true);
            
                var newMonth= new MonthlyReportModel
                {
                    EmployeeName = employee.Name,
                    MonthName = startDate.ToString("MMMM"),
                    Salary = employee.Salary,
                    TotalPresent = totalPresent,
                    TotalAbsent = totalAbsent,
                    TotalOffDay = totalOffDay
                };
                monthlyReportModels.Add(newMonth);
            }

          
            return monthlyReportModels;
        }



        public async Task<List<Employee>> GetThirdHightestSalaryAsync()
        {
            var thirdHighestSalary = await _context.Employees
                .OrderByDescending(employee => employee.Salary)
                .Select(employee => employee.Salary)
                .Distinct()
                .Skip(2)
                .Take(1)
                .FirstOrDefaultAsync();

            if (thirdHighestSalary != null)
            {
                var employeesWithThirdHighestSalary = await _context.Employees
                    .Where(employee => employee.Salary == thirdHighestSalary)
                    .ToListAsync();

                return employeesWithThirdHighestSalary;
            }
            else
            {
                return new List<Employee>(); 
            }
        }

      
    }
}
