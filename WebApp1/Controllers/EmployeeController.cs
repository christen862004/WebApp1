using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using WebApp1.ViewModels;

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
        #region Details 
        //Employee/DEtails/1 ==>Route Segmant
        //Employee/DEtails?id=1 ==>Query string
        public IActionResult Details(int id)
        {
            //varaible get value from differnet data source
            int Temp = 20;
            string Message="Hello From BackEnd";
            List<string> brchs=new () { "Assiut" ,"Alex","Cairo", "Mansoura"};
            string Clr = "red";
            //fill viewData in Action (C#) Backend [Set]
            ViewData["Temp1"] = Temp;//boxing to object
            ViewData["Color"] = Clr;
            ViewData["Brch"]  = brchs;
            ViewData["Msg"] = Message;
            ViewBag.xyz = "ayhage";//ViewData["xyz"]="ayhage";
            ViewBag.Color = "Blue";
            
            Employee emp= companyContext.Employee.FirstOrDefault(e=>e.Id==id);
            return View("Details", emp);//view Details ,Model =Employee
        }


        public IActionResult DetailsVM(int id) {
            //collect data From Differnet REsource
            int Temp = 20;
            string Message = "Hello From BackEnd";
            List<string> brchs = new() { "Assiut", "Alex", "Cairo", "Mansoura" };
            string Clr = "red";
            Employee empModel = 
                companyContext.Employee.Include(e=>e.Department).FirstOrDefault(e => e.Id == id);
            //Declare ViewModel Object
            EmployeeWithBrchsColorTempMsgViewModel EmpVM = new();
            //Map source ==>desination (automapper)
            EmpVM.EmpName = empModel.Name;
            EmpVM.EmpAddress = empModel.Address;
            EmpVM.DeptName = empModel.Department.Name;//
            EmpVM.Temp = 20;
            EmpVM.Color = Clr;
            EmpVM.Branches = brchs;
            EmpVM.Message = Message;
            //send viewModel to view
            return View("DetailsVM", EmpVM);//View with name DetailsVM
                                               //,Model with type EmployeeWithBrchsColorTempMsgViewModel
           
         }
        #endregion

        #region    Edit
        public IActionResult Edit(int id)
        {
            Employee emp = companyContext.Employee.FirstOrDefault(e => e.Id == id);
            return View("Edit", emp);
        }
        [HttpPost]//edit | add
        public IActionResult SaveEdit(Employee empFromReq)
        {
            if(empFromReq.Name!=null && empFromReq.Salary > 7000)
            {
                //get old reference
                Employee empFromDB=
                    companyContext.Employee.FirstOrDefault(e => e.Id == empFromReq.Id);
                //change value
                empFromDB.Name = empFromReq.Name;
                empFromDB.Salary = empFromReq.Salary;
                empFromDB.Address = empFromReq.Address;
                empFromDB.ImageURL = empFromReq.ImageURL;
                empFromDB.DepartmentID = empFromReq.DepartmentID;
                //save Chnages
                companyContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", empFromReq);
        }
        #endregion
    }
}
