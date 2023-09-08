using EmployeeApi.Model;

namespace EmployeeApi.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeViewModel> AddEmployeeAsysnc(EmployeeModel employee);
        Task<AttendanceViewModel> AddAttdanceAsysnc(AttendenceModel attendence);

        Task<EmployeeViewModel> GetThirdHightestSalaryAsync();
    }
}
