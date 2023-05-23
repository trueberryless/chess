using System.Linq.Expressions;

namespace Chess.Application.Services.Interfaces;

public interface IRepository<T>
{
    T Create(T entity);
    
    IEnumerable<T> Read();
    
    IEnumerable<T> Read(Expression<Func<T, bool>> filter);

    T Read(int id);

    void Update(T entity);

    T Delete(int id);
}