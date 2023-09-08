using EmployeeApi.Entity;
using EmployeeApi.Model;

namespace EmployeeApi.Repository
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        Task<List<Employee>> GetEmployeeWhoHasNoAbsentRecordAsync();
        Task<List<Employee> > GetThirdHightestSalaryAsync();

        Task<List<MonthlyReportModel>> GetMonthlyReportAsync();

        Task<string> GetEmployHierarchyAsync(int employeeId);
    }
}
