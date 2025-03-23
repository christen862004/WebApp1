using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyContext companyContext = new CompanyContext();
        //class/method
        public IActionResult Index()
        {
            List<Employee> EmpList= 
                companyContext.Employee.ToList();
            return View("Index",EmpList); //view = index ,Model ==>List<Employee> 
        }
        //Employee/DEtails/1
        //Employee/DEtails?id=1
        public IActionResult Details(int id)
        {
            Employee emp= companyContext.Employee.FirstOrDefault(e=>e.Id==id);
            return View("Details", emp);//view Details ,Model =Employee
        }
    }
}
