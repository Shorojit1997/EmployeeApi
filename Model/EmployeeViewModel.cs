using EmployeeApi.Entity;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Model
{
    public class EmployeeViewModel:BaseViewModel
    {
        public List<EmployeeModel>? Employees { get; set; } = new List<EmployeeModel>();

    }
}
