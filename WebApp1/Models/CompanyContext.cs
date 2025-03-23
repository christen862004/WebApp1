using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models
{
    public class CompanyContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        public CompanyContext():base()
        {
            
        }
        //public CompanyContext(DbContextOptions<CompanyContext> option):base(option)
        //{ 
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=G1MVC;Integrated Security=True;Encrypt=False");
        }
    }
}
