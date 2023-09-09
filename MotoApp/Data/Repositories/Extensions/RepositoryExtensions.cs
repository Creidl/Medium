using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

namespace MotoApp.Data.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddBatch<T>(this IRepository<T> repository, T[] employees)
            where T : class, IEntity
        {
            foreach (var employee in employees)
            {
                repository.Add(employee);
            }
            repository.Save();
        }
    }
}