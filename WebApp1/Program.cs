using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using WebApp1.Repository;

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
            //1) sevice already defined alsread Register contrinaer
            //2) sevice already defined need to Register container
            builder.Services.AddControllersWithViews();//default setting
            builder.Services.AddSession(options=>
            { 
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
          
            builder.Services.AddDbContext<CompanyContext>(
                option=>option.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
                );//call companycontext parmeter constructor



            //3) service developer define and register   
            //register determin life time (create)
            builder.Services.AddScoped<ITEstREpository, TestRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            
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

            app.UseRouting();//mapping action && controller "Security Boy"
            
            app.UseSession();


            app.UseAuthorization();//for remeber Permission Roles
                      #region Custom Route
            //Staff define execute
                                   //custom route 
                                   //Nameing converntion Route(MVC)
                                   //Route Attribute (Web aPI)
           
            //app.MapControllerRoute("Rout1", "r1/{age:int:range(20,60)}/{name:maxlength(10):minlength(3)}",
            //app.MapControllerRoute("Rout1", "r1/{age:int:range(20,60)}/{name?}",
            #endregion

            //r1/method1
            //r1/Method2
            //app.MapControllerRoute("Rout1", "{contorller}/{action}",
            //    new {controller="Route",action="Method1"});


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }

    }
}
