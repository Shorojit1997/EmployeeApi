using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApi.Entity
{
    public class Employee:BaseEntity
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public int Code { get; set; }
        public double?  Salary { get; set; }

        public int?  SuperVisorId { get; set; }

        public IList<Attendance> MyAttendance { get; set; }

    }
}
