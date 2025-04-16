using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using WebApp1.Repository;

namespace WebApp1.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ITEstREpository testRepo;

        public ServiceController(ITEstREpository testRepo)//injection
        {
            this.testRepo = testRepo;
        }

        public IActionResult Index()//ITEstREpository tRepo,Department dept)//inject MEthod
        {
            ViewData["Id"] = testRepo.Id;
            return View();
        }
    }
}
