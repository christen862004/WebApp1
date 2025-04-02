using WebApp1.Models;

namespace WebApp1.Services
{
    public class EmployeeServices : IServices<Employee>
    {
        List<Employee> employees;
        public EmployeeServices()
        {
            employees = new List<Employee>();
            employees.Add(new Employee() { Id=1,Name="Ali",Salary=9000,Address="Alex",ImageURL="m.png",DepartmentID=1});
            employees.Add(new Employee() { Id=2,Name="Ahmed",Salary=9000,Address="Alex",ImageURL="m.png",DepartmentID=2});
            employees.Add(new Employee() { Id=3,Name="Mohamed",Salary=9000,Address="Alex",ImageURL="m.png",DepartmentID=3});
            employees.Add(new Employee() { Id=4,Name="Sara",Salary=9000,Address="Alex",ImageURL="2.jpg",DepartmentID=1});
            employees.Add(new Employee() { Id=5,Name="Mary",Salary=9000,Address="Alex",ImageURL="2.jpg",DepartmentID=2});
        }
        public List<Employee> GetAll()
        {
            return employees;
        }

        public Employee GetByID(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
