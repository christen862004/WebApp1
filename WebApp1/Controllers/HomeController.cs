using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    //1) name of this class Sufixx end with Controller
    //2) Inherit from Controller
    public class HomeController : Controller
    {
        /// 1) Method Must Be Public 
        /// 2) Method Cant Be Static 
        /// 3) MEthod Cant Overload (only in One Case)
        
        //endpoint:URL==>Action Class
        //Home/TestMsg
        public ContentResult TestMsg()
        {
            //......
            //decalre
            ContentResult result = new ContentResult();
            //set
            result.Content = "Msg From Action To View";
            //return 
            return result;
        }
        //Home/TestView
        public ViewResult TestView()
        {
            //logic ......
            return View("View1");

        }

        //Home/TestMix?no=10&name=ahmed&id=1
        //Home/TestMix/1?no=10&name=ahmed&

        public IActionResult  TestMix(int no)//,string name,int id)
        {
            if (no % 2 == 0)
            {
                //logic
                return View("View1");
            }
            else
            {
                
                return Content("My Content From View");
            }
        }

        //ViewResult View(string viewName)
        //{
        //    ViewResult result = new ViewResult();
        //    //set Data
        //    result.ViewName = viewName;
        //    //retsurn
        //    return result;
        //}

        /// <summary>
        /// Action can resturn Types
        /// 1) string     ==> ContentResult   ==> Content
        /// 2) View       ==> ViewResult      ==>View
        /// 3) Josn       ==> JsonResult      ==>Json
        /// 4) NotFound    => NotFoundResult  ==>NotFound
        /// 5) Unauthorize==> UnAuthorizeReult==>Unauth
        /// </summary>









        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
