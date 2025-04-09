using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name="Current Address")]
        //[DataType(DataType.Password)]
        public string? Address { get; set; }

        public int Salary { get; set; }
        public string? ImageURL { get; set; }
        
        [ForeignKey("Department")]
        [Display(Name="DEpartment - Id")]
        public int DepartmentID { get; set; }

        public virtual Department? Department { get; set; }
    }
}
