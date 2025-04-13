using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp1.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp1.ViewModels
{
    public class EmployeeWithDeptListViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name Requied")]
        [MinLength(3,ErrorMessage ="Name Must be more than 3 char")]
        [MaxLength(25,ErrorMessage ="NAme Must Be Less Than 25 char")]
        [Unique]//(xyz ="value")]
        public string Name { get; set; }

        [Display(Name = "Current Address")]
        //[DataType(DataType.Password)]
        public string? Address { get; set; }

        //[Range(7000,50000)]
        //[Even]
        [Remote("CheckSalary","Employee",AdditionalFields = "Address")]//server side using url using ajax
        public int Salary { get; set; }

        [RegularExpression(@"\w*\.(jpg|png)",ErrorMessage ="Image Must be png or jpg")]//lklkl*jpg || jhjh.png
        public string? ImageURL { get; set; }

        [Display(Name = "DEpartment - Id")]
        public int DepartmentID { get; set; }
     
        public List<Department>?  DeptList { get; set; }

    }
}
