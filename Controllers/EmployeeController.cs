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


        [HttpGet("GetAll")]
        public List<Employee> GetALl()
        {
            List<Employee> list = new List<Employee>(){};

       

            return list;
        }


        [HttpGet("Get")]
        public List<Employee> Get()
        {
            List<Employee> list = new List<Employee>() { };
            return list;
        }

    }
}
