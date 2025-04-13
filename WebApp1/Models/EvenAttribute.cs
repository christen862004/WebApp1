using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    //mvc & web api
    //Server side press submit
    public class EvenAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            int val =int.Parse(value.ToString());

            return (val % 2 == 0);
        }
    }
}
