namespace EmployeeApi.Model
{
    public class BaseViewModel
    {
        public int Status { get; set; }

        public bool  Success { get; set; }=false;

        public ICollection<string> Error { get; set; }=new List<string>();
    }
}
