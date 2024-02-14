using System;
using System.Collections.Generic;
using Test.Model;

namespace Test.Api.Services
{
    public abstract class BaseService<T> : IDisposable
    {
        // get the connection string from of current solution
        readonly TestDbContext DbContext = new TestDbContext("defaultCS");

        public T ControllerBl { get; set; }

        public BaseService()
        {
            ControllerBl = (T)Activator.CreateInstance(typeof(T), DbContext);
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}