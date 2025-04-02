using Microsoft.Data.SqlClient.DataClassification;

namespace WebApp1
{
    public class Program
    {
        //public static  int Add(int x,int y)
        //{
        //    return x + y;
        //    Second();
        //}
        //public static void Second()
        //{
            
        //}

        public static void Main(string[] args)
        {
            //Console.WriteLine("First Line");
            //int resutl= Add(10, 20);//<---

            //Console.WriteLine("Last Line");
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();//default setting

            var app = builder.Build();

            // Configure the HTTP request pipeline. using middleware
            #region Custom Middleware
            //name middleware
            //inline Middlware ==>anonums delegete Lambad Exprestion
            //app.Use(async (httpContext, nextMiddleware) => {
            //    //if(httpContext.Request.Headers.co)
            //    await httpContext.Response.WriteAsync("1) Middleware 1\n");
            //    await nextMiddleware.Invoke();//<----Wait call method
            //    await httpContext.Response.WriteAsync("1-1) Middleware 1-1\n");

            //});
            //app.Use(async (httpContext, nextMiddleware) => {
            //    await httpContext.Response.WriteAsync("2) Middleware 2\n");
            //    await nextMiddleware.Invoke();//<--Wait cal; next
            //    await httpContext.Response.WriteAsync("2-2) Middleware 2-2\n");

            //});

            //app.Run(async (httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("3) Terminate\n");
            //});

            #endregion


            #region Built in Middleware

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles(); //handel reuest static files "wwwroot"

            app.UseRouting();//mapping action && contoolrt

            app.UseAuthorization();//for remeber Permission Roles

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }

    }
}
