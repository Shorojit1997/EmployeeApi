using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Model
{
    public class EmployeeModel
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public int Code { get; set; }
        public double? Salary { get; set; }
    }
}
