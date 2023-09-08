namespace EmployeeApi.Model
{
    public class AttendenceModel
    {
        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool? IsPresent { get; set; } = false;

        public bool? IsAbsent { get; set; } = false;

        public bool? IsOffDay { get; set; } = false;
    }
}
