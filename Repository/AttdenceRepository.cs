using EmployeeApi.Data;
using EmployeeApi.Entity;

namespace EmployeeApi.Repository
{
    public class AttdenceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttdenceRepository(EmployeeDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
