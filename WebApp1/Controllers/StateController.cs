using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class StateController : Controller
    {
        #region Cookie
        public IActionResult SetCookie(string name,int age)
        {
            //Session cookie
            HttpContext.Response.Cookies.Append("FirstName", name);//cookie brose

            //Presistent cookie
            CookieOptions cookieOption = new CookieOptions();
            cookieOption.Expires = DateTimeOffset.Now.AddDays(1);
            HttpContext.Response.Cookies.Append("Age", age.ToString(), cookieOption);//cookie brose

            return Content("Cookie Save");
        }

        public IActionResult GetCookie()
        {
            //logic
           string name= HttpContext.Request.Cookies["FirstName"];
           string age= HttpContext.Request.Cookies["Age"];
            //logi return view
            return Content($"name={name}\t age={age}");
        }

        #endregion

        #region Session
        public IActionResult SetSession()
        {
            //logic
            //store data write session per user
            //how store obj ==>json
            HttpContext.Session.SetString("name", "Ahmed");
            HttpContext.Session.SetInt32("age", 12);

            //logic
            return Content("Session Store Success");
            
        } 

        public IActionResult GetSession()
        {
            //logic
            //need info from session
            string n= HttpContext.Session.GetString("name");
            int? a =  HttpContext.Session.GetInt32("age");
            return Content($"Session Data {n}");
        }
        #endregion
        #region Test
        int counter;
        public StateController()
        {
            counter = 0;
        }
        public IActionResult incr()
        {
            counter++;
            return Content("Increamne");//state the last value
        }
        public IActionResult display()
        {
            
            return Content($"Increamne \t{counter}" );
        }
        #endregion
    }
}
