namespace EmployeeApi.Model
{
    public class MonthlyReportModel
    {
        public string EmployeeName { get; set; }

        public string?   MonthName { get; set; }

        public double? Salary { get; set; } = 0;

        public int? TotalAbsent { get; set; } = 0;
        public int? TotalPresent { get; set; } = 0;
        public int? TotalOffDay{ get; set; } = 0;

    }
}
