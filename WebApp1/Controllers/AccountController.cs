using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp1.Models;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> UserManager,SignInManager<ApplicationUser> signInManager)//inject
        {
            userManager = UserManager;
            this.signInManager = signInManager;
        }
        #region  Register Link
        public IActionResult Register()
        {
           // ApplicationUser app=new ApplicationUser();
            
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel userFromRequest)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser UserModel = new ApplicationUser();
                UserModel.UserName = userFromRequest.UserName;
                UserModel.PasswordHash = userFromRequest.Password;
                UserModel.Address = userFromRequest.Address;
                IdentityResult result= await userManager.CreateAsync(UserModel,userFromRequest.Password);
                if (result.Succeeded == true)
                {
                    //Assign to Admin Role
                    IdentityResult RoleRe= await userManager.AddToRoleAsync(UserModel, "Admin");
                    //create cookie auth
                    //Claims (id,userName,role)
                    await signInManager.SignInAsync(UserModel,false);//asyn back
                    return RedirectToAction( "Index", "Employee");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View("Register",userFromRequest);
        }


        #endregion


        #region Login
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userFromRequest)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser userFRomDB=
                    await userManager.FindByNameAsync(userFromRequest.UserName);
                if (userFRomDB != null) {
                    //password
                    bool found=await userManager.CheckPasswordAsync(userFRomDB, userFromRequest.Password);
                    if (found == true)
                    {
                        //create Cooke With [ ID ,Name ,Role ,Email,Address] Claim
                        List<Claim> addClaim=new List<Claim>();
                        addClaim.Add(new Claim("Address", userFRomDB.Address));
                        await signInManager
                            .SignInWithClaimsAsync(userFRomDB, userFromRequest.RememberMe,addClaim);
                        //await signInManager.SignInAsync(userFRomDB, userFromRequest.RememberMe);
                        return RedirectToAction("Index", "Employee");

                    }
                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login", userFromRequest);
        }
        #endregion







        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
