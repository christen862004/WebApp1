using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Repository
{
    public class EmployeeRepository :IEmployeeRepository
    {
        CompanyContext context;
        public EmployeeRepository(CompanyContext ctx)//register
        {
            context = ctx;//
           // context = new CompanyContext();
        }

        public void Add(Employee entity)
        {
            context.Add(entity);
        }

        public void Delete(int id)
        {
            context.Remove(GetById(id));
        }

        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }
        //GetAllWithInclue("Course,Department")
        public List<Employee> GetAllWithInclue(string include="")
        {
            if (include == "")
            {
                return GetAll();
            }
            return context.Employee.Include(include).ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employee.FirstOrDefault(e => e.Id == id);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(Employee entity)
        {
            context.Update(entity);
        }
    }
}
