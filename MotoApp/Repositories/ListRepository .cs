using MotoApp.Entities;

namespace MotoApp.Repositories
{
    public class ListRepository <T> :IRepository<T>
        where T : class, IEntitiy
    {
        protected readonly List<T> _items = new();

        public IEnumerable<T> GetAll()
        {
            return _items.ToList(); //zwraca kopię listy
                                    //zamiast referencji do listy gdybyśmy wpisali samo:
                                    //return _items;
        }

        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public T GetById(int id)
        { 
            return _items.Single(item => item.Id == id);
        } 

        public void Save() //docelowo ma zapisytwać dane w data storage
        {
            // w listach nie ma potrzeby zapisu
        }
    }
}
