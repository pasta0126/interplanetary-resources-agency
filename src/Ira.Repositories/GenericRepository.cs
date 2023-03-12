using Ira.Repositories.Context;
using Ira.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ira.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ILogger<GenericRepository<T>> _logger;
        private readonly IraContext _context;

        public GenericRepository(
            ILogger<GenericRepository<T>> logger,
            IraContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T Get(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
