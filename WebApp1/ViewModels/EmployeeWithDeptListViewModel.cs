using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp1.Models;

namespace WebApp1.ViewModels
{
    public class EmployeeWithDeptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Current Address")]
        //[DataType(DataType.Password)]
        public string? Address { get; set; }

        public int Salary { get; set; }
        public string? ImageURL { get; set; }

        [Display(Name = "DEpartment - Id")]
        public int DepartmentID { get; set; }

        public List<Department>  DeptList { get; set; }

    }
}
