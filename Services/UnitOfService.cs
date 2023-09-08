using EmployeeApi.Data;
using EmployeeApi.Entity;
using EmployeeApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Services
{
    public class UnitOfService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public IEmployeeService Employee { get; private set; }

        public UnitOfService(UnitOfWork _unitofWork, ILoggerFactory loggerFactory)
        {
            _unitOfWork = _unitofWork;
            _logger = loggerFactory.CreateLogger<UnitOfWork>();
            Employee = new EmployeeServices(_unitofWork);

        }
    }

}
