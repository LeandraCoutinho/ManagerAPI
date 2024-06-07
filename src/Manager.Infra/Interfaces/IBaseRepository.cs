using Manager.Domain.Entities;

namespace Manager.Infra.Interfaces;

public interface IBaseRepository<T> where T : Base // usa-se T pra pegar toda entidade que usa Base
{
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task Remove(long id);
    Task<T?> Get(long id);
    Task<List<T>> GetTask();
}