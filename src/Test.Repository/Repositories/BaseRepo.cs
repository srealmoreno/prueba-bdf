using Test.Model;

namespace Test.Repository
{
    public abstract class BaseRepo<T>
    {
        public TestDbContext DbContext { get; set; }
        
        public BaseRepo(TestDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
