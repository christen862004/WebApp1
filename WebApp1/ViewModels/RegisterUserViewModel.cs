using System.ComponentModel.DataAnnotations;

namespace WebApp1.ViewModels
{
    public class RegisterUserViewModel
    {
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string  Password { get; set; }

        [DataType(DataType.Password)]//extra 
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
    }
}
