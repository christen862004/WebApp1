using WebApp1.Controllers;
using WebApp1.Models;

namespace WebApp1.Services
{
    public class DepartmentServices : IServices<Department>
    {
        List<Department> departmentList;
        public DepartmentServices()
        {
            departmentList = new List<Department>()
            {
                new(){Id=1,Name="SD",ManagerName="Ahmed"},
                new(){Id=2,Name="OS",ManagerName="Sedq"},
                new(){Id=3,Name="UI",ManagerName="Yosry"},
                new(){Id=4,Name="Testing",ManagerName="Mora"},
            };

        }
        public List<Department> GetAll()
        {
            return departmentList;
        }

        public Department GetByID(int id)
        {
            return departmentList.FirstOrDefault(d => d.Id == id);
        }
    }
}
