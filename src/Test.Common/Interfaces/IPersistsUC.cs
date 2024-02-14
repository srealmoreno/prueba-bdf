namespace Test.Common.Interfaces
{
    public interface IPersistsUC<T, U> where T : class
    {
        T Save(T entity);

        void Put(U id, T entity);

        void Delete(U id);
    }
}
