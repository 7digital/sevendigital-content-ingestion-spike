using System.Collections.Generic;
using System.Linq;
using SevenDigital.Content.Ingestion.Spike.Domain.Boilerplate;

namespace SevenDigital.Content.Ingestion.Spike.Data
{
    public class PersistentStore : IPersistentStore
    {
        private Dictionary<PersistentKey, IPersistable> _repository;

        public PersistentStore()
        {
            _repository = new Dictionary<PersistentKey, IPersistable>();
        }

        public void Store(IPersistable item)
        {
            if (_repository.ContainsKey(item.Id))
                _repository[item.Id] = item;
            else
                _repository.Add(item.Id, item);
        }

        public T Get<T>(PersistentKey key) where T : IPersistable
        {
            return (T)_repository[key];
        }

        public IList<T> All<T>() where T : IPersistable
        {
            return _repository.Values.Cast<T>().ToList();
        }
    }
}
