using System.Reflection.Metadata.Ecma335;

namespace EmployeeApi.Entity
{

    public class Attendance:BaseEntity
    {
        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool? IsPresent { get; set; } = false;

        public bool? IsAbsent { get; set; } = false;

        public bool? IsOffDay { get; set; } = false;

        
    }
}
