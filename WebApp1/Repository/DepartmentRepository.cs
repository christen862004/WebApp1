using WebApp1.Models;

namespace WebApp1.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        CompanyContext context;
        public DepartmentRepository(CompanyContext ctx)//inject ask 
        {
            context = ctx;
        }
        //CRUD : Create  - Read - Update - Delete
        //lazy load (performance)
        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }

        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(d => d.Id == id);
        }


        public void Add(Department entity)
        {
            context.Add(entity);
            
        }

        public void Delete(int id)
        {
            Department dept = GetById(id);
            context.Remove(dept);
        }

        
        public void Update(Department entity)
        {
            context.Update(entity);//id=0 new record not update
            //Department dep=GetById(entity.Id);
            //dep.Name=entity.Name;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public List<Department> GetAllWithInclue(string include)
        {
            throw new NotImplementedException();
        }
    }
}
