namespace WebApp1.Services
{
    public interface IServices<T>
    {
        List<T> GetAll();
        T GetByID(int id);
    }
}
