namespace Ira.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(Guid id);
        void Insert(T entity);
        public void InsertRange(List<T> entities);
        void Update(T entity);
        void Delete(T entity);
    }
}
