namespace WebApp1.Repository
{
    public interface IRepository<T>//contract
    {
        List<T> GetAll();
        List<T> GetAllWithInclue(string include);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        int Save();

    }
}
