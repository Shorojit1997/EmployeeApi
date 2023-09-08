using EmployeeApi.Repository;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly ILogger<BaseApiController> _logger;
        protected readonly UnitOfWork _unitOfWork;
        public BaseApiController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
