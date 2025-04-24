using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class RouteController : Controller
    {
        //Route/Method1?age=10
        //r1 not found
        //r1/10/alaa
        //r1/27/Ahmed
        [Route("r1/{age:int}/{name?}")]//default
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
