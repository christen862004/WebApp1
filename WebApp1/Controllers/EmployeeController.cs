using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using WebApp1.Repository;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
{
    public class EmployeeController : Controller
    {
        //CompanyContext companyContext = new CompanyContext();
        IEmployeeRepository EmpRepository;
        IDepartmentRepository DEptRepository;
        //create controllerFactore
        public EmployeeController(IDepartmentRepository deptRepo,IEmployeeRepository empRepo)
        {
            EmpRepository = empRepo;
            DEptRepository = deptRepo;
        }
        //class/method
        public IActionResult Index()
        {
            List<Employee> EmpList =   EmpRepository.GetAll();
            return View("Index",EmpList); //view = index ,Model ==>List<Employee> 
        }

        public IActionResult CheckSalary(int Salary,string Address)
        {
            if (Salary > 7000)
                return Json(true);
            else
                return Json(false);
        }

        #region Return Emp card PArtial
        public IActionResult GetEmpCard(int id)
        {
            Employee emp = EmpRepository.GetById(id);
            return PartialView("_EmpCardPartial", emp);
        }


        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            Employee emp = EmpRepository.GetById(id); 
            return View("Delete", emp);
        }
        #endregion


        #region NEw USing Tag Helper
        // [Authorize]
        public IActionResult New() {
           // ViewData["deptList"] = companyContext.Department.ToList();
           // ViewData["deptList"] = companyContext.Department.ToList();

            EmployeeWithDeptListViewModel empViewModel=new
                EmployeeWithDeptListViewModel();
            // Employee emp = empViewModel;
            empViewModel.DeptList = DEptRepository.GetAll(); ;
            return View("New", empViewModel);  //New ,Model with type EmployeeWithDeptListViewModel
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//post
        public IActionResult SaveNew(EmployeeWithDeptListViewModel empFromReq)
        {
            //if(empFromReq.Name != null && empFromReq.ImageURL!=null && empFromReq.Salary > 7000) {
            if (ModelState.IsValid == true)
            {
                try
                {
                    Employee newEmp = new()
                    {
                        ImageURL = empFromReq.ImageURL,
                        Name = empFromReq.Name,
                        Salary = empFromReq.Salary,
                        Address = empFromReq.Address,
                        DepartmentID = empFromReq.DepartmentID
                    };

                    EmpRepository.Add(newEmp);
                    EmpRepository.Save();
                    return RedirectToAction("Index", "Employee");
                }catch(Exception ex)
                {
                    //action scop i can add error
                    //ModelState.AddModelError("DepartmentID", "Please Select Department");
                    ModelState.AddModelError("other", ex.InnerException.Message);
                }
            }
            empFromReq.DeptList = DEptRepository.GetAll();

            return View("New", empFromReq);
        }
        #endregion


        #region Details 
        //Employee/DEtails/1?name=ahmed ==>Route Segmant
        //Employee/DEtails?id=1 ==>Query string
        public IActionResult Details(int id ,string name)
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

            Employee emp = EmpRepository.GetById(id); // companyContext.Employee.FirstOrDefault(e=>e.Id==id);
            return View("Details", emp);//view Details ,Model =Employee
        }


        public IActionResult DetailsVM(int id) {
            
            //collect data From Differnet REsource
            int Temp = 20;
            Temp.GetHashCode()
            string Message = "Hello From BackEnd";
            List<string> brchs = new() { "Assiut", "Alex", "Cairo", "Mansoura" };
            string Clr = "red";
            Employee empModel = EmpRepository.GetById(id);
                //companyContext.Employee.Include(e=>e.Department).FirstOrDefault(e => e.Id == id);
            //Declare ViewModel Object
            EmployeeWithBrchsColorTempMsgViewModel EmpVM = new();
            //Map source ==>desination (automapper)
            EmpVM.EmpName = empModel.Name;
            EmpVM.EmpAddress = empModel.Address;
            //EmpVM.DeptName = empModel.Department.Name;//
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
            Employee emp = EmpRepository.GetById(id);
            return View("Edit", emp);
        }
       
        
        [HttpPost]//edit | add
        public IActionResult SaveEdit(Employee empFromReq)
        {
            if(empFromReq.Name!=null && empFromReq.Salary > 7000)
            {

                EmpRepository.Update(empFromReq);
                EmpRepository.Save();
                //get old reference
                //Employee empFromDB=
                //    EmpRepository.GetById(empFromReq.Id);
                ////change value
                //empFromDB.Name = empFromReq.Name;
                //empFromDB.Salary = empFromReq.Salary;
                //empFromDB.Address = empFromReq.Address;
                //empFromDB.ImageURL = empFromReq.ImageURL;
                //empFromDB.DepartmentID = empFromReq.DepartmentID;
                ////save Chnages
                //companyContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", empFromReq);
        }
        #endregion
    }
}
