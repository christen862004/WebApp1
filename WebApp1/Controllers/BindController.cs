using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class BindController : Controller
    {
        //Primitive type parmeter (int ,float ,string)
        //Bind/TestPrimitive?name=Ahmed&age=12&id=1
        //Bind/TestPrimitive/1?name=Ahmed&age=12&color=red
        //bind/TestPrimitive/11?color[1]=red&color[0]=blue
        public IActionResult TestPrimitive(int age,string name,int id,string[] Color)
        {
           
            return Content("ok");
        }


        //Collection ( List ,Dictionary)
        //Bind/TestDic?name=christen&phones[ahmed]=123&phones[mohamed]=456
        public IActionResult TestDic(Dictionary<string,string> phones,string name)
        {
            return Content("Ok");
        }

        //Test Complex[Custom] Class
        //Bind/TestObj/12?name=.net&ManagerName=Ahmed&Employee[0].Name=alaa
        //public IActionResult TestObj(int Id,string Name,string ManagerName,List<Employee> Employee)
        public IActionResult TestObj(Department dept)
        {    
            return Content("Ok");

        }
    }
}
