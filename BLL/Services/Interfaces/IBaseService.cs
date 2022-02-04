using System.Linq.Expressions;

namespace BLL.Services.Interfaces
{
    public interface IBaseService<T> : IDisposable where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        void Remove(T entity);
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> filter = null); // Зачем тут допускается null?
        int SaveChanges();

    }
}
