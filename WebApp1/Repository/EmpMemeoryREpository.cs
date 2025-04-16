using WebApp1.Models;

namespace WebApp1.Repository
{
    public class EmpMemeoryREpository : IEmployeeRepository
    {
        List<Employee> employees;
        public EmpMemeoryREpository()
        {
            employees = new List<Employee>() {
                new(){Id=1,Name="Ahmed",ImageURL="m.png"},
                new(){Id=2,Name="Amira",ImageURL="2.jpg"}
            };
        }
        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return employees;
        }

        public List<Employee> GetAllWithInclue(string include)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
