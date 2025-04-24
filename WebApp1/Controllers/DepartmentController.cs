using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using WebApp1.Repository;

namespace WebApp1.Controllers
{
    
    public class DepartmentController : Controller
    {
        //  CompanyContext companyContext = new CompanyContext();//most of action
        //DIP - IOC
        IDepartmentRepository DeptRepoitory;
        private readonly IEmployeeRepository empRepo;

        //ControllerFactory
        public DepartmentController(IDepartmentRepository deptREpo,IEmployeeRepository EmpRepo)//DI DP (dont create but inject (ask)
        {
            //DeptRepoitory = new DepartmentRepository();
            DeptRepoitory= deptREpo;//initlaiztiop
            empRepo = EmpRepo;
        }

        //endpoint url :\Department\ShowAll
        public IActionResult ShowAll()
        {
            //get data from model
            List<Department> deptList =
                DeptRepoitory.GetAll();
            //send data to view
            // return View("ShowAll");//go to view with name ShowAll  with no data Empty
            return View("ShowAll",deptList);//View Showall ,Model with type List<Deprtment>
        }

        public IActionResult Index()
        {
            List<Department> deptList = DeptRepoitory.GetAll();
            return View("Index", deptList);
        }
        ///Department/GetEmps?deptId=1 <summary>
        public IActionResult GetEmps(int deptId)
        {
            var empList= empRepo.GetByDeptId(deptId).Select(e=>new { e.Id,e.Name});
            return Json(empList);
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
                DeptRepoitory.Add(deptFromRequest);
                DeptRepoitory.Save();
                //Dry
                return RedirectToAction("ShowAll", "Department");
            }
            //return the same view
            return View("New", deptFromRequest);

        }

        #endregion
    }
}
