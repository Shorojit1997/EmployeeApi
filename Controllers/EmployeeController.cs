using EmployeeApi.Entity;
using EmployeeApi.Model;
using EmployeeApi.Repository;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EmployeeApi.Controllers
{

    public class EmployeeController : BaseApiController
    {

        protected readonly UnitOfService _unitOfServices;

        public EmployeeController( UnitOfWork unitOfWork, UnitOfService services) :base(unitOfWork) {
            _unitOfServices = services;
        }

        [HttpPost("AddEmployee")]
        public async Task<EmployeeViewModel> AddEmployee(EmployeeModel employee)
        {
            if(!ModelState.IsValid)
            {

                return new EmployeeViewModel()
                {
                    Status=400,
                    Success=false,
                    Error= new List<string>() {"Invalid Informations"}
                };
            }

            try
            {
                return await _unitOfServices.Employee.AddEmployeeAsysnc(employee);
            }
            catch (Exception ex)
            {
                return new EmployeeViewModel()
                {
                    Status = 400,
                    Success = false,
                    Error = new List<string>() { ex.Message }
                };
            }
        }

        [HttpPut("EditEmployee")]
        public async Task<EmployeeViewModel> EditEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {

                return new EmployeeViewModel()
                {
                    Status = 400,
                    Success = false,
                    Error = new List<string>() { "Invalid Informations" }
                };
            }

            try
            {
                var existingEmployee = await _unitOfWork.Employee.GetByIdAsync(employee.Id);
                if (existingEmployee != null)
                {
                    existingEmployee.Name = employee.Name??existingEmployee.Name;
                    existingEmployee.Code = employee.Code>0? employee.Code:existingEmployee.Code;
                }
                
                _unitOfWork.Employee.Update(employee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeViewModel()
                {
                    Status=200,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new EmployeeViewModel()
                {
                    Status = 400,
                    Success = false,
                    Error = new List<string>() { ex.Message }
                };
            }
        }


        [HttpPost("AddAttendence")]
        public async Task<AttendanceViewModel> AddAttendence(AttendenceModel attendance)
        {
            if (!ModelState.IsValid)
            {

                return new AttendanceViewModel()
                {
                    Status = 400,
                    Success = false,
                    Error = new List<string>() { "Invalid Informations" }
                };
            }

            try
            {
                return await _unitOfServices.Employee.AddAttdanceAsysnc(attendance);
            }
            catch (Exception ex)
            {
                return new AttendanceViewModel()
                {
                    Status = 400,
                    Success = false,
                    Error = new List<string>() { ex.Message }
                };
            }
        }



        [HttpGet("GetThirdHighestSalary")]
        public async Task<EmployeeViewModel> GetThirdHighestSalary()
        {
            try
            {
                return await _unitOfServices.Employee.GetThirdHightestSalaryAsync();
            }
            catch (Exception ex)
            {
                return new EmployeeViewModel()
                {
                    Status = 400,
                    Success = false,
                    Error = new List<string>() { ex.Message }
                };
            }
        }

        [HttpGet("GetEmployeeWhoHasNoAbsentRecored")]
        public async Task<EmployeeViewModel> GetEmployeeWhoHasNoAbsentRecored()
        {
            try
            {
                return await _unitOfServices.Employee.GetEmployeeWhoHasNoAbsentRecordAsync();
            }
            catch (Exception ex)
            {
                return new EmployeeViewModel()
                {
                    Status = 400,
                    Success = false,
                    Error = new List<string>() { ex.Message }
                };
            }
        }


        [HttpGet("GetMonthlyReport")]
        public async Task<MonthlyReportViewModel> GetMonthlyReport()
        {
            try
            {
                return await _unitOfServices.Employee.GetMonthlyReportAsync();
            }
            catch (Exception ex)
            {
                return new MonthlyReportViewModel()
                {
                    Status = 400,
                    Success = false,
                    Error = new List<string>() { ex.Message }
                };
            }
        }


        [HttpGet("GetEmployHierarchy")]
        public async Task<HierarchyModelView> GetEmployHierarchy(int id)
        {
            try
            {
                var employeeHierarchy= await _unitOfWork.Employee.GetEmployHierarchyAsync(id);
                return new HierarchyModelView()
                {
                    Status=200,
                    Success=true,
                    Hierarchy=employeeHierarchy
                };
            }
            catch (Exception ex)
            {
                return new HierarchyModelView()
                {
                    Status = 400,
                    Success = false,
                    Error = new List<string>() { ex.Message }
                };
            }
        }

    }
}
