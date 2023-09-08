using EmployeeApi.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeApi.Repository
{
    public class UnitOfWork:IDisposable
    {
        private readonly EmployeeDbContext _context;
        private readonly ILogger _logger;
        public IEmployeeRepository Employee { get; private set; }
        public IAttendanceRepository Attendance { get; private set; }

        public UnitOfWork(EmployeeDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<UnitOfWork>();
            Employee = new EmployeeRepository(context, _logger);
            Attendance = new AttdenceRepository(context, _logger);

        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
