using EmployeeApi.Entity;
using EmployeeApi.Model;
using EmployeeApi.Repository;
using Microsoft.Identity.Client;

namespace EmployeeApi.Services
{



    public class EmployeeServices : IEmployeeService
    {
        protected readonly UnitOfWork _unitOfWork;
        public EmployeeServices(UnitOfWork unitOfWork) {
              _unitOfWork = unitOfWork;
        }

        public async Task<AttendanceViewModel> AddAttdanceAsysnc(AttendenceModel attendence)
        {
            Attendance newAttdence = new Attendance()
            {
                EmployeeId = attendence.EmployeeId,
                AttendanceDate = DateTime.Now,
                IsPresent = attendence.IsPresent,
                IsAbsent = attendence.IsAbsent,
                IsOffDay = attendence.IsOffDay,
             };

            await _unitOfWork.Attendance.AddAsync(newAttdence);
            await _unitOfWork.CompleteAsync();

            return new AttendanceViewModel() {
                Status=100,
                Success = true,
            };
        }

        public async Task<EmployeeViewModel> AddEmployeeAsysnc(EmployeeModel employee)
        {
            Employee newEmployee = new Employee()
            {
                Name = employee.Name,
                Salary = employee.Salary,
                Code = employee.Code,
            };

            await _unitOfWork.Employee.AddAsync(newEmployee);
            await _unitOfWork.CompleteAsync();


            EmployeeViewModel viewModel= new EmployeeViewModel()
            {
                Status = 200,
                Success = true,
            };

            return viewModel;

        }

        public async Task<EmployeeViewModel> GetEmployeeWhoHasNoAbsentRecordAsync()
        {
            var employee=await _unitOfWork.Employee.GetEmployeeWhoHasNoAbsentRecordAsync();
            var newEmployee = new EmployeeViewModel()
            {
                Status = 100,
                Success = true,
                Employees = employee
                .Select(employee => new EmployeeModel()
                { Name = employee.Name, Salary = employee.Salary, Code = employee.Code }).ToList(),
            };

            return newEmployee;
        }

        public async Task<MonthlyReportViewModel > GetMonthlyReportAsync()
        {
            var employee= await _unitOfWork.Employee.GetMonthlyReportAsync();

            var newEmployee = new MonthlyReportViewModel()
            {
                Status=200,
                Success = true,
                Empoyees=employee
            };

            return newEmployee;
        }

        public async Task<EmployeeViewModel> GetThirdHightestSalaryAsync()
        {
            var employee= await _unitOfWork.Employee.GetThirdHightestSalaryAsync();
            var newEmployee = new EmployeeViewModel()
            {
                Status=100,
                Success = true,
                Employees= employee
                .Select(employee=> new EmployeeModel() 
                {Name = employee.Name, Salary = employee.Salary,Code=employee.Code }).ToList(),
            };
            

            return newEmployee;
        }
    }
}
