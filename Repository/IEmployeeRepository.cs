using EmployeeApi.Entity;

namespace EmployeeApi.Repository
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        public Task<List<Employee>> GetEmployeeWhoHasNoAbsentRecordAsync();
        public Task<List<Employee>> GetThirdHightestSalaryAsync();
    }
}
