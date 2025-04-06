using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    
    public class DepartmentController : Controller
    {
        CompanyContext companyContext = new CompanyContext();//most of action

        public DepartmentController()
        {
            
        }

        //endpoint url :\Department\ShowAll
        public IActionResult ShowAll()
        {
            //get data from model
            List<Department> deptList= 
                companyContext.Department.AsNoTracking().ToList();
            //send data to view
            // return View("ShowAll");//go to view with name ShowAll  with no data Empty
            return View("ShowAll",deptList);//View Showall ,Model with type List<Deprtment>
        }

        #region New
        public IActionResult New()
        {
            return View("New");//Model Null
        }
        ///Department/SaveNew?Name=.net&ManagerName=ahmed <summary>
        //any action can handel get | post
        [HttpPost]
        public IActionResult SaveNew(Department deptFromRequest)//string NAme,string ManagerName)
        {
            if (deptFromRequest.Name != null)
            {
                companyContext.Department.Add(deptFromRequest);
                companyContext.SaveChanges();
                //Dry
                return RedirectToAction("ShowAll", "Department");
            }
            //return the same view
            return View("New", deptFromRequest);

        }

        #endregion
    }
}
