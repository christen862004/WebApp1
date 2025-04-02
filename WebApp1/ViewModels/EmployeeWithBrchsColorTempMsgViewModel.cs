namespace WebApp1.ViewModels
{
    public class EmployeeWithBrchsColorTempMsgViewModel
    {
        //Properties from Employee Model
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string DeptName { get; set; }

        //Some Extra Property Need To View Display
        public List<string> Branches { get; set; }
        public int Temp { get; set; }
        public string Color { get; set; }
        public string Message { get; set; }
    }
}
