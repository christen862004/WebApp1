using System.ComponentModel.DataAnnotations;
using WebApp1.ViewModels;

namespace WebApp1.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        public string xyz { get; set; }
        //public override bool IsValid(object? value)
        //{
        //    return base.IsValid(value);
        //}
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string name = value.ToString();

            var  empFromRequest=
                validationContext.ObjectInstance as EmployeeWithDeptListViewModel;


            CompanyContext context = 
                validationContext.GetRequiredService<CompanyContext>(); //new CompanyContext();

            Employee empFromDataBase = 
                context.Employee
                .FirstOrDefault(e => e.Name == name && e.DepartmentID==empFromRequest.DepartmentID);
            if(empFromDataBase == null) {
                return ValidationResult.Success;
            }
            //invalid name
            return new ValidationResult("Name Already Exist:)");
        }
    }
}
