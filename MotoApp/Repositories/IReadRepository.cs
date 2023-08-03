using MotoApp.Entities;

namespace MotoApp.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntitiy
    {
        IEnumerable<T> GetAll();
        T GetById(int id);    
    }
}
