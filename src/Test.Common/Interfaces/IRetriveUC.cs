using System.Collections.Generic;

namespace Test.Common.Interfaces
{
    public interface IRetriveUC<T, U> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(U id);
    }
}
