using System;
using Test.Model;

namespace Test.BussinesLogic
{
    public abstract class BaseBL<T>
    {
        public TestDbContext DbContext { get; set; }

        public T Repository { get; set; }

        public BaseBL(TestDbContext dbContext)
        {
            DbContext = dbContext;
            Repository = (T)Activator.CreateInstance(typeof(T), DbContext);
        }
    }
}