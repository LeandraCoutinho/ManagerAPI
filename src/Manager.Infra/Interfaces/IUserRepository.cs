using Manager.Domain.Entities;

namespace Manager.Infra.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email); // obtém o email exato
    Task<List<User>> SearchByEmail(string email); // busca parte do email informado
    Task<List<User>> SearchByName(string name); 
}