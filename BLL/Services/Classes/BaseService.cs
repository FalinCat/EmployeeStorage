using BLL.Services.Interfaces;
using DAL;
using System.Linq.Expressions;

namespace BLL.Services.Classes
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private protected readonly EmploeeContext context;

        public BaseService(EmploeeContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            if (entity != null)
            {
                context.Set<T>().Add(entity);
            }
        }

        public void AddRange(IEnumerable<T> entity)
        {
            context.Set<T>().AddRange(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return filter == null ? context.Set<T>().FirstOrDefault() : context.Set<T>().FirstOrDefault(filter);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? context.Set<T>() : context.Set<T>().Where(filter);
        }

        public void Remove(T entity)
        {
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
            }
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
