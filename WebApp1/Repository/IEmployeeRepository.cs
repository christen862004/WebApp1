using WebApp1.Models;

namespace WebApp1.Repository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        List<Employee> GetByDeptId(int deptId,string includes=null);
    }
}
