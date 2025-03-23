using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    
    public class DepartmentController : Controller
    {
        CompanyContext companyContext = new CompanyContext();//most of action

        //endpoint url :\Department\ShowAll
        public IActionResult ShowAll()
        {
            //get data from model
            List<Department> deptList= companyContext.Department.AsNoTracking().ToList();
            //send data to view
            // return View("ShowAll");//go to view with name ShowAll  with no data Empty
            return View("ShowAll",deptList);//View Showall ,Model with type List<Deprtment>
        }
    }
}
