namespace WebApp1.Repository
{
    public class TestRepository : ITEstREpository
    {
        public string Id { get; set; }
        public TestRepository()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
