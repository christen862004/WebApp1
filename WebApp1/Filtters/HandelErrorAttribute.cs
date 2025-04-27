using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp1.Filtters
{
    public class HandelErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //handel Exception control return (exception - Content - view)
            //ContentResult result = new ContentResult();
            //result.Content = context.Exception.Message;//"Some Eception happen";
            ViewResult result=new ViewResult();
            result.ViewName = "Error";//Shared
            
            context.Result = result;//handel exception
        }
    }
}
