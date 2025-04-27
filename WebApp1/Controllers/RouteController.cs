using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp1.Filtters;

namespace WebApp1.Controllers
{
    //15 14 authorize ,1 all gust
    //[Authorize]
    [HandelError]//controller scop (all action inside this controller)
    public class RouteController : Controller
    {

        //Route/test1
        //[HandelError]
        
        public IActionResult test1()
        {
            //return View("Error");
            throw new Exception("Error HAppen");
        }
        //[HandelError]
        
        public IActionResult test2()
        {
            throw new Exception("Error HAppen");
        }
        //Route/Method1?age=10
        //r1 not found
        //r1/10/alaa
        //r1/27/Ahmed
        [Route("r1/{age:int}/{name?}")]//default
        //type action
        public IActionResult Method1(int age,string name)
        {
          
            return Content("Method1");
        }
        //r2
        public IActionResult Method2()
        {
            return Content("Method2");

        }
    }
}
