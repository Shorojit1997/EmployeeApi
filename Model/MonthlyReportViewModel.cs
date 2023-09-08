namespace EmployeeApi.Model
{
    public class MonthlyReportViewModel:BaseViewModel
    {
        public List<MonthlyReportModel> Empoyees { get; set; } = new List<MonthlyReportModel>() { };
    }
}
